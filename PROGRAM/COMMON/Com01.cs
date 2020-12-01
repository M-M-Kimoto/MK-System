using SQL_Server;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using static SystemInfo;

public static class Com01
{
    public static SystemInfo clsSystemInfo = new SystemInfo();

    /// <summary>
    /// システム初期処理
    /// </summary>
    public static void SystemInit()
    {
        // システム情報取得初期処理を実行
        clsSystemInfo.InitProc();

        // 起動プログラムIDをセット
        clsSystemInfo.strExeName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);

    }

    #region "システム初期処理"


    #endregion

    #region "全システム共通処理　ログ関係"
    /// <summary>
    /// 画面下部メッセージ表示内容作成処理
    /// </summary>
    public static string GetAppMessage(string strFunctionName, string strMessage, string strErrMessage, bool booOutputFlg = false)
    {
        string strReturnMessage;

        strReturnMessage = strMessage + " " + strErrMessage;

        if (booOutputFlg == true)
        {
            // リターン内容をテキストに吐き出す
            SetLogWrite(String.Format("{0, -30}", strFunctionName) + " " + strReturnMessage);
        }
        return strReturnMessage;
    }

    /// <summary>
    /// プログラム別ログファイル書き込み処理
    /// </summary>
    /// <param material_name="strLog"></param>
    private static void SetLogWrite(string strLog)
    {
        string strKankyoFile;
        string strExeName;

        strKankyoFile = Com01.clsSystemInfo.strKankyoPath + "\\LOG";
        if (System.IO.Directory.Exists(strKankyoFile) == false)
        {
            // パスが存在しない場合は作成する
            Directory.CreateDirectory(strKankyoFile);
        }

        // 
        if (Com01.clsSystemInfo.strExeName != "")
        {
            strExeName = Com01.clsSystemInfo.strExeName;
        }
        else
        {
            strExeName = "log";
        }

        // ファイルパスを作成し、上書き許可でストリームを開く
        strKankyoFile += "\\" + strExeName + ".log";
        StreamWriter writer = new StreamWriter(strKankyoFile, true, Encoding.GetEncoding("UTF-8"));

        // テキストを書き込む
        writer.WriteLine(strLog);

        // ファイルを閉じる
        writer.Close();
    }
    #endregion

    /// <summary>
    /// システム日時更新処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    public static void Set_DateTime(SqlServer clsSqlServer)
    {

        clsSystemInfo.dtNow = Com02.Get_SYSDATE(clsSqlServer);

    }

    #region "全システム共通処理　他実行ファイル起動関係"

    /// <summary>
    /// 別プロジェクト起動処理
    /// </summary>
    public static bool CallMenuExe(string strExeName, struct_CommandLineArgs _CommandLineArgs)
    {
        try
        {
            // パスを変数に
            string strExepath;
            strExepath = Com01.clsSystemInfo.strKankyoPath + "\\EXE\\" + strExeName + ".exe";
            if (System.IO.File.Exists(strExepath) == false)
            {
                // ファイルが存在しない場合は例外
                throw new Exception("実行ファイルが存在しません。[" + strExepath + "]");
            }

            // コマンドライン引数を設定
            string strArgs = GetComLineArgs(_CommandLineArgs);

            // プロセスを作成
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @strExepath;
            proc.StartInfo.Arguments = strArgs;

            // 実行
            proc.Start();

            return true;
        }
        catch (Exception ex)
        {

            // ログに記載
            GetAppMessage(MethodBase.GetCurrentMethod().Name, "実行ファイルの起動処理に失敗", ex.Message);

            return false;
        }

    }

    /// <summary>
    /// コマンドライン引数構造体から文字列に
    /// </summary>
    /// <param material_name="_CommandLineArgs"></param>
    /// <returns></returns>
    public static string GetComLineArgs(struct_CommandLineArgs _CommandLineArgs)
    {
        string strArgs = "";

        // 企業コード
        if (_CommandLineArgs.kigyo_code != null && _CommandLineArgs.kigyo_code != "")
        {
            strArgs += " " + nameof(_CommandLineArgs.kigyo_code) + "==" + _CommandLineArgs.kigyo_code;
        }

        // ユーザID
        if (_CommandLineArgs.user_id != null && _CommandLineArgs.user_id != "")
        {
            strArgs += " "+ nameof(_CommandLineArgs.user_id) + "==" + _CommandLineArgs.user_id;
        }

        return strArgs.Trim();
    }

    #endregion

}
