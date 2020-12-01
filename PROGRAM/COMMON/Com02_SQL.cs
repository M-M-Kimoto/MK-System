using SQL_Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;

/// <summary>
/// テーブルデータ取得共通処理
/// </summary>
public static class Com02
{
    // 改行
    static string ctrl = Environment.NewLine;

    /// <summary>
    /// システム日時取得処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    public static DateTime Get_SYSDATE(SqlServer clsSqlServer)
    {
        DataTable dTable = clsSqlServer.ExeSQL_Select("SELECT format(SYSDATETIME(), 'yyyy/MM/dd HH:mm:ss') AS SYSDATETIME");

        return DateTime.Parse(dTable.Rows[0].ItemArray[0].ToString());

    }

    #region "ログイン情報"
    /// <summary>
    /// システム設定情報取得処理
    /// </summary>
    /// <param material_name="clsSqlServer"></param>
    /// <returns></returns>
    public static Dictionary<string, struct_sys002> Select_sys002(SqlServer clsSqlServer)
    {
        string strSql = "";
        DataTable DatSqlResult = new DataTable();
        Dictionary<string, struct_sys002> Dic_sys002 = new Dictionary<string, struct_sys002>();

        strSql += ctrl + " " + "select ";
        strSql += ctrl + " " + "   toroku_datetime		,";
        strSql += ctrl + " " + "   toroku_user_id		,";
        strSql += ctrl + " " + "   koshin_datetime		,";
        strSql += ctrl + " " + "   koshin_user_id		,";
        strSql += ctrl + " " + "   data_name			,";
        strSql += ctrl + " " + "   data_code_name		,";
        strSql += ctrl + " " + "   data_code_name_jp	,";
        strSql += ctrl + " " + "   code				,";
        strSql += ctrl + " " + "   code_min			,";
        strSql += ctrl + " " + "   code_max			";
        strSql += ctrl + " " + "from sys002";
        strSql += ctrl + " " + "where 1 = 1";
        strSql += ctrl + " " + "and invalid_flg = 0";

        // sqlの実行
        DatSqlResult = clsSqlServer.ExeSQL_Select(strSql);

        // データテーブルを構造体の連想配列にセット
        for (int intRowCount = 0; intRowCount < DatSqlResult.Rows.Count; intRowCount++)
        {
            struct_sys002 Struct_sys002 = new struct_sys002();

            Struct_sys002.toroku_datetime = DateTime.Parse(DatSqlResult.Rows[intRowCount]["toroku_datetime"].ToString());
            Struct_sys002.toroku_user_id = DatSqlResult.Rows[intRowCount]["toroku_user_id"].ToString();
            Struct_sys002.koshin_datetime = DateTime.Parse(DatSqlResult.Rows[intRowCount]["koshin_datetime"].ToString());
            Struct_sys002.koshin_user_id = DatSqlResult.Rows[intRowCount]["koshin_user_id"].ToString();
            Struct_sys002.data_name = DatSqlResult.Rows[intRowCount]["data_name"].ToString();
            Struct_sys002.data_code_name = DatSqlResult.Rows[intRowCount]["data_code_name"].ToString();
            Struct_sys002.data_code_name_jp = DatSqlResult.Rows[intRowCount]["data_code_name_jp"].ToString();
            Struct_sys002.code = DatSqlResult.Rows[intRowCount]["code"].ToString();
            Struct_sys002.code_min = int.Parse(DatSqlResult.Rows[intRowCount]["code_min"].ToString());
            Struct_sys002.code_max = int.Parse(DatSqlResult.Rows[intRowCount]["code_max"].ToString());

            // セット
            Dic_sys002.Add(Struct_sys002.data_name, Struct_sys002);

        }
        return Dic_sys002;
    }


    /// <summary>
    /// ユーザ情報取得処理
    /// </summary>
    /// <param material_name="clsSqlServer"></param>
    /// <param material_name="strKigyoCode"></param>
    /// <param material_name="strUserID"></param>
    /// <param material_name="strPassWord"></param>
    /// <returns></returns>
    public static Dictionary<string, struct_vew001> Select_vew001(SqlServer clsSqlServer, string strKigyoCode, string strUserID, string strPassWord)
    {
        string strSql = "";
        DataTable DatSqlResult = new DataTable();
        Dictionary<string, struct_vew001> Dic_vew001 = new Dictionary<string, struct_vew001>();

        strSql += ctrl + " " + "select ";
        strSql += ctrl + " " + "   toroku_datetime,";
        strSql += ctrl + " " + "   toroku_user_id ,";
        strSql += ctrl + " " + "   koshin_datetime,";
        strSql += ctrl + " " + "   koshin_user_id ,";
        strSql += ctrl + " " + "   kigyo_code     ,";
        strSql += ctrl + " " + "   kigyo_name     ,";
        strSql += ctrl + " " + "   keiyaku_date   ,";
        strSql += ctrl + " " + "   license_kikan  ,";
        strSql += ctrl + " " + "   manryo_date    ,";
        strSql += ctrl + " " + "   user_name      ,";
        strSql += ctrl + " " + "   status         ,";
        strSql += ctrl + " " + "   user_id        ,";
        strSql += ctrl + " " + "   pass           ";
        strSql += ctrl + " " + "from vew001";
        strSql += ctrl + " " + "where 1 = 1";
        strSql += ctrl + " " + "and kigyo_code = '" + strKigyoCode + "'";
        strSql += ctrl + " " + "and user_id    = '" + strUserID + "'";
        strSql += ctrl + " " + "and pass       = '" + strPassWord + "'";

        // sqlの実行
        DatSqlResult = clsSqlServer.ExeSQL_Select(strSql);

        // データテーブルを構造体の連想配列にセット
        for (int intRowCount = 0; intRowCount < DatSqlResult.Rows.Count; intRowCount++)
        {
            struct_vew001 Struct_vew001 = new struct_vew001();

            Struct_vew001.toroku_datetime = DateTime.Parse(DatSqlResult.Rows[intRowCount]["toroku_datetime"].ToString());
            Struct_vew001.toroku_user_id = DatSqlResult.Rows[intRowCount]["toroku_user_id"].ToString();
            Struct_vew001.koshin_datetime = DateTime.Parse(DatSqlResult.Rows[intRowCount]["koshin_datetime"].ToString());
            Struct_vew001.koshin_user_id = DatSqlResult.Rows[intRowCount]["koshin_user_id"].ToString();
            Struct_vew001.kigyo_code = DatSqlResult.Rows[intRowCount]["kigyo_code"].ToString();
            Struct_vew001.kigyo_name = DatSqlResult.Rows[intRowCount]["kigyo_name"].ToString();
            Struct_vew001.keiyaku_date = DateTime.Parse(DatSqlResult.Rows[intRowCount]["keiyaku_date"].ToString());
            Struct_vew001.license_kikan = int.Parse(DatSqlResult.Rows[intRowCount]["license_kikan"].ToString());
            Struct_vew001.manryo_date = DateTime.Parse(DatSqlResult.Rows[intRowCount]["manryo_date"].ToString());
            Struct_vew001.user_name = DatSqlResult.Rows[intRowCount]["user_name"].ToString();
            Struct_vew001.status = int.Parse(DatSqlResult.Rows[intRowCount]["status"].ToString());
            Struct_vew001.user_id = DatSqlResult.Rows[intRowCount]["user_id"].ToString();
            Struct_vew001.pass = DatSqlResult.Rows[intRowCount]["pass"].ToString();

            // セット
            Dic_vew001.Add(Struct_vew001.kigyo_code, Struct_vew001);

        }

        return Dic_vew001;

    }
    #endregion

    #region "テーブル定義"
    public struct struct_v_Teigi
    {

        public const int idx_DatabaseName = 0;
        public const int idx_SchemaName = 1;
        public const int idx_TableName = 2;
        public const int idx_ColumnID = 3;
        public const int idx_PrimaryKey = 4;
        public const int idx_ColumnName = 5;
        public const int idx_ColumnName_JP = 6;
        public const int idx_IS_NULLABLE = 7;
        public const int idx_data_type = 8;
        public const int idx_default_val = 9;
        public const int idx_MaxInteger = 10;
        public const int idx_MaxDecimal = 11;
    }




    public static DataTable Get_v_Teigi(SqlServer clsSqlServer, string TableName, int intCount = 99)
    {

        string strSql;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "select top(" + intCount + ")";
            strSql += ctrl + " " + "    DatabaseName ,";
            strSql += ctrl + " " + "    SchemaName   ,";
            strSql += ctrl + " " + "    TableName    ,";
            strSql += ctrl + " " + "    ColumnID     ,";
            strSql += ctrl + " " + "    PrimaryKey   ,";
            strSql += ctrl + " " + "    ColumnName   ,";
            strSql += ctrl + " " + "    ColumnName_JP,";
            strSql += ctrl + " " + "    IS_NULLABLE  ,";
            strSql += ctrl + " " + "    data_type    ,";
            strSql += ctrl + " " + "    default_val  ,";
            strSql += ctrl + " " + "    MaxInteger   ,";
            strSql += ctrl + " " + "    MaxDecimal   ";
            strSql += ctrl + " " + "from v_Teigi";
            #region where 
            strSql += ctrl + " " + "where 1 = 1";
            strSql += ctrl + " " + "  and  TableName    = '" + TableName + "'";
            strSql += ctrl + " " + "  order by DatabaseName, TableName, ColumnID";

            #endregion

            #endregion

            // sqlの実行
            return clsSqlServer.ExeSQL_Select(strSql);

        }
        catch
        {
            return new DataTable();
        }

    }



    #endregion

    #region "システム　マスタ関係"

    #region "区分マスタ"

    public struct struct_m_kbn
    {
        public string toroku_datetime;
        public string toroku_user_id;
        public string toroku_program;
        public string koshin_datetime;
        public string koshin_user_id;
        public string koshin_program;
        public string kigyo_code;
        public int invalid_flg;

        public string data_code;
        public string data_name;
        public string kbn;
        public string name;
        public string komoku1;
        public string komoku2;
        public string komoku3;
        public string komoku4;
        public string komoku5;
        public int    flg1;
        public int    flg2;
        public int    flg3;
        public int    flg4;
        public int    flg5;

        public const int idx_toroku_datetime = 0;
        public const int idx_toroku_user_id = 1;
        public const int idx_toroku_program = 2;
        public const int idx_koshin_datetime = 3;
        public const int idx_koshin_user_id = 4;
        public const int idx_koshin_program = 5;
        public const int idx_kigyo_code = 6;
        public const int idx_invalid_flg = 7;

        public const int idx_data_code=8;
        public const int idx_data_name=9;
        public const int idx_kbn=10;
        public const int idx_name=11;
        public const int idx_komoku1=12;
        public const int idx_komoku2=13;
        public const int idx_komoku3=14;
        public const int idx_komoku4=15;
        public const int idx_komoku5=16;
        public const int idx_flg1=17;
        public const int idx_flg2=18;
        public const int idx_flg3=19;
        public const int idx_flg4=20;
        public const int idx_flg5=21;

    }

    /// <summary>
    /// マテリアルマスタ取得SQL作成処理
    /// </summary>
    /// <param material_name="clsSqlServer"></param>
    /// <param material_name="struct_m_kbn"></param>
    /// <param material_name="intCount"></param>
    /// <returns></returns>
    public static DataTable Get_v_kbn(SqlServer clsSqlServer, struct_m_kbn struct_m_kbn, int intCount = 9999)
    {

        string strSql;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "select top(" + intCount + ")";
            strSql += ctrl + " " + "    toroku_datetime,";
            strSql += ctrl + " " + "    toroku_user_id,";
            strSql += ctrl + " " + "    toroku_program,";
            strSql += ctrl + " " + "    koshin_datetime,";
            strSql += ctrl + " " + "    koshin_user_id,";
            strSql += ctrl + " " + "    koshin_program,";
            strSql += ctrl + " " + "    kigyo_code,";
            strSql += ctrl + " " + "    invalid_flg,";
            strSql += ctrl + " " + "    data_code,";
            strSql += ctrl + " " + "    data_name,";
            strSql += ctrl + " " + "    kbn,";
            strSql += ctrl + " " + "    name,";
            strSql += ctrl + " " + "    komoku1,";
            strSql += ctrl + " " + "    komoku2,";
            strSql += ctrl + " " + "    komoku3,";
            strSql += ctrl + " " + "    komoku4,";
            strSql += ctrl + " " + "    komoku5,";
            strSql += ctrl + " " + "    flg1,";
            strSql += ctrl + " " + "    flg2,";
            strSql += ctrl + " " + "    flg3,";
            strSql += ctrl + " " + "    flg4,";
            strSql += ctrl + " " + "    flg5";
            strSql += ctrl + " " + "from v_kbn";
            #region where 
            strSql += ctrl + " " + "where 1 = 1";
            if (!(struct_m_kbn.toroku_datetime == "" || struct_m_kbn.toroku_datetime is null))
            {
                strSql += ctrl + " " + "and toroku_datetime = '" + struct_m_kbn.toroku_datetime + "'";
            }
            if (!(struct_m_kbn.toroku_user_id == "" || struct_m_kbn.toroku_user_id is null))
            {
                strSql += ctrl + " " + "and toroku_user_id = '" + struct_m_kbn.toroku_user_id + "'";
            }
            if (!(struct_m_kbn.toroku_program == "" || struct_m_kbn.toroku_program is null))
            {
                strSql += ctrl + " " + "and toroku_program = '" + struct_m_kbn.toroku_program + "'";
            }
            if (!(struct_m_kbn.koshin_datetime == "" || struct_m_kbn.toroku_datetime is null))
            {
                strSql += ctrl + " " + "and koshin_datetime = '" + struct_m_kbn.koshin_datetime + "'";
            }
            if (!(struct_m_kbn.koshin_user_id == "" || struct_m_kbn.koshin_user_id is null))
            {
                strSql += ctrl + " " + "and koshin_user_id = '" + struct_m_kbn.koshin_user_id + "'";
            }
            if (!(struct_m_kbn.koshin_program == "" || struct_m_kbn.koshin_program is null))
            {
                strSql += ctrl + " " + "and koshin_program = '" + struct_m_kbn.koshin_program + "'";
            }
            if (!(struct_m_kbn.kigyo_code == "" || struct_m_kbn.kigyo_code is null))
            {
                strSql += ctrl + " " + "and kigyo_code in ('', '" + struct_m_kbn.kigyo_code + "')";
            }
            else
            {
                strSql += ctrl + " " + "and kigyo_code = ''";
            }

            strSql += ctrl + " " + "and invalid_flg = " + struct_m_kbn.invalid_flg + "";

            if (!(struct_m_kbn.data_code == "" || struct_m_kbn.data_code is null))
            {
                strSql += ctrl + " " + "and data_code = '" + struct_m_kbn.data_code + "'";
            }
            if (!(struct_m_kbn.kbn == "" || struct_m_kbn.kbn is null))
            {
                strSql += ctrl + " " + "and kbn = '" + struct_m_kbn.kbn + "'";
            }
            #endregion

            #endregion

            // sqlの実行
            return clsSqlServer.ExeSQL_Select(strSql);

        }
        catch
        {
            return new DataTable();
        }

    }

    #endregion

    #region "m_material"
    public struct struct_m_material
    {
        public string toroku_datetime;
        public string toroku_user_id;
        public string toroku_program;
        public string koshin_datetime;
        public string koshin_user_id;
        public string koshin_program;
        public string kigyo_code;
        public int invalid_flg;
        public string material_code;
        public string material_name;
        public string unit_kbn;
        public string type_name;
        public string kikaku_shiyo;
        public string biko;
        public string yobi1;
        public string yobi2;
        public string yobi3;
        public string yobi4;
        public string yobi5;

        public const int idx_toroku_datetime = 0;
        public const int idx_toroku_user_id = 1;
        public const int idx_toroku_program = 2;
        public const int idx_koshin_datetime = 3;
        public const int idx_koshin_user_id = 4;
        public const int idx_koshin_program = 5;
        public const int idx_kigyo_code = 6;
        public const int idx_invalid_flg = 7;
        public const int idx_material_code = 8;
        public const int idx_material_name = 9;
        public const int idx_unit_kbn = 10;
        public const int idx_type_name = 11;
        public const int idx_kikaku_shiyo = 12;
        public const int idx_biko = 13;
        public const int idx_yobi1 = 14;
        public const int idx_yobi2 = 15;
        public const int idx_yobi3 = 16;
        public const int idx_yobi4 = 17;
        public const int idx_yobi5 = 18;

    }

    /// <summary>
    /// マテリアルマスタ取得SQL作成処理
    /// </summary>
    /// <param material_name="clsSqlServer"></param>
    /// <param material_name="m_material"></param>
    /// <param material_name="intCount"></param>
    /// <returns></returns>
    public static DataTable Get_m_material(SqlServer clsSqlServer, struct_m_material m_material, int intCount = 9999)
    {

        string strSql;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "select top(" + intCount + ")";
            strSql += ctrl + " " + "    toroku_datetime,";
            strSql += ctrl + " " + "    toroku_user_id,";
            strSql += ctrl + " " + "    toroku_program,";
            strSql += ctrl + " " + "    koshin_datetime,";
            strSql += ctrl + " " + "    koshin_user_id,";
            strSql += ctrl + " " + "    koshin_program,";
            strSql += ctrl + " " + "    kigyo_code,";
            strSql += ctrl + " " + "    invalid_flg,";
            strSql += ctrl + " " + "    material_code,";
            strSql += ctrl + " " + "    material_name,";
            strSql += ctrl + " " + "    unit_kbn,";
            strSql += ctrl + " " + "    type_name,";
            strSql += ctrl + " " + "    kikaku_shiyo,";
            strSql += ctrl + " " + "    biko,";
            strSql += ctrl + " " + "    yobi1,";
            strSql += ctrl + " " + "    yobi2,";
            strSql += ctrl + " " + "    yobi3,";
            strSql += ctrl + " " + "    yobi4,";
            strSql += ctrl + " " + "    yobi5";
            strSql += ctrl + " " + "from m_material";
            #region where 
            strSql += ctrl + " " + "where 1 = 1";
            if (!(m_material.toroku_datetime == "" || m_material.toroku_datetime is null))
            {
                strSql += ctrl + " " + "and toroku_datetime = '" + m_material.toroku_datetime + "'";
            }
            if (!(m_material.toroku_user_id == "" || m_material.toroku_user_id is null))
            {
                strSql += ctrl + " " + "and toroku_user_id = '" + m_material.toroku_user_id + "'";
            }
            if (!(m_material.toroku_program == "" || m_material.toroku_program is null))
            {
                strSql += ctrl + " " + "and toroku_program = '" + m_material.toroku_program + "'";
            }
            if (!(m_material.koshin_datetime == "" || m_material.toroku_datetime is null))
            {
                strSql += ctrl + " " + "and koshin_datetime = '" + m_material.koshin_datetime + "'";
            }
            if (!(m_material.koshin_user_id == "" || m_material.koshin_user_id is null))
            {
                strSql += ctrl + " " + "and koshin_user_id = '" + m_material.koshin_user_id + "'";
            }
            if (!(m_material.koshin_program == "" || m_material.koshin_program is null))
            {
                strSql += ctrl + " " + "and koshin_program = '" + m_material.koshin_program + "'";
            }
            if (!(m_material.kigyo_code == "" || m_material.kigyo_code is null))
            {
                strSql += ctrl + " " + "and kigyo_code = '" + m_material.kigyo_code + "'";
            }
            if (!(m_material.material_code == "" || m_material.material_code is null))
            {
                strSql += ctrl + " " + "and material_code like '" + m_material.material_code + "'";
            }
            if (!(m_material.material_name == "" || m_material.material_name is null))
            {
                strSql += ctrl + " " + "and material_name like '" + m_material.material_name + "'";
            }
            if (!(m_material.unit_kbn == "" || m_material.unit_kbn is null))
            {
                strSql += ctrl + " " + "and unit_kbn = '" + m_material.unit_kbn + "'";
            }
            if (!(m_material.type_name == "" || m_material.type_name is null))
            {
                strSql += ctrl + " " + "and type_name like '" + m_material.type_name + "'";
            }
            if (!(m_material.kikaku_shiyo == "" || m_material.kikaku_shiyo is null))
            {
                strSql += ctrl + " " + "and kikaku_shiyo like '" + m_material.kikaku_shiyo + "'";
            }
            if (!(m_material.biko == "" || m_material.biko is null))
            {
                strSql += ctrl + " " + "and biko like '" + m_material.biko + "'";
            }
            if (!(m_material.yobi1 == "" || m_material.yobi1 is null))
            {
                strSql += ctrl + " " + "and yobi1 like '" + m_material.yobi1 + "'";
            }
            if (!(m_material.yobi2 == "" || m_material.yobi2 is null))
            {
                strSql += ctrl + " " + "and yobi2 like '" + m_material.yobi2 + "'";
            }
            if (!(m_material.yobi3 == "" || m_material.yobi3 is null))
            {
                strSql += ctrl + " " + "and yobi3 like '" + m_material.yobi3 + "'";
            }
            if (!(m_material.yobi4 == "" || m_material.yobi4 is null))
            {
                strSql += ctrl + " " + "and yobi4 like '" + m_material.yobi4 + "'";
            }
            if (!(m_material.yobi5 == "" || m_material.yobi5 is null))
            {
                strSql += ctrl + " " + "and yobi5 like '" + m_material.yobi5 + "'";
            }
            // 無効フラグは「有効のみ」または「すべて」とする
            if (m_material.invalid_flg == 0)
            {
                strSql += ctrl + " " + "and invalid_flg = 0";
            }

            #endregion

            #endregion

            // sqlの実行
            return clsSqlServer.ExeSQL_Select(strSql);

        }
        catch
        {
            return new DataTable();
        }

    }

    /// <summary>
    /// マテリアルマスタ新規登録処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    /// <param name="m_material"></param>
    /// <returns></returns>
    public static int Insert_m_material(SqlServer clsSqlServer, struct_m_material m_material)
    {

        string strSql;
        int intRtn;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "insert into m_material";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    toroku_datetime ,";
            strSql += ctrl + " " + "    toroku_user_id  ,";
            strSql += ctrl + " " + "    toroku_program  ,";
            strSql += ctrl + " " + "    koshin_datetime ,";
            strSql += ctrl + " " + "    koshin_user_id  ,";
            strSql += ctrl + " " + "    koshin_program  ,";
            strSql += ctrl + " " + "    kigyo_code      ,";
            strSql += ctrl + " " + "    invalid_flg     ,";
            strSql += ctrl + " " + "    material_code   ,";
            strSql += ctrl + " " + "    material_name   ,";
            strSql += ctrl + " " + "    unit_kbn       ,";
            strSql += ctrl + " " + "    type_name       ,";
            strSql += ctrl + " " + "    kikaku_shiyo    ,";
            strSql += ctrl + " " + "    biko            ,";
            strSql += ctrl + " " + "    yobi1           ,";
            strSql += ctrl + " " + "    yobi2           ,";
            strSql += ctrl + " " + "    yobi3           ,";
            strSql += ctrl + " " + "    yobi4           ,";
            strSql += ctrl + " " + "    yobi5           ";
            strSql += ctrl + " " + ")";
            strSql += ctrl + " " + "values";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    '" + m_material.toroku_datetime + "',";
            strSql += ctrl + " " + "    '" + m_material.toroku_user_id + "',";
            strSql += ctrl + " " + "    '" + m_material.toroku_program + "',";
            strSql += ctrl + " " + "    '" + m_material.koshin_datetime + "',";
            strSql += ctrl + " " + "    '" + m_material.koshin_user_id + "',";
            strSql += ctrl + " " + "    '" + m_material.koshin_program + "',";
            strSql += ctrl + " " + "    '" + m_material.kigyo_code + "',";
            strSql += ctrl + " " + "     " + m_material.invalid_flg + "  ,";
            strSql += ctrl + " " + "    '" + m_material.material_code + "',";
            strSql += ctrl + " " + "    '" + m_material.material_name + "',";
            strSql += ctrl + " " + "    '" + m_material.unit_kbn + "',";
            strSql += ctrl + " " + "    '" + m_material.type_name + "',";
            strSql += ctrl + " " + "    '" + m_material.kikaku_shiyo + "',";
            strSql += ctrl + " " + "    '" + m_material.biko + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi1 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi2 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi3 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi4 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi5 + "'";
            strSql += ctrl + " " + ")";

            #endregion

            // sqlの実行
            intRtn = clsSqlServer.ExeDatabaseUpdate(strSql);
            if (!(intRtn == SystemInfo.RtnStatus.OK))
            {
                return SystemInfo.RtnStatus.NG;
            }

            // 履歴に登録
            intRtn = Insert_m_material_history(clsSqlServer, m_material);
            if (!(intRtn == SystemInfo.RtnStatus.OK))
            {
                return SystemInfo.RtnStatus.NG;
            }

            return intRtn;
        }
        catch
        {
            return SystemInfo.RtnStatus.ER;
        }

    }

    /// <summary>
    /// マテリアルマスタ更新処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    /// <param name="m_material"></param>
    /// <returns></returns>
    public static int Update_m_material(SqlServer clsSqlServer, struct_m_material m_material)
    {

        string strSql;
        int intRtn;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "update m_material";
            strSql += ctrl + " " + "    set ";
            strSql += ctrl + " " + "    koshin_datetime = '" + m_material.koshin_datetime + "',";
            strSql += ctrl + " " + "    koshin_user_id  = '" + m_material.koshin_user_id  + "',";
            strSql += ctrl + " " + "    koshin_program  = '" + m_material.koshin_program  + "',";
            strSql += ctrl + " " + "    kigyo_code      = '" + m_material.kigyo_code      + "',";
            strSql += ctrl + " " + "    invalid_flg     =  " + m_material.invalid_flg     + " ,";
            strSql += ctrl + " " + "    material_code   = '" + m_material.material_code   + "',";
            strSql += ctrl + " " + "    material_name   = '" + m_material.material_name   + "',";
            strSql += ctrl + " " + "    unit_kbn        = '" + m_material.unit_kbn        + "',";
            strSql += ctrl + " " + "    type_name       = '" + m_material.type_name       + "',";
            strSql += ctrl + " " + "    kikaku_shiyo    = '" + m_material.kikaku_shiyo    + "',";
            strSql += ctrl + " " + "    biko            = '" + m_material.biko            + "',";
            strSql += ctrl + " " + "    yobi1           = '" + m_material.yobi1           + "',";
            strSql += ctrl + " " + "    yobi2           = '" + m_material.yobi2           + "',";
            strSql += ctrl + " " + "    yobi3           = '" + m_material.yobi3           + "',";
            strSql += ctrl + " " + "    yobi4           = '" + m_material.yobi4           + "',";
            strSql += ctrl + " " + "    yobi5           = '" + m_material.yobi5           + "'";
            strSql += ctrl + " " + "where 1 = 1";
            strSql += ctrl + " " + "and kigyo_code    = '" + m_material.kigyo_code + "'";
            strSql += ctrl + " " + "and material_code = '" + m_material.material_code + "'";

            #endregion

            // sqlの実行
            intRtn = clsSqlServer.ExeDatabaseUpdate(strSql);
            if (!(intRtn == SystemInfo.RtnStatus.OK))
            {
                return SystemInfo.RtnStatus.NG;
            }

            // 履歴に登録
            intRtn = Insert_m_material_history(clsSqlServer, m_material);
            if (!(intRtn == SystemInfo.RtnStatus.OK))
            {
                return SystemInfo.RtnStatus.NG;
            }

            return intRtn;
        }
        catch
        {
            return SystemInfo.RtnStatus.ER;
        }

    }

    /// <summary>
    /// マテリアルマスタ履歴登録処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    /// <param name="m_material"></param>
    /// <returns></returns>
    private static int Insert_m_material_history(SqlServer clsSqlServer, struct_m_material m_material)
    {

        string strSql;
        int intRtn;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "insert into m_material_history";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    toroku_datetime ,";
            strSql += ctrl + " " + "    toroku_user_id  ,";
            strSql += ctrl + " " + "    toroku_program  ,";
            strSql += ctrl + " " + "    koshin_datetime ,";
            strSql += ctrl + " " + "    koshin_user_id  ,";
            strSql += ctrl + " " + "    koshin_program  ,";
            strSql += ctrl + " " + "    kigyo_code      ,";
            strSql += ctrl + " " + "    invalid_flg     ,";
            strSql += ctrl + " " + "    material_code   ,";
            strSql += ctrl + " " + "    material_name   ,";
            strSql += ctrl + " " + "    unit_kbn       ,";
            strSql += ctrl + " " + "    type_name       ,";
            strSql += ctrl + " " + "    kikaku_shiyo    ,";
            strSql += ctrl + " " + "    biko            ,";
            strSql += ctrl + " " + "    yobi1           ,";
            strSql += ctrl + " " + "    yobi2           ,";
            strSql += ctrl + " " + "    yobi3           ,";
            strSql += ctrl + " " + "    yobi4           ,";
            strSql += ctrl + " " + "    yobi5           ";
            strSql += ctrl + " " + ")";
            strSql += ctrl + " " + "values";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    '" + m_material.toroku_datetime + "',";
            strSql += ctrl + " " + "    '" + m_material.toroku_user_id + "',";
            strSql += ctrl + " " + "    '" + m_material.toroku_program + "',";
            strSql += ctrl + " " + "    '" + m_material.koshin_datetime + "',";
            strSql += ctrl + " " + "    '" + m_material.koshin_user_id + "',";
            strSql += ctrl + " " + "    '" + m_material.koshin_program + "',";
            strSql += ctrl + " " + "    '" + m_material.kigyo_code + "',";
            strSql += ctrl + " " + "     " + m_material.invalid_flg + "  ,";
            strSql += ctrl + " " + "    '" + m_material.material_code + "',";
            strSql += ctrl + " " + "    '" + m_material.material_name + "',";
            strSql += ctrl + " " + "    '" + m_material.unit_kbn + "',";
            strSql += ctrl + " " + "    '" + m_material.type_name + "',";
            strSql += ctrl + " " + "    '" + m_material.kikaku_shiyo + "',";
            strSql += ctrl + " " + "    '" + m_material.biko + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi1 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi2 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi3 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi4 + "',";
            strSql += ctrl + " " + "    '" + m_material.yobi5 + "'";
            strSql += ctrl + " " + ")";

            #endregion

            // sqlの実行
            intRtn = clsSqlServer.ExeDatabaseUpdate(strSql);

            return intRtn;
        }
        catch
        {
            return SystemInfo.RtnStatus.ER;
        }

    }
    #endregion

    #region "m_kaisya"
    public struct struct_m_kaisya
    {
        public string toroku_datetime;
        public string toroku_user_id;
        public string toroku_program;
        public string koshin_datetime;
        public string koshin_user_id;
        public string koshin_program;
        public string kigyo_code;
        public int invalid_flg;
        public string kaisya_code;
        public string kaisya_name;
        public string kaisya_name_kana;
        public string kaisya_name_ryaku;
        public string address;
        public string postal_code;
        public string tel_no;
        public string fax_no;
        public string mail_address;

        public const int idx_toroku_datetime = 0;
        public const int idx_toroku_user_id = 1;
        public const int idx_toroku_program = 2;
        public const int idx_koshin_datetime = 3;
        public const int idx_koshin_user_id = 4;
        public const int idx_koshin_program = 5;
        public const int idx_kigyo_code = 6;
        public const int idx_invalid_flg = 7;
        public const int idx_kaisya_code = 8;
        public const int idx_kaisya_name = 9;
        public const int idx_kaisya_name_kana = 10;
        public const int idx_kaisya_name_ryaku = 11;
        public const int idx_address = 12;
        public const int idx_postal_code = 13;
        public const int idx_tel_no = 14;
        public const int idx_fax_no = 15;
        public const int idx_mail_address = 16;

    }

    /// <summary>
    /// 会社マスタ取得SQL作成処理
    /// </summary>
    /// <param material_name="clsSqlServer"></param>
    /// <param material_name="m_kaisya"></param>
    /// <param material_name="intCount"></param>
    /// <returns></returns>
    public static DataTable Get_m_kaisya(SqlServer clsSqlServer, struct_m_kaisya m_kaisya, int intCount = 9999)
    {

        string strSql;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "select top(" + intCount + ")";
            strSql += ctrl + " " + "    toroku_datetime,";
            strSql += ctrl + " " + "    toroku_user_id,";
            strSql += ctrl + " " + "    toroku_program,";
            strSql += ctrl + " " + "    koshin_datetime,";
            strSql += ctrl + " " + "    koshin_user_id,";
            strSql += ctrl + " " + "    koshin_program,";
            strSql += ctrl + " " + "    kigyo_code,";
            strSql += ctrl + " " + "    invalid_flg,";
            strSql += ctrl + " " + "    kaisya_code      ,";
            strSql += ctrl + " " + "    kaisya_name      ,";
            strSql += ctrl + " " + "    kaisya_name_kana ,";
            strSql += ctrl + " " + "    kaisya_name_ryaku,";
            strSql += ctrl + " " + "    address          ,";
            strSql += ctrl + " " + "    postal_code      ,";
            strSql += ctrl + " " + "    tel_no           ,";
            strSql += ctrl + " " + "    fax_no           ,";
            strSql += ctrl + " " + "    mail_address     ";
            strSql += ctrl + " " + "from m_kaisya";
            #region where 
            strSql += ctrl + " " + "where 1 = 1";
            if (!(m_kaisya.toroku_datetime == "" || m_kaisya.toroku_datetime is null))
            {
                strSql += ctrl + " " + "and toroku_datetime = '" + m_kaisya.toroku_datetime + "'";
            }
            if (!(m_kaisya.toroku_user_id == "" || m_kaisya.toroku_user_id is null))
            {
                strSql += ctrl + " " + "and toroku_user_id = '" + m_kaisya.toroku_user_id + "'";
            }
            if (!(m_kaisya.toroku_program == "" || m_kaisya.toroku_program is null))
            {
                strSql += ctrl + " " + "and toroku_program = '" + m_kaisya.toroku_program + "'";
            }
            if (!(m_kaisya.koshin_datetime == "" || m_kaisya.toroku_datetime is null))
            {
                strSql += ctrl + " " + "and koshin_datetime = '" + m_kaisya.koshin_datetime + "'";
            }
            if (!(m_kaisya.koshin_user_id == "" || m_kaisya.koshin_user_id is null))
            {
                strSql += ctrl + " " + "and koshin_user_id = '" + m_kaisya.koshin_user_id + "'";
            }
            if (!(m_kaisya.koshin_program == "" || m_kaisya.koshin_program is null))
            {
                strSql += ctrl + " " + "and koshin_program = '" + m_kaisya.koshin_program + "'";
            }
            if (!(m_kaisya.kigyo_code == "" || m_kaisya.kigyo_code is null))
            {
                strSql += ctrl + " " + "and kigyo_code = '" + m_kaisya.kigyo_code + "'";
            }
            if (!(m_kaisya.kaisya_code == "" || m_kaisya.kaisya_code is null))
            {
                strSql += ctrl + " " + "and kaisya_code like '" + m_kaisya.kaisya_code + "'";
            }
            if (!(m_kaisya.kaisya_name == "" || m_kaisya.kaisya_name is null))
            {
                strSql += ctrl + " " + "and kaisya_name like '" + m_kaisya.kaisya_name + "'";
            }
            if (!(m_kaisya.kaisya_name_kana == "" || m_kaisya.kaisya_name_kana is null))
            {
                strSql += ctrl + " " + "and kaisya_name_kana like '" + m_kaisya.kaisya_name_kana + "'";
            }
            if (!(m_kaisya.kaisya_name_ryaku == "" || m_kaisya.kaisya_name_ryaku is null))
            {
                strSql += ctrl + " " + "and kaisya_name_ryaku like '" + m_kaisya.kaisya_name_ryaku + "'";
            }
            if (!(m_kaisya.address == "" || m_kaisya.address is null))
            {
                strSql += ctrl + " " + "and address = '" + m_kaisya.address + "'";
            }
            if (!(m_kaisya.postal_code == "" || m_kaisya.postal_code is null))
            {
                strSql += ctrl + " " + "and postal_code = '" + m_kaisya.postal_code + "'";
            }
            if (!(m_kaisya.tel_no == "" || m_kaisya.tel_no is null))
            {
                strSql += ctrl + " " + "and tel_no = '" + m_kaisya.tel_no + "'";
            }
            if (!(m_kaisya.fax_no == "" || m_kaisya.fax_no is null))
            {
                strSql += ctrl + " " + "and fax_no = '" + m_kaisya.fax_no + "'";
            }
            if (!(m_kaisya.mail_address == "" || m_kaisya.mail_address is null))
            {
                strSql += ctrl + " " + "and mail_address = '" + m_kaisya.mail_address + "'";
            }

            // 無効フラグは「有効のみ」または「すべて」とする
            if (m_kaisya.invalid_flg == 0)
            {
                strSql += ctrl + " " + "and invalid_flg = 0";
            }

            #endregion

            #endregion

            // sqlの実行
            return clsSqlServer.ExeSQL_Select(strSql);

        }
        catch
        {
            return new DataTable();
        }

    }

    /// <summary>
    /// 会社マスタ登録エラーチェック
    /// </summary>
    /// <param name="errMsg"></param>
    /// <param name="clsSqlServer"></param>
    /// <param name="m_kaisya"></param>
    /// <returns></returns>
    public static bool Chk_m_kaisya(string errMsg, SqlServer clsSqlServer, struct_m_kaisya m_kaisya)
    {
        // テーブル定義を取得
        DataTable v_Teigi = Get_v_Teigi(clsSqlServer, "m_kaisya");

        // 会社コード
        DataRow dRows = v_Teigi.Select("ColumnName = 'kaisya_code'")[0];
        int Length_KaisyaCode = System.Text.Encoding.GetEncoding("UTF-8").GetByteCount(m_kaisya.kaisya_code);
        if (!(int.Parse(dRows[struct_v_Teigi.idx_MaxInteger].ToString()) >= Length_KaisyaCode))
        {
            errMsg = "会社コードは" + int.Parse(dRows[struct_v_Teigi.idx_MaxInteger].ToString()) +
                     "文字以内で入力してください。";
            return false;
        }

        // 入力チェック問題なし
        return true;
    }

    /// <summary>
    /// 会社マスタ新規登録処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    /// <param name="m_kaisya"></param>
    /// <returns></returns>
    public static int Insert_m_kaisya(SqlServer clsSqlServer, struct_m_kaisya m_kaisya)
    {

        string strSql;
        int intRtn;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "insert into m_kaisya";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    toroku_datetime ,";
            strSql += ctrl + " " + "    toroku_user_id  ,";
            strSql += ctrl + " " + "    toroku_program  ,";
            strSql += ctrl + " " + "    koshin_datetime ,";
            strSql += ctrl + " " + "    koshin_user_id  ,";
            strSql += ctrl + " " + "    koshin_program  ,";
            strSql += ctrl + " " + "    kigyo_code      ,";
            strSql += ctrl + " " + "    invalid_flg     ,";
            strSql += ctrl + " " + "    kaisya_code       ,";
            strSql += ctrl + " " + "    kaisya_name       ,";
            strSql += ctrl + " " + "    kaisya_name_kana  ,";
            strSql += ctrl + " " + "    kaisya_name_ryaku ,";
            strSql += ctrl + " " + "    address           ,";
            strSql += ctrl + " " + "    postal_code       ,";
            strSql += ctrl + " " + "    tel_no            ,";
            strSql += ctrl + " " + "    fax_no            ,";
            strSql += ctrl + " " + "    mail_address       ";
            strSql += ctrl + " " + ")";
            strSql += ctrl + " " + "values";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    '" + m_kaisya.toroku_datetime + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.toroku_user_id + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.toroku_program + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.koshin_datetime + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.koshin_user_id + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.koshin_program + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kigyo_code + "',";
            strSql += ctrl + " " + "     " + m_kaisya.invalid_flg + "  ,";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_code + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_name       + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_name_kana  + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_name_ryaku + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.address           + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.postal_code       + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.tel_no            + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.fax_no            + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.mail_address      + "'";
            strSql += ctrl + " " + ")";

            #endregion

            // sqlの実行
            intRtn = clsSqlServer.ExeDatabaseUpdate(strSql);
            if (!(intRtn == SystemInfo.RtnStatus.OK))
            {
                return SystemInfo.RtnStatus.NG;
            }

            // 履歴に登録
            intRtn = Insert_m_kaisya_history(clsSqlServer, m_kaisya);

            return intRtn;
        }
        catch
        {
            return SystemInfo.RtnStatus.ER;
        }

    }

    /// <summary>
    /// 会社マスタ更新処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    /// <param name="m_kaisya"></param>
    /// <returns></returns>
    public static int Update_m_kaisya(SqlServer clsSqlServer, struct_m_kaisya m_kaisya)
    {

        string strSql;
        int intRtn;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "update m_kaisya";
            strSql += ctrl + " " + "    set ";
            strSql += ctrl + " " + "    koshin_datetime = '" + m_kaisya.koshin_datetime + "',";
            strSql += ctrl + " " + "    koshin_user_id  = '" + m_kaisya.koshin_user_id + "',";
            strSql += ctrl + " " + "    koshin_program  = '" + m_kaisya.koshin_program + "',";
            strSql += ctrl + " " + "    kigyo_code      = '" + m_kaisya.kigyo_code + "',";
            strSql += ctrl + " " + "    invalid_flg     =  " + m_kaisya.invalid_flg + " ,";
            strSql += ctrl + " " + "    kaisya_code            = '" + m_kaisya.kaisya_code       + "',";
            strSql += ctrl + " " + "    kaisya_name            = '" + m_kaisya.kaisya_name       + "',";
            strSql += ctrl + " " + "    kaisya_name_kana       = '" + m_kaisya.kaisya_name_kana  + "',";
            strSql += ctrl + " " + "    kaisya_name_ryaku      = '" + m_kaisya.kaisya_name_ryaku + "',";
            strSql += ctrl + " " + "    address                = '" + m_kaisya.address           + "',";
            strSql += ctrl + " " + "    postal_code            = '" + m_kaisya.postal_code       + "',";
            strSql += ctrl + " " + "    tel_no                 = '" + m_kaisya.tel_no            + "',";
            strSql += ctrl + " " + "    fax_no                 = '" + m_kaisya.fax_no            + "',";
            strSql += ctrl + " " + "    mail_address           = '" + m_kaisya.mail_address      + "'";
            strSql += ctrl + " " + "where 1 = 1";
            strSql += ctrl + " " + "and kigyo_code    = '" + m_kaisya.kigyo_code + "'";
            strSql += ctrl + " " + "and kaisya_code = '" + m_kaisya.kaisya_code + "'";

            #endregion

            // sqlの実行
            intRtn = clsSqlServer.ExeDatabaseUpdate(strSql);
            if (!(intRtn == SystemInfo.RtnStatus.OK))
            {
                return SystemInfo.RtnStatus.NG;
            }

            // 履歴に登録
            intRtn = Insert_m_kaisya_history(clsSqlServer, m_kaisya);
            if (!(intRtn == SystemInfo.RtnStatus.OK))
            {
                return SystemInfo.RtnStatus.NG;
            }

            return intRtn;
        }
        catch
        {
            return SystemInfo.RtnStatus.ER;
        }

    }

    /// <summary>
    /// 会社マスタ履歴登録処理
    /// </summary>
    /// <param name="clsSqlServer"></param>
    /// <param name="Data_m_material"></param>
    /// <returns></returns>
    private static int Insert_m_kaisya_history(SqlServer clsSqlServer, struct_m_kaisya m_kaisya)
    {

        string strSql;
        int intRtn;
        try
        {
            #region SQL select
            strSql = "";
            strSql += ctrl + " " + "insert into m_kaisya_history";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    toroku_datetime ,";
            strSql += ctrl + " " + "    toroku_user_id  ,";
            strSql += ctrl + " " + "    toroku_program  ,";
            strSql += ctrl + " " + "    koshin_datetime ,";
            strSql += ctrl + " " + "    koshin_user_id  ,";
            strSql += ctrl + " " + "    koshin_program  ,";
            strSql += ctrl + " " + "    kigyo_code      ,";
            strSql += ctrl + " " + "    invalid_flg     ,";
            strSql += ctrl + " " + "    kaisya_code       ,";
            strSql += ctrl + " " + "    kaisya_name       ,";
            strSql += ctrl + " " + "    kaisya_name_kana  ,";
            strSql += ctrl + " " + "    kaisya_name_ryaku ,";
            strSql += ctrl + " " + "    address           ,";
            strSql += ctrl + " " + "    postal_code       ,";
            strSql += ctrl + " " + "    tel_no            ,";
            strSql += ctrl + " " + "    fax_no            ,";
            strSql += ctrl + " " + "    mail_address       ";
            strSql += ctrl + " " + ")";
            strSql += ctrl + " " + "values";
            strSql += ctrl + " " + "(";
            strSql += ctrl + " " + "    '" + m_kaisya.toroku_datetime  + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.toroku_user_id   + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.toroku_program   + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.koshin_datetime  + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.koshin_user_id   + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.koshin_program   + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kigyo_code       + "',";
            strSql += ctrl + " " + "     " + m_kaisya.invalid_flg      + " ,";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_code      + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_name      + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_name_kana + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.kaisya_name_ryaku + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.address + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.postal_code + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.tel_no + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.fax_no + "',";
            strSql += ctrl + " " + "    '" + m_kaisya.mail_address + "' ";
            strSql += ctrl + " " + ")";

            #endregion

            // sqlの実行
            intRtn = clsSqlServer.ExeDatabaseUpdate(strSql);

            return intRtn;
        }
        catch
        {
            return SystemInfo.RtnStatus.ER;
        }

    }
    #endregion

    #endregion
}
