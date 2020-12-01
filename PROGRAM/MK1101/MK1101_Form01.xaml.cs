using Prism.Services.Dialogs;
using SQL_Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MK1101
{
    // データバインディング用クラス
    #region ViewModel

    /// <summary>
    /// 画面データバインディング用クラス
    /// ※ViewModel
    /// </summary>
    class BindingData : INotifyPropertyChanged
    {

        /// <summary>
        /// プロパティ変更イベントの宣言
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティ変更通知処理
        /// </summary>
        /// <param material_name="name"></param>
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #region "メッセージ"
        private string strAppMessage;
        /// <summary>
        /// メッセージ
        /// </summary>
        public string AppMessage
        {
            get { return strAppMessage; }
            set
            {
                strAppMessage = value;
                OnPropertyChanged(nameof(AppMessage));
            }
        }
        #endregion

        #region "検索　物コード"
        private string strSearchMaterialCode;
        /// <summary>
        /// 物コード
        /// </summary>
        public string SearchMaterialCode
        {
            get { return strSearchMaterialCode; }
            set
            {
                strSearchMaterialCode = value;
                OnPropertyChanged(nameof(SearchMaterialCode));
            }
        }
        #endregion

        #region "検索　品名"
        private string strSearchMaterialName;
        /// <summary>
        /// 物コード　名称
        /// </summary>
        public string SearchMaterialName
        {
            get { return strSearchMaterialName; }
            set
            {
                strSearchMaterialName = value;
                OnPropertyChanged(nameof(SearchMaterialName));
            }
        }
        #endregion

        #region "検索　無効"
        private bool booSearchInvalidFlg;
        /// <summary>
        /// 無効フラグ
        /// </summary>
        public bool SearchInvalidFlg
        {
            get { return booSearchInvalidFlg; }
            set
            {
                booSearchInvalidFlg = value;
                OnPropertyChanged(nameof(SearchInvalidFlg));
            }
        }
        #endregion

        #region "検索結果テーブル"
        private DataTable DatMaterialInfo;
        /// <summary>
        /// 新着情報
        /// </summary>
        public DataTable MaterialInfo
        {
            get { return DatMaterialInfo; }
            set
            {
                DatMaterialInfo = value;
                OnPropertyChanged(nameof(MaterialInfo));
            }
        }
        #endregion

        #region "詳細　無効"
        private bool booInvalidFlg;
        /// <summary>
        /// 無効フラグ
        /// </summary>
        public bool InvalidFlg
        {
            get { return booInvalidFlg; }
            set
            {
                booInvalidFlg = value;
                OnPropertyChanged(nameof(InvalidFlg));
            }
        }
        #endregion

        #region "詳細　物コード"
        private string strMaterialCode;
        /// <summary>
        /// 物コード
        /// </summary>
        public string MaterialCode
        {
            get { return strMaterialCode; }
            set
            {
                strMaterialCode = value;
                OnPropertyChanged(nameof(MaterialCode));
            }
        }
        #endregion

        #region "詳細　品名"
        private string strMaterialName;
        /// <summary>
        /// 品名
        /// </summary>
        public string MaterialName
        {
            get { return strMaterialName; }
            set
            {
                strMaterialName = value;
                OnPropertyChanged(nameof(MaterialName));
            }
        }
        #endregion

        #region "詳細　単位"

        public DataTable DatUnitKbnInfo;
        /// <summary>
        /// 単位コンボボックス
        /// </summary>
        public DataTable UnitKbnInfo
        {
            get { return DatUnitKbnInfo; }
            set
            {
                DatUnitKbnInfo = value;
                OnPropertyChanged(nameof(UnitKbnInfo));
            }
        }

        private int intUnitKbnInfo_SelectedIndex;
        /// <summary>
        /// 単位コンボボックス選択行
        /// </summary>
        public int UnitKbnInfo_Selectedindex
        {
            get { return intUnitKbnInfo_SelectedIndex; }
            set
            {
                intUnitKbnInfo_SelectedIndex = value;

                // ここでコード名称を取得する処理を挟む
                OnPropertyChanged(nameof(UnitKbnInfo_Selectedindex));

                if (intUnitKbnInfo_SelectedIndex < 0)
                {
                    // 区分をセット
                    UnitKbn = "";
                }
                else
                {
                    // 区分をセット
                    UnitKbn = UnitKbnInfo.Rows[UnitKbnInfo_Selectedindex].ItemArray[Com02.struct_m_kbn.idx_kbn].ToString();
                }
            }
        }
        private String strUnitKbn;
        /// <summary>
        /// 単位コンボボックス選択行
        /// </summary>
        public String UnitKbn
        {
            get { return strUnitKbn; }
            set
            {
                strUnitKbn = value;

            }
        }

        #endregion

        #region "詳細　型名"
        private string strTypeName;
        /// <summary>
        /// 型名
        /// </summary>
        public string TypeName
        {
            get { return strTypeName; }
            set
            {
                strTypeName = value;
                OnPropertyChanged(nameof(TypeName));
            }
        }
        #endregion

        #region "詳細　規格・仕様"
        private string strKikakuShiyo;
        /// <summary>
        /// 規格・仕様
        /// </summary>
        public string KikakuShiyo
        {
            get { return strKikakuShiyo; }
            set
            {
                strKikakuShiyo = value;
                OnPropertyChanged(nameof(KikakuShiyo));
            }
        }
        #endregion

        #region "詳細　備考"
        private string strBiko;
        /// <summary>
        /// 備考
        /// </summary>
        public string Biko
        {
            get { return strBiko; }
            set
            {
                strBiko = value;
                OnPropertyChanged(nameof(Biko));
            }
        }
        #endregion

        public BindingData()
        {
            AppMessage = "";

            // 検索
            SearchMaterialCode = "";
            SearchMaterialName = "";
            MaterialInfo = new DataTable();

            // 詳細
            MaterialCode = "";
            MaterialName = "";
            UnitKbnInfo = new DataTable();
            UnitKbn = "";
            intUnitKbnInfo_SelectedIndex = -1;
            TypeName = "";
            KikakuShiyo = "";
            Biko = "";
        }

    }

    #endregion

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Form01 : Window
    {

        // データバインディングクラスの宣言
        private BindingData clsBindData = new BindingData();
        private string MaterialCode_old = "";

        #region "初期処理・初期化処理"
        public Form01()
        {
            InitializeComponent();

            // ソリューション共通初期処理
            Com01.SystemInit();

            // プロジェクト毎の初期処理
            Set_ProjectInit(clsBindData);

            //// 画面初期化処理
            this.DataContext = clsBindData;
        }

        private void Set_ProjectInit(BindingData clsBindData)
        {

            // DB接続
            SqlServer clsSqlServer = new SqlServer(Com01.clsSystemInfo.SystemDatabase);
            clsSqlServer.Connect();

            Com02.struct_m_kbn m_kbn_UnitKbn = new Com02.struct_m_kbn();
            m_kbn_UnitKbn.kigyo_code = Com01.clsSystemInfo.ComLineArgs.kigyo_code;
            m_kbn_UnitKbn.data_code = SystemInfo.DataCode.unit_code;

            // 区分マスタを取得
            clsBindData.UnitKbnInfo = Com02.Get_v_kbn(clsSqlServer, m_kbn_UnitKbn);



        }
        #endregion

        #region "ボタンクリックイベント"
        /// <summary>
        /// 検索処理実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // DB接続
                SqlServer clsSqlServer = new SqlServer(Com01.clsSystemInfo.SystemDatabase);
                clsSqlServer.Connect();

                // マテリアルマスタ検索(共通)
                Com02.struct_m_material m_material = new Com02.struct_m_material();
                m_material.kigyo_code = Com01.clsSystemInfo.ComLineArgs.kigyo_code;
                m_material.material_code = clsBindData.SearchMaterialCode;
                m_material.material_name = clsBindData.SearchMaterialName;
                if (clsBindData.SearchInvalidFlg == true)
                {
                    m_material.invalid_flg = 1;
                }
                clsBindData.MaterialInfo = Com02.Get_m_material(clsSqlServer, m_material, 100);

                // 画面更新
                this.DataContext = clsBindData;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 検索クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchClear_Click(object sender, RoutedEventArgs e)
        {
            clsBindData.SearchMaterialCode = "";
            clsBindData.SearchMaterialName = "";
            clsBindData.MaterialInfo = new DataTable();
        }

        /// <summary>
        /// 詳細クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyosaiClear_Click(object sender, RoutedEventArgs e)
        {
            // 選択キー値をクリア
            MaterialCode_old = "";

            clsBindData.MaterialCode = "";
            clsBindData.MaterialName = "";
            clsBindData.UnitKbnInfo_Selectedindex = -1;
            clsBindData.UnitKbn = "";
            clsBindData.TypeName = "";
            clsBindData.Biko = "";
        }

        /// <summary>
        /// 新規登録処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string strMsg;
            string strErrMsg;
            string strProcName;

            strMsg = "";
            strErrMsg = "";
            try
            {
                // DB接続
                SqlServer clsSqlServer = new SqlServer(Com01.clsSystemInfo.SystemDatabase);
                clsSqlServer.Connect();

                // 登録・更新用の構造体へ値をセットする
                Com02.struct_m_material m_material;
                m_material = Set_EntryData(clsSqlServer, clsBindData);

                // 新規/更新の文言を取得
                if (m_material.toroku_datetime == m_material.koshin_datetime)
                {
                    strProcName = "新規登録";
                }
                else
                {
                    strProcName = "更新";
                }

                // エラーチェック


                // 確認
                MessageBoxResult msgResult = MessageBox.Show(strProcName + "処理を行います。" + Environment.NewLine
                                                                            + "よろしいですか？"
                                                                            , "確認：" + strProcName
                                                                            , MessageBoxButton.YesNo);
                if (!(msgResult == MessageBoxResult.Yes))
                {
                    strMsg = strProcName + "処理を中止しました。";
                    return;
                }

                // 新規/更新を実行
                int result = SystemInfo.RtnStatus.ER;
                if (m_material.toroku_datetime == m_material.koshin_datetime)
                {
                    // 新規
                    result = Com02.Insert_m_material(clsSqlServer, m_material);
                }
                else
                {
                    // 更新
                    result = Com02.Update_m_material(clsSqlServer, m_material);
                }

                // 戻り値から表示するメッセージを切り替える
                switch (result)
                {
                    case SystemInfo.RtnStatus.ER:
                        strMsg = strProcName + "処理に失敗しました。";
                        break;

                    case SystemInfo.RtnStatus.NG:

                        strMsg = strProcName + "処理に失敗しました。";
                        if (!(clsSqlServer.ErrCode == "0"))
                        {
                            strMsg += "管理者に右記コードと共に御連絡ください。[エラーコード：" + clsSqlServer.ErrCode + "]";
                        }
                        break;

                    default:
                        // 再検索処理を行う
                        Search_Click(BtnF01, new RoutedEventArgs());
                        strMsg = strProcName + "処理が完了しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                strMsg = "例外が発生しました。";
                strErrMsg = ex.Message;
            }
            finally
            {
                clsBindData.AppMessage = Com01.GetAppMessage(MethodBase.GetCurrentMethod().Name, strMsg, strErrMsg);
                this.DataContext = clsBindData;
            }
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Me_KeyUp(object sender, KeyEventArgs e)
        {

            // 押されたファンクションキー対応ボタンが対話可能かつ表示している場合、クリックイベントを呼ぶ
            switch (e.Key.ToString())
            {
                case "F1":

                    if (BtnF01.IsEnabled == true && BtnF01.IsVisible == true)
                    {
                        Search_Click(BtnF01, new RoutedEventArgs());
                    }
                    break;

                case "F2":

                    if (BtnF02.IsEnabled == true && BtnF02.IsVisible == true)
                    {
                        SearchClear_Click(BtnF02, new RoutedEventArgs());
                    }
                    break;

                case "F3":

                    if (BtnF03.IsEnabled == true && BtnF03.IsVisible == true)
                    {
                        SyosaiClear_Click(BtnF03, new RoutedEventArgs());
                    }
                    break;

                case "F5":

                    if (BtnF05.IsEnabled == true && BtnF05.IsVisible == true)
                    {
                        Save_Click(BtnF05, new RoutedEventArgs());
                    }
                    break;

                case "F11":

                    if (BtnF11.IsEnabled == true && BtnF11.IsVisible == true)
                    {
                        //Search_Click(BtnF11, new RoutedEventArgs());
                    }
                    break;

                case "F12":

                    if (BtnF12.IsEnabled == true && BtnF12.IsVisible == true)
                    {
                        End_Click(BtnF12, new RoutedEventArgs());
                    }
                    break;

                default:

                    break;
            }


        }


        #region "検索結果一覧イベント"
        /// <summary>
        /// 検索結果ダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialInfo_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            // イベント発生コントロール
            DataGrid dg = sender as DataGrid;

            if (dg.SelectedItem == null)
            {
                return;
            }

            // 検索のキーとなるコードを取得
            string strSelectMaterialCode =
                    clsBindData.MaterialInfo.Rows[dg.SelectedIndex].ItemArray[Com02.struct_m_material.idx_material_code].ToString();

            // 変更データの登録・変更破棄の確認
            bool booCheckMitoroku = Chk_SyosaiChange(clsBindData, MaterialCode_old);
            if (booCheckMitoroku == true)
            {
                MessageBoxResult result = MessageBox.Show("登録・更新前です。" + Environment.NewLine + "破棄してもよろしいでしょうか？", "", MessageBoxButton.YesNo);
                if (!(result == MessageBoxResult.Yes))
                {
                    return;
                }
            }

            // 選択内容を詳細に反映
            Set_SyosaiInfo(clsBindData, strSelectMaterialCode, ref MaterialCode_old);

            // 反映
            this.DataContext = clsBindData;
        }

        #endregion

        /// <summary>
        /// 引数のデータテーブルからマテリアルコードが一致する値を詳細にセットする。
        /// </summary>
        /// <param name="bindingData"></param>
        /// <param name="materialCode"></param>
        private void Set_SyosaiInfo(BindingData bindingData, string materialCode, ref string materialCode_old)
        {
            // Selectメソッドを使ってデータを抽出
            DataRow[] dRowsMaterialCode = bindingData.MaterialInfo.Select("material_code = '" + materialCode + "'");
            if (dRowsMaterialCode == null || dRowsMaterialCode.Length > 1)
            {
                // なぜこうなるのか
                return;
            }

            // バインド用プロパティにセット
            bindingData.MaterialCode = dRowsMaterialCode[0].ItemArray[Com02.struct_m_material.idx_material_code].ToString();
            bindingData.MaterialName = dRowsMaterialCode[0].ItemArray[Com02.struct_m_material.idx_material_name].ToString();
            bindingData.TypeName = dRowsMaterialCode[0].ItemArray[Com02.struct_m_material.idx_type_name].ToString();
            bindingData.KikakuShiyo = dRowsMaterialCode[0].ItemArray[Com02.struct_m_material.idx_kikaku_shiyo].ToString();
            bindingData.Biko = dRowsMaterialCode[0].ItemArray[Com02.struct_m_material.idx_biko].ToString();

            // 単位コードの何行目かを取得
            string strUnitKbn = dRowsMaterialCode[0].ItemArray[Com02.struct_m_material.idx_unit_kbn].ToString();
            for (int idx = 0; idx <= bindingData.UnitKbnInfo.Rows.Count - 1; idx += 1)
            {
                if (strUnitKbn == bindingData.UnitKbnInfo.Rows[idx].ItemArray[Com02.struct_m_kbn.idx_kbn].ToString())
                {
                    // 行を選択
                    bindingData.UnitKbnInfo_Selectedindex = idx;
                }
            }

            // 無効フラグ
            if (dRowsMaterialCode[0].ItemArray[Com02.struct_m_material.idx_invalid_flg].ToString() == "1")
            {
                bindingData.InvalidFlg = true;
            }
            else
            {
                bindingData.InvalidFlg = false;
            }

            // キーの旧情報として保持
            materialCode_old = bindingData.MaterialCode;
            return;
        }

        /// <summary>
        /// 詳細情報変更チェック処理
        /// </summary>
        /// <param name="bindingData"></param>
        /// <param name="strMaterialCode_old"></param>
        /// <returns></returns>
        private bool Chk_SyosaiChange(BindingData bindingData, string strMaterialCode_old)
        {
            if (strMaterialCode_old == "")
            {
                // 旧情報無し
                return false;
            }

            // キー項目を確認
            if (!(bindingData.MaterialCode.Equals(strMaterialCode_old)))
            {
                return true;
            }

            // キー項目以外でバインド元データと差異があるか確認
            DataRow dRows = bindingData.MaterialInfo.Select("material_code = '" + bindingData.MaterialCode + "'")[0];

            if (!(dRows[Com02.struct_m_material.idx_material_name].ToString() == bindingData.MaterialName))
            {
                return true;
            }
            if (!(dRows[Com02.struct_m_material.idx_unit_kbn].ToString() == bindingData.UnitKbn))
            {
                return true;
            }
            if (!(dRows[Com02.struct_m_material.idx_type_name].ToString() == bindingData.TypeName))
            {
                return true;
            }
            if (!(dRows[Com02.struct_m_material.idx_kikaku_shiyo].ToString() == bindingData.KikakuShiyo))
            {
                return true;
            }
            if (!(dRows[Com02.struct_m_material.idx_biko].ToString() == bindingData.Biko))
            {
                return true;
            }

            // 変更なし
            return false;
        }

        /// <summary>
        /// マテリアルマスタ登録データ設定処理
        /// </summary>
        /// <param name="clsSqlServer"></param>
        /// <param name="bindingData"></param>
        /// <returns></returns>
        private Com02.struct_m_material Set_EntryData(SqlServer clsSqlServer, BindingData bindingData)
        {

            // キーを条件に最新データを取得
            Com02.struct_m_material m_material = new Com02.struct_m_material();
            m_material.kigyo_code = Com01.clsSystemInfo.ComLineArgs.kigyo_code;
            m_material.material_code = bindingData.MaterialCode;
            m_material.invalid_flg = 1; // 削除も含めて検索
            DataTable dTable = Com02.Get_m_material(clsSqlServer, m_material, 1);

            // システム日時を取得
            Com01.Set_DateTime(clsSqlServer);

            // 更新日時をセット
            m_material.koshin_datetime = Com01.clsSystemInfo.dtNow.ToString();
            m_material.koshin_user_id = Com01.clsSystemInfo.ComLineArgs.user_id;
            m_material.koshin_program = Com01.clsSystemInfo.strExeName;

            // 検索結果
            if (dTable == null || dTable.Rows.Count == 0)
            {
                // 新規登録日時
                m_material.toroku_datetime = m_material.koshin_datetime;
                m_material.toroku_user_id = m_material.koshin_user_id;
                m_material.toroku_program = m_material.koshin_program;

                // 空の場合は規定値を
                m_material.invalid_flg = 0;
            }
            else
            {

                DataRow dRow = dTable.Rows[0];

                // 取得内容を構造体へ
                m_material.toroku_datetime = dRow[Com02.struct_m_material.idx_toroku_datetime].ToString();
                m_material.toroku_user_id = dRow[Com02.struct_m_material.idx_toroku_user_id].ToString();
                m_material.toroku_program = dRow[Com02.struct_m_material.idx_toroku_program].ToString();
                m_material.kigyo_code = dRow[Com02.struct_m_material.idx_kigyo_code].ToString();
                m_material.material_code = dRow[Com02.struct_m_material.idx_material_code].ToString();
                m_material.material_name = dRow[Com02.struct_m_material.idx_material_name].ToString();
                m_material.unit_kbn = dRow[Com02.struct_m_material.idx_unit_kbn].ToString();
                m_material.type_name = dRow[Com02.struct_m_material.idx_type_name].ToString();
                m_material.kikaku_shiyo = dRow[Com02.struct_m_material.idx_kikaku_shiyo].ToString();
                m_material.biko = dRow[Com02.struct_m_material.idx_biko].ToString();
                m_material.yobi1 = dRow[Com02.struct_m_material.idx_yobi1].ToString();
                m_material.yobi2 = dRow[Com02.struct_m_material.idx_yobi2].ToString();
                m_material.yobi3 = dRow[Com02.struct_m_material.idx_yobi3].ToString();
                m_material.yobi4 = dRow[Com02.struct_m_material.idx_yobi4].ToString();
                m_material.yobi5 = dRow[Com02.struct_m_material.idx_yobi5].ToString();
                m_material.invalid_flg = int.Parse(dRow[Com02.struct_m_material.idx_invalid_flg].ToString());
            }

            // これに対して画面内容を上書く
            if (bindingData.InvalidFlg == true)
            {
                m_material.invalid_flg = 1;
            }
            else
            {
                m_material.invalid_flg = 0;
            }
            m_material.material_name = bindingData.MaterialName;
            m_material.unit_kbn = bindingData.UnitKbn;
            m_material.type_name = bindingData.TypeName;
            m_material.kikaku_shiyo = bindingData.KikakuShiyo;
            m_material.biko = bindingData.Biko;

            return m_material;
        }

    }
}
