using SQL_Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Reflection;
using System.Text;
using System.Windows;

/// <summary>
/// システムで共通に使う値を取得、保持するためのクラス
/// </summary>
public class SystemInfo
{
    #region API
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    private  static extern int GetPrivateProfileString(
       string lpApplicationName,
       string lpKeyName,
       string lpDefault,
       StringBuilder lpReturnedstring,
       int nSize,
       string lpFileName);

    #endregion

    #region メンバ関数

    /// <summary>
    /// ステータス
    /// </summary>
    public struct RtnStatus
    {
        public const int OK = 0;
        public const int NG = 1;
        public const int ER = 9;

    }

    public struct DataCode
    {
        public const string unit_code = "unit_code";
    }

    /// <summary>
    /// システム設定内容の連想配列
    /// </summary>
    public Dictionary<string, struct_sys002> Dic_sys002 = new Dictionary<string, struct_sys002>();

    /// <summary>
    /// システムにログインする際のデータベース
    /// </summary>
    public  struct_DatabaseConnectInfo LoginDatabase = new struct_DatabaseConnectInfo();

    /// <summary>
    /// システムとして使用するデータベース
    /// </summary>
    public  struct_DatabaseConnectInfo SystemDatabase = new struct_DatabaseConnectInfo();

    /// <summary>
    /// 起動プログラムID
    /// </summary>
    public  string strExeName;

    /// <summary>
    /// 最新取得日時
    /// </summary>
    public DateTime dtNow;

    /// <summary>
    /// ローカル設定ファイル
    /// </summary>
    public  readonly string strKankyoPath = Environment.GetEnvironmentVariable("MKDIR");

    #region "コマンドライン引数"
    /// <summary>
    /// コマンドライン引数　キー
    /// </summary>
    private struct CommandLineArgs_Key
    {
        public const string kigyo_code = "kigyo_code";
        public const string user_id = "user_id";
    }
    public struct struct_CommandLineArgs
    {
        public string kigyo_code;
        public string user_id;
    }


    /// <summary>
    /// コマンドライン引数受け取り用
    /// </summary>
    public  struct_CommandLineArgs ComLineArgs = new struct_CommandLineArgs();

    /// <summary>
    /// コマンドライン引数引き渡し用
    /// </summary>
    public  struct_CommandLineArgs ComLineArgs_Set = new struct_CommandLineArgs();
    #endregion

    #endregion

    /// <summary>
    /// システム情報取得初期処理を実行
    /// </summary>
    public void InitProc()
    {

        // コマンドライン引数取得処理を実行
        GetCommandLineArgs();

        // ログイン、システム共通設定情報取得処理
        LoginDatabase.ServerName = SetIniInfo("DB1", "SERVER");
        LoginDatabase.DatabaseName = SetIniInfo("DB1", "NAME");
        LoginDatabase.User = SetIniInfo("DB1", "USER");
        LoginDatabase.Pass = SetIniInfo("DB1", "PASS");

        // システム設定情報取得処理
        SQL_Server.SqlServer clsSqlServer = new SQL_Server.SqlServer(LoginDatabase);
        clsSqlServer.Connect();
        Com02.Select_sys002(clsSqlServer);

        // システムとして使用するデータベースの接続先を設定
        SystemDatabase.ServerName = SetIniInfo("DB2", "SERVER");
        SystemDatabase.DatabaseName = SetIniInfo("DB2", "NAME");
        SystemDatabase.User = SetIniInfo("DB2", "USER");
        SystemDatabase.Pass = SetIniInfo("DB2", "PASS");

    }

    /// <summary>
    /// コマンドライン引数の値を構造体へセット
    /// </summary>
    private void GetCommandLineArgs()
    {

        // 引数取得
        string[] strAryCommandLineArgs = Environment.GetCommandLineArgs();

        if (strAryCommandLineArgs.Length == 1)
        {
            // コマンドライン引数なし時の処理
            Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "コマンドライン引数なし", "");
            return;
        }

        // 引数を構造体へ
        for (int intCount = 1; intCount <= strAryCommandLineArgs.Length - 1; intCount++)
        {
            // Key==Valueとなるように指定している前提
            string[] words = strAryCommandLineArgs[intCount].Split("==");
            if (words.Length != 2)
            {
                // 想定通りの形ではない場合は飛ばす
                continue;
            }

            switch (words[0])
            {
                case CommandLineArgs_Key.kigyo_code:

                    ComLineArgs.kigyo_code = words[1];
                    break;

                case CommandLineArgs_Key.user_id:

                    ComLineArgs.user_id = words[1];
                    break;

            }

        }
    }

    /// <summary>
    /// システム設定情報設定
    /// </summary>
    /// <param material_name="strSection"></param>
    /// <param material_name="strKey"></param>
    /// <returns></returns>
    private string SetIniInfo(string strSection, string strKey)
    {

        string strKankyoIniFile = strKankyoPath + "\\KANKYO\\Kankyo.ini";

        try
        {

            if (System.IO.File.Exists(strKankyoIniFile) == false)
            {
                // ファイルが存在しない場合は例外
                throw new Exception("環境ファイルが存在しません。[" + strKankyoIniFile + "]");
            }

            StringBuilder sb = new StringBuilder(256);
            GetPrivateProfileString(strSection, strKey, string.Empty, sb, sb.Capacity, strKankyoIniFile);

            return sb.ToString();

        }
        catch (Exception ex)
        {

            // ログに記載
            Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "環境設定取得処理に失敗しました。", ex.Message);
            return "";
        }
    }

    /// <summary>
    /// システム設定情報
    /// </summary>
    /// <param material_name="strSection"></param>
    /// <param material_name="strKey"></param>
    /// <returns></returns>
    private string GetIniInfo(string strSection, string strKey)
    {

        string strKankyoIniFile = strKankyoPath + "\\KANKYO\\Kankyo.ini";

        try
        {

            if (System.IO.File.Exists(strKankyoIniFile) == false)
            {
                // ファイルが存在しない場合は例外
                throw new Exception("環境ファイルが存在しません。[" + strKankyoIniFile + "]");
            }

            StringBuilder sb = new StringBuilder(256);
            GetPrivateProfileString(strSection, strKey, string.Empty, sb, sb.Capacity, strKankyoIniFile);
            return sb.ToString();

        }
        catch (Exception ex)
        {

            // ログに記載
            Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "環境設定取得処理に失敗しました。", ex.Message);
            return "";
        }
    }

}
