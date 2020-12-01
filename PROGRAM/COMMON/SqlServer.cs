using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SQL_Server
{
    #region 構造体
    /// <summary>
    /// データベース接続先１
    /// ログイン情報など
    /// </summary>
    public struct struct_DatabaseConnectInfo
    {
        public string ServerName;
        public string DatabaseName;
        public string User;
        public string Pass;
    }

    /// <summary>
    /// vew001構造体
    /// </summary>
    public struct struct_vew001
    {
        public DateTime toroku_datetime;
        public string toroku_user_id;
        public DateTime koshin_datetime;
        public string koshin_user_id;
        public string kigyo_code;
        public string kigyo_name;
        public DateTime keiyaku_date;
        public int license_kikan;
        public DateTime manryo_date;
        public string user_name;
        public int status;
        public string user_id;
        public string pass;
    }

    /// <summary>
    /// sys002構造体
    /// </summary>
    public struct struct_sys002
    {
        public DateTime toroku_datetime;
        public string toroku_user_id;
        public DateTime koshin_datetime;
        public string koshin_user_id;
        public string data_code_name;
        public string data_code_name_jp;
        public string data_name;
        public string code;
        public int code_min;
        public int code_max;
        public int invalid_flg;
    }

    /// <summary>
    /// sys003構造体
    /// </summary>
    public struct struct_sys003
    {
        public DateTime toroku_datetime;
        public string toroku_user_id;
        public DateTime koshin_datetime;
        public string koshin_user_id;
        public string news;
        public int invalid_flg;
    }

    #endregion

    public class SqlServer
    {
        #region メンバ変数

        /// <summary>
        /// 接続情報
        /// </summary>
        private struct_DatabaseConnectInfo M_SqlConnectInfo;

        /// <summary>
        /// コネクション
        /// </summary>
        private SqlConnection M_Connection;

        #endregion

        #region "エラーコード"
        private string strErrCode;
        /// <summary>
        /// メッセージ
        /// </summary>
        public string ErrCode
        {
            get { return strErrCode; }
            set
            {
                strErrCode = value;
            }
        }
        #endregion

        #region メンバ関数


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param material_name="strServer"></param>
        /// <param material_name="strDatabase"></param>
        /// <param material_name="strUser"></param>
        /// <param material_name="strPass"></param>
        public SqlServer(struct_DatabaseConnectInfo DatabaseConnectInfo)
        {
            //引数の値をこのクラスのプロパティとしてセット
            M_SqlConnectInfo = DatabaseConnectInfo;
        }

        /// <summary>
        /// 接続開始
        /// </summary>
        public void Connect()
        {
            string strConnectonString = "";
            try
            {
                // 接続文字列を作成
                strConnectonString = "Server = " + M_SqlConnectInfo.ServerName + ";"
                                    + "Database=" + M_SqlConnectInfo.DatabaseName + ";"
                                    + "User ID = " + M_SqlConnectInfo.User + ";"
                                    + "Password = " + M_SqlConnectInfo.Pass + ";"
                                    + "MultipleActiveResultSets=True;";

                // データベース接続の準備
                M_Connection = new SqlConnection(strConnectonString);

                // データベースの接続開始
                M_Connection.Open();
            }
            catch (Exception ex)
            {
                Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "SQL Server接続処理に失敗[" + strConnectonString + "]", ex.Message);
            }
        }

        /// <summary>
        /// Select文実行関数
        /// </summary>
        /// <param material_name="strSql"></param>
        public DataTable ExeSQL_Select(string strSql)
        {
            var table = new DataTable();
            var command = new SqlCommand();

            try
            {
                // 実行するSQLの準備
                command.Connection = M_Connection;
                command.CommandTimeout = 0;
                command.CommandText = @strSql;

                // SQLの実行
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

            }
            catch (SqlException exSql)
            {
                ErrCode = exSql.Number.ToString();
                Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "Select文実行処理に失敗", exSql.Message + "[ErrCode：" + exSql.Number + "]" + "[" + strSql + "]");
            }
            catch (Exception ex)
            {
                Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "Select文実行処理で例外が発生", ex.Message + "[" + strSql + "]");
            }

            return table;
        }

        /// <summary>
        /// データベース更新実行処理
        /// ※Insert Update Delete
        /// </summary>
        /// <param material_name="strSql"></param>
        public int ExeDatabaseUpdate(string strSql)
        {
            var table = new DataTable();
            var command = new SqlCommand();

            try
            {
                // 実行するSQLの準備
                command.Connection = M_Connection;
                command.CommandTimeout = 0;
                command.CommandText = @strSql;

                // SQLの実行
                command.ExecuteNonQuery();

                return SystemInfo.RtnStatus.OK;
            }
            catch(SqlException exSql)
            {
                ErrCode = exSql.Number.ToString();
                Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "DB更新処理に失敗", exSql.Message + "[ErrCode：" + exSql.Number + "]" + "[" + strSql + "]");
                return SystemInfo.RtnStatus.NG;
            }
            catch (Exception ex)
            {
                Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, "DB更新処理で例外が発生", ex.Message + "[" + strSql + "]");
                return SystemInfo.RtnStatus.ER;
            }

        }

        #endregion
    }

}

