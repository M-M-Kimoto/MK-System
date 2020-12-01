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

namespace MK1102
{
    #region　"データバインディング"
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

        #region "検索　会社コード"
        private string strSearchKaisyaCode;
        /// <summary>
        /// 会社コード
        /// </summary>
        public string SearchKaisyaCode
        {
            get { return strSearchKaisyaCode; }
            set
            {
                strSearchKaisyaCode = value;
                OnPropertyChanged(nameof(SearchKaisyaCode));
            }
        }
        #endregion

        #region "検索　会社名（略称）"
        private string strSearchKaisyName_Ryaku;
        /// <summary>
        /// 会社名（略称）
        /// </summary>
        public string SearchKaisyaName_Ryaku
        {
            get { return strSearchKaisyName_Ryaku; }
            set
            {
                strSearchKaisyName_Ryaku = value;
                OnPropertyChanged(nameof(SearchKaisyaName_Ryaku));
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
        private DataTable DatKaisyaInfo;
        /// <summary>
        /// 新着情報
        /// </summary>
        public DataTable KaisyaInfo
        {
            get { return DatKaisyaInfo; }
            set
            {
                DatKaisyaInfo = value;
                OnPropertyChanged(nameof(KaisyaInfo));
            }
        }
        #endregion

        #region "詳細　無効"
        private CheckItem CI_InvalidFlg;
        /// <summary>
        /// 無効フラグ
        /// </summary>
        public CheckItem InvalidFlg
        {
            get { return CI_InvalidFlg; }
            set
            {
                CI_InvalidFlg = value;
                OnPropertyChanged(nameof(InvalidFlg));
            }
        }
        #endregion

        #region "詳細　会社コード"
        private TextItem TI_KaisyaCode;
        /// <summary>
        /// 会社コード
        /// </summary>
        public TextItem KaisyaCode
        {
            get { return TI_KaisyaCode; }
            set
            {
                TI_KaisyaCode = value;
                OnPropertyChanged(nameof(KaisyaCode));
            }
        }
        #endregion

        #region "詳細　会社名"
        private TextItem TI_KaisyaName;
        /// <summary>
        /// 会社名
        /// </summary>
        public TextItem KaisyaName
        {
            get { return TI_KaisyaName; }
            set
            {
                TI_KaisyaName = value;
                OnPropertyChanged(nameof(KaisyaName));
            }
        }
        #endregion

        #region "詳細　会社名カナ"
        private TextItem TI_KaisyaName_Kana;
        /// <summary>
        /// 会社名カナ
        /// </summary>
        public TextItem KaisyaName_Kana
        {
            get { return TI_KaisyaName_Kana; }
            set
            {
                TI_KaisyaName_Kana = value;
                OnPropertyChanged(nameof(KaisyaName_Kana));
            }
        }
        #endregion

        #region "詳細　会社名略称"
        private TextItem TI_KaisyaName_Ryaku;
        /// <summary>
        /// 会社名略称
        /// </summary>
        public TextItem KaisyaName_Ryaku
        {
            get { return TI_KaisyaName_Ryaku; }
            set
            {
                TI_KaisyaName_Ryaku = value;
                OnPropertyChanged(nameof(KaisyaName_Ryaku));
            }
        }
        #endregion

        #region "詳細　郵便番号"
        private TextItem TI_PostalCode_1;
        /// <summary>
        /// 郵便番号 頭3桁
        /// </summary>
        public TextItem PostalCode_1
        {
            get { return TI_PostalCode_1; }
            set
            {
                TI_PostalCode_1 = value;
                OnPropertyChanged(nameof(PostalCode_1));

                if (PostalCode_1.errVisibility == "Visible")
                {
                    PostalCode_2.errVisibility = "'Hidden";
                }

            }
        }

        private TextItem TI_PostalCode_2;
        /// <summary>
        /// 郵便番号　末4桁
        /// </summary>
        public TextItem PostalCode_2
        {
            get { return TI_PostalCode_2; }
            set
            {
                TI_PostalCode_2 = value;

                if (PostalCode_1.errVisibility == "Visible")
                {
                    PostalCode_2.errVisibility = "'Hidden";
                }

                OnPropertyChanged(nameof(PostalCode_2));
            }
        }

        #endregion

        #region "詳細　住所"
        private TextItem TI_Address;
        /// <summary>
        /// 住所
        /// </summary>
        public TextItem Address
        {
            get { return TI_Address; }
            set
            {
                TI_Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        #endregion

        #region "詳細　電話番号"
        private TextItem TI_TelNo;
        /// <summary>
        /// 電話番号
        /// </summary>
        public TextItem TelNo
        {
            get { return TI_TelNo; }
            set
            {
                TI_TelNo = value;
                OnPropertyChanged(nameof(TelNo));
            }
        }
        #endregion

        #region "詳細　FAX番号"
        private TextItem TI_FaxNo;
        /// <summary>
        /// FAX番号
        /// </summary>
        public TextItem FaxNo
        {
            get { return TI_FaxNo; }
            set
            {
                TI_FaxNo = value;
                OnPropertyChanged(nameof(FaxNo));
            }
        }
        #endregion

        #region "詳細　メールアドレス"
        private TextItem TI_Mail;
        /// <summary>
        /// メールアドレス
        /// </summary>
        public TextItem MailAddress
        {
            get { return TI_Mail; }
            set
            {
                TI_Mail = value;
                OnPropertyChanged(nameof(MailAddress));
            }
        }
        #endregion

        public BindingData()
        {
            AppMessage = "";

            // 検索
            SearchKaisyaCode = "";
            SearchKaisyaName_Ryaku = "";
            KaisyaInfo = new DataTable();

            // 詳細
            InvalidFlg = new CheckItem(false, "");
            KaisyaCode = new TextItem("", "");
            KaisyaName = new TextItem("", "");
            KaisyaName_Kana = new TextItem("", "");
            KaisyaName_Ryaku = new TextItem("", "");

            PostalCode_1 = new TextItem("", "");
            PostalCode_2 = new TextItem("", "");
            Address = new TextItem("", "");
            TelNo = new TextItem("", "");
            FaxNo = new TextItem("", "");
            MailAddress = new TextItem("", "");
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
        private string KaisyaCode_old = "";

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
            /*
            // DB接続
            SqlServer clsSqlServer = new SqlServer(Com01.clsSystemInfo.SystemDatabase);
            clsSqlServer.Connect();
            */
        }
        #endregion

        #region "フォームイベント処理"
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
                Com02.struct_m_kaisya m_kaisya = new Com02.struct_m_kaisya();
                m_kaisya.kigyo_code = Com01.clsSystemInfo.ComLineArgs.kigyo_code;
                m_kaisya.kaisya_code = clsBindData.SearchKaisyaCode;
                m_kaisya.kaisya_name_ryaku = "%" + clsBindData.SearchKaisyaName_Ryaku + "%";
                if (clsBindData.SearchInvalidFlg == true)
                {
                    m_kaisya.invalid_flg = 1;
                }
                clsBindData.KaisyaInfo = Com02.Get_m_kaisya(clsSqlServer, m_kaisya, 100);

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
            clsBindData.SearchKaisyaCode = "";
            clsBindData.SearchKaisyaName_Ryaku = "";
            clsBindData.KaisyaInfo = new DataTable();
        }

        /// <summary>
        /// 詳細クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyosaiClear_Click(object sender, RoutedEventArgs e)
        {
            // 選択キー値をクリア
            KaisyaCode_old = "";

            clsBindData.InvalidFlg = new CheckItem(false, "");
            clsBindData.KaisyaCode = new TextItem("", "");
            clsBindData.KaisyaName = new TextItem("", "");
            clsBindData.KaisyaName_Kana = new TextItem("", "");
            clsBindData.KaisyaName_Ryaku = new TextItem("", "");
            clsBindData.PostalCode_1 = new TextItem("", "");
            clsBindData.PostalCode_2 = new TextItem("", "");
            clsBindData.Address = new TextItem("", "");
            clsBindData.TelNo = new TextItem("", "");
            clsBindData.FaxNo = new TextItem("", "");
            clsBindData.MailAddress = new TextItem("", "");
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
                Com02.struct_m_kaisya m_kaisya;
                m_kaisya = Set_EntryData(clsSqlServer, clsBindData);

                // 新規/更新の文言を取得
                if (m_kaisya.toroku_datetime == m_kaisya.koshin_datetime)
                {
                    strProcName = "新規登録";
                }
                else
                {
                    strProcName = "更新";
                }

                // エラーチェック
                bool booRtn = Com02.Chk_m_kaisya(strErrMsg, clsSqlServer, m_kaisya);
                if (booRtn == false)
                {
                    strMsg = "入力内容に誤りがあります。";
                    return;
                }

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
                if (m_kaisya.toroku_datetime == m_kaisya.koshin_datetime)
                {
                    // 新規
                    result = Com02.Insert_m_kaisya(clsSqlServer, m_kaisya);
                }
                else
                {
                    // 更新
                    result = Com02.Update_m_kaisya(clsSqlServer, m_kaisya);
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

        #region "検索結果一覧イベント"
        /// <summary>
        /// 検索結果ダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            // イベント発生コントロール
            DataGrid dg = sender as DataGrid;

            if (dg.SelectedItem == null)
            {
                return;
            }

            // 検索のキーとなるコードを取得
            bool booChangeFlg;
            string strSelectKaisyaCode =
                    clsBindData.KaisyaInfo.Rows[dg.SelectedIndex].ItemArray[Com02.struct_m_kaisya.idx_kaisya_code].ToString();

            // 変更データの登録・変更破棄の確認
            booChangeFlg = Chk_SyosaiChange(clsBindData, strSelectKaisyaCode);

            // 変更箇所ありの場合はユーザに確認
            if (booChangeFlg == true)
            {
                MessageBoxResult result = MessageBox.Show("登録・更新前です。" + Environment.NewLine + "破棄してもよろしいでしょうか？", "", MessageBoxButton.YesNo);
                if (!(result == MessageBoxResult.Yes))
                {
                    return;
                }
            }

            // 選択内容を詳細に反映
            Set_SyosaiInfo(clsBindData, strSelectKaisyaCode, ref KaisyaCode_old);

            // 反映
            this.DataContext = clsBindData;
        }

        #endregion

        /// <summary>
        /// 引数のデータテーブルからマテリアルコードが一致する値を詳細にセットする。
        /// </summary>
        /// <param name="bindingData"></param>
        /// <param name="kaisyaCode"></param>
        /// <param name="kaisyaCode_old"></param>
        private void Set_SyosaiInfo(BindingData bindingData, string kaisyaCode, ref string materialCode_old)
        {
            // Selectメソッドを使ってデータを抽出
            DataRow[] dRowsRecode = bindingData.KaisyaInfo.Select("kaisya_code = '" + kaisyaCode + "'");
            if (dRowsRecode == null || dRowsRecode.Length > 1)
            {
                // なぜこうなるのか
                return;
            }

            // 無効フラグ
            if (dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_invalid_flg].ToString() == "1")
            {
                bindingData.InvalidFlg = new CheckItem(true, "");
            }
            else
            {
                bindingData.InvalidFlg = new CheckItem(false, "");
            }

            string[] postal = dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_postal_code].ToString().Split('-');
            bindingData.PostalCode_1 = new TextItem(postal[0], "");
            bindingData.PostalCode_2 = new TextItem(postal[1], "");

            bindingData.KaisyaCode = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_kaisya_code].ToString(), "");
            bindingData.KaisyaName = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_kaisya_name].ToString(), "");
            bindingData.KaisyaName_Kana = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_kaisya_name_kana].ToString(), "");
            bindingData.KaisyaName_Ryaku = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_kaisya_name_ryaku].ToString(), "");
            bindingData.Address = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_address].ToString(), "");
            bindingData.TelNo = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_tel_no].ToString(), "");
            bindingData.FaxNo = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_fax_no].ToString(), "");
            bindingData.MailAddress = new TextItem(dRowsRecode[0].ItemArray[Com02.struct_m_kaisya.idx_mail_address].ToString(), "");

            // キーの旧情報として保持
            KaisyaCode_old = bindingData.KaisyaCode.text;
            return;
        }

        /// <summary>
        /// 詳細情報変更チェック処理
        /// </summary>
        /// <param name="bindingData"></param>
        /// <param name="strKaisyaCode_old"></param>
        /// <returns></returns>
        private bool Chk_SyosaiChange(BindingData bindingData, string strKaisyaCode_old)
        {
            if (strKaisyaCode_old == "")
            {
                // 旧情報無し
                return false;
            }

            // キー項目を確認
            if (!(bindingData.KaisyaCode.text.Equals(strKaisyaCode_old)))
            {
                return true;
            }

            // キー項目以外でバインド元データと差異があるか確認
            DataRow dRows = bindingData.KaisyaInfo.Select("kaisya_code = '" + bindingData.KaisyaCode.text + "'")[0];
            if (!(dRows[Com02.struct_m_kaisya.idx_kaisya_name].ToString() == bindingData.KaisyaName.text))
            {
                return true;
            }

            // 変更なし
            return false;
        }

        /// <summary>
        /// マスタ登録データ設定処理
        /// </summary>
        /// <param name="clsSqlServer"></param>
        /// <param name="bindingData"></param>
        /// <returns></returns>
        private Com02.struct_m_kaisya Set_EntryData(SqlServer clsSqlServer, BindingData bindingData)
        {

            // キーを条件に最新データを取得
            Com02.struct_m_kaisya m_kaisya = new Com02.struct_m_kaisya();
            m_kaisya.kigyo_code = Com01.clsSystemInfo.ComLineArgs.kigyo_code;
            m_kaisya.kaisya_code = bindingData.KaisyaCode.text;
            m_kaisya.invalid_flg = 1; // 削除も含めて検索
            DataTable dTable = Com02.Get_m_kaisya(clsSqlServer, m_kaisya, 1);

            // システム日時を取得
            Com01.Set_DateTime(clsSqlServer);

            // 更新日時をセット
            m_kaisya.koshin_datetime = Com01.clsSystemInfo.dtNow.ToString();
            m_kaisya.koshin_user_id = Com01.clsSystemInfo.ComLineArgs.user_id;
            m_kaisya.koshin_program = Com01.clsSystemInfo.strExeName;

            // 検索結果
            if (dTable == null || dTable.Rows.Count == 0)
            {
                // 新規登録日時
                m_kaisya.toroku_datetime = m_kaisya.koshin_datetime;
                m_kaisya.toroku_user_id = m_kaisya.koshin_user_id;
                m_kaisya.toroku_program = m_kaisya.koshin_program;

                // 空の場合は規定値を
                m_kaisya.invalid_flg = 0;
            }
            else
            {

                DataRow dRow = dTable.Rows[0];

                // 取得内容を構造体へ
                m_kaisya.toroku_datetime = dRow[Com02.struct_m_kaisya.idx_toroku_datetime].ToString();
                m_kaisya.toroku_user_id = dRow[Com02.struct_m_kaisya.idx_toroku_user_id].ToString();
                m_kaisya.toroku_program = dRow[Com02.struct_m_kaisya.idx_toroku_program].ToString();

                m_kaisya.invalid_flg = int.Parse(dRow[Com02.struct_m_kaisya.idx_invalid_flg].ToString());

                m_kaisya.kaisya_code = dRow[Com02.struct_m_kaisya.idx_kaisya_code].ToString();
                m_kaisya.kaisya_name = dRow[Com02.struct_m_kaisya.idx_kaisya_name].ToString();
                m_kaisya.kaisya_name_kana = dRow[Com02.struct_m_kaisya.idx_kaisya_name_kana].ToString();
                m_kaisya.kaisya_name_ryaku = dRow[Com02.struct_m_kaisya.idx_kaisya_name_ryaku].ToString();
                m_kaisya.address = dRow[Com02.struct_m_kaisya.idx_address].ToString();
                m_kaisya.postal_code = dRow[Com02.struct_m_kaisya.idx_postal_code].ToString();
                m_kaisya.tel_no = dRow[Com02.struct_m_kaisya.idx_tel_no].ToString();
                m_kaisya.fax_no = dRow[Com02.struct_m_kaisya.idx_fax_no].ToString();
                m_kaisya.mail_address = dRow[Com02.struct_m_kaisya.idx_mail_address].ToString();
            }

            // これに対して画面内容を上書く
            if (bindingData.InvalidFlg.check == true)
            {
                m_kaisya.invalid_flg = 1;
            }
            else
            {
                m_kaisya.invalid_flg = 0;
            }
            m_kaisya.kaisya_code = bindingData.KaisyaCode.text;
            m_kaisya.kaisya_name = bindingData.KaisyaName.text;
            m_kaisya.kaisya_name_kana = bindingData.KaisyaName_Kana.text;
            m_kaisya.kaisya_name_ryaku = bindingData.KaisyaName_Ryaku.text;
            m_kaisya.address = bindingData.Address.text;
            m_kaisya.postal_code = bindingData.PostalCode_1.text + "-" + bindingData.PostalCode_2.text;
            m_kaisya.tel_no = bindingData.TelNo.text;
            m_kaisya.fax_no = bindingData.FaxNo.text;
            m_kaisya.mail_address = bindingData.MailAddress.text;

            return m_kaisya;
        }

    }
}
