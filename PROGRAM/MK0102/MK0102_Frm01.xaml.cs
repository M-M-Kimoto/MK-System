using SQL_Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MK0102
{

    /// <summary>
    /// メニューボタンプロパティ用クラス
    /// </summary>
    public class btnMenu
    {

        public int id { get; set; }
        public string text { get; set; }
        public string program_id { get; set; }
        public int in_menu_id { get; set; }
        public bool visible { get; set; }
        public string visibility { get; set; }

        public string back_color { get; set; }

        /// <summary>
        /// コンストラクタ１
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_text"></param>
        /// <param name="_program_id"></param>
        /// <param name="_in_menu_id"></param>
        /// <param name="_visible"></param>
        public btnMenu(int _id, string _text, string _program_id, int _in_menu_id, bool _visible)
        {
            SetPropates(_id, _text, _program_id, _in_menu_id, _visible);
        }

        /// <summary>
        /// コンストラクタ２
        /// </summary>
        /// <param name="_BtnMenu"></param>
        public btnMenu(btnMenu _BtnMenu)
        {
            SetPropates(_BtnMenu.id, _BtnMenu.text, _BtnMenu.program_id, _BtnMenu.in_menu_id, _BtnMenu.visible);
        }

        /// <summary>
        /// 初期設定処理
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_text"></param>
        /// <param name="_program_id"></param>
        /// <param name="_in_menu_id"></param>
        /// <param name="_visible"></param>
        private void SetPropates(int _id, string _text, string _program_id, int _in_menu_id, bool _visible)
        {
            this.id = _id;
            this.text = _text;
            this.program_id = _program_id;
            this.in_menu_id = _in_menu_id;
            this.visible = _visible;
            if (this.visible == true)
            {
                this.visibility = "Visible";
            }
            else
            {
                this.visibility = "Hidden";
            }

            if (this.program_id != "")
            {
                // プログラム起動ボタン
                this.back_color = "#FF9AEE9A";
            }
            else
            {
                // メニューボタン
                this.back_color = "#FFF3BCB9";
            }
        }

    }

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
        /// <param name="name"></param>
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string strAppMessage_val;

        /// <summary>
        /// メッセージ
        /// </summary>
        public string AppMessage
        {
            get { return strAppMessage_val; }
            set
            {
                strAppMessage_val = value;
                OnPropertyChanged("AppMessage");
            }
        }

        public ObservableCollection<btnMenu> LstBtnMenu = new ObservableCollection<btnMenu>();
        public ObservableCollection<btnMenu> Menu { get { return LstBtnMenu; } set { LstBtnMenu = value; } }

        /// <summary>
        /// 初期処理　全てのボタンを非表示にする
        /// </summary>
        public BindingData()
        {

            // メニュー設定用のリスト
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
            LstBtnMenu.Add(new btnMenu(0, "", "", 0, false));
        }
    }

    /// <summary>
    /// v_kigyo_menu構造体
    /// </summary>
    struct struct_kigyo_menu
    {
        public int id;
        public string name;
        public int in_menu_id;
        public string program_id;
        public int unvisible_flg;
    }

    /// <summary>
    /// Interaction logic for View002.xaml
    /// </summary>
    public partial class View001 : Window
    {

        // データバインディングクラスの宣言
        private BindingData clsBindData;

        #region "初期処理"

        /// <summary>
        /// 初期処理
        /// </summary>
        public View001()
        {
            InitializeComponent();

            // ソリューション共通初期処理
            Com01.SystemInit();

            // 企業メニューからトップメニューを取得する
            ProcMenuSetting(0);

        }

        #endregion

        #region "ボタンクリックイベント"

        private void TopMenu_Click(object sender, RoutedEventArgs e)
        {

            // 企業メニューからトップメニューを取得する
            ProcMenuSetting(0);
        }


        private void End_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// メニューボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Click(object sender, RoutedEventArgs e)
        {

            string strMsg = "";
            string strErrMsg = "";
            Button ClickButton = (Button)sender;
            btnMenu ClickMenuInfo;

            try
            {
                // ボタンの名前に連番を降っており、それがLstBtnMenuの配列番号とリンクしている
                int IntMenuSeq = int.Parse(ClickButton.Name.Split('_')[1]);
                ClickMenuInfo = clsBindData.Menu[IntMenuSeq];

                if (ClickMenuInfo.program_id != "")
                {
                    // 実行ファイルを実行
                    bool BooMenuExe = Com01.CallMenuExe(ClickMenuInfo.program_id, Com01.clsSystemInfo.ComLineArgs);
                    if (BooMenuExe == false)
                    {
                        strMsg = ClickMenuInfo.text + "の起動処理に失敗しました。";
                        return;
                    }
                }
                else
                {
                    // 直下のメニュー取得・設定
                    ProcMenuSetting(ClickMenuInfo.id);
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

                // カーソルを待機カーソルに変更
                Mouse.OverrideCursor = Cursors.Arrow;
            }

        }

        #endregion

        #region "メニュー取得・設定処理"

        /// <summary>
        /// 引数のメニュー直下を取得しメニューボタンへ設定する処理
        /// </summary>
        /// <param name="_InMenuID"></param>
        private void ProcMenuSetting(int _InMenuID)
        {

            // DB接続
            SqlServer clsSqlServer = new SqlServer(Com01.clsSystemInfo.SystemDatabase);
            clsSqlServer.Connect();

            // メニュー
            var LstKigyoMenu = new List<struct_kigyo_menu>();
            LstKigyoMenu = Get_KigyoMenus(clsSqlServer, _InMenuID);

            // 取得結果をBindingDataクラスに設定する
            Set_MenuBottom(LstKigyoMenu);
        }

        /// <summary>
        /// 指定メニューID直下の物を取得
        /// </summary>
        /// <param name="clsSqlServer"></param>
        /// <param name="iniMenuID"></param>
        /// <returns></returns>
        private List<struct_kigyo_menu> Get_KigyoMenus(SqlServer clsSqlServer, int iniMenuID = 0)
        {

            string strSql;
            var LstKigyoMenu = new List<struct_kigyo_menu>();
            struct_kigyo_menu structKigyoMenu;
            DataTable DatSqlResult = new DataTable();

            strSql = "";
            strSql += Environment.NewLine + " " + "select              ";
            strSql += Environment.NewLine + " " + "    id,             ";
            strSql += Environment.NewLine + " " + "    name,           ";
            strSql += Environment.NewLine + " " + "    in_menu_id,     ";
            strSql += Environment.NewLine + " " + "    program_id,     ";
            strSql += Environment.NewLine + " " + "    unvisible_flg　 ";
            strSql += Environment.NewLine + " " + "from v_kigyo_menu   ";
            strSql += Environment.NewLine + " " + "where 1 = 1";
            strSql += Environment.NewLine + " " + "and in_menu_id = " + iniMenuID.ToString();
            strSql += Environment.NewLine + " " + "and kigyo_code = '" + Com01.clsSystemInfo.ComLineArgs.kigyo_code + "'";
            strSql += Environment.NewLine + " " + "order by unvisible_flg asc, id asc";

            // sqlの実行
            DatSqlResult = clsSqlServer.ExeSQL_Select(strSql);

            foreach (DataRow dr in DatSqlResult.Rows)
            {
                structKigyoMenu = new struct_kigyo_menu();

                // レコード内容を構造体へ
                structKigyoMenu.id = int.Parse(dr["id"].ToString());
                structKigyoMenu.name = dr["name"].ToString();
                structKigyoMenu.program_id = dr["program_id"].ToString();
                structKigyoMenu.in_menu_id = int.Parse(dr["in_menu_id"].ToString());
                structKigyoMenu.unvisible_flg = int.Parse(dr["unvisible_flg"].ToString());

                // 追加
                LstKigyoMenu.Add(structKigyoMenu);

            }

            return LstKigyoMenu;

        }

        /// <summary>
        /// メニューボタンにデータをバインディングにセットする
        /// </summary>
        /// <param name="LstKigyoMenu"></param>
        private void Set_MenuBottom(List<struct_kigyo_menu> LstKigyoMenu)
        {

            int MenuSeq;
            // 全て初期化
            clsBindData = new BindingData();


            //clsBindData.LstBtnMenu = new ObservableCollection<btnMenu>();
            MenuSeq = 0;
            foreach (struct_kigyo_menu structKigyoMenu in LstKigyoMenu)
            {
                if (structKigyoMenu.unvisible_flg == 1)
                {
                    // 非表示が出たら終わり
                    break;
                }

                // 内容をセット
                clsBindData.LstBtnMenu[MenuSeq] = new btnMenu(structKigyoMenu.id, structKigyoMenu.name, structKigyoMenu.program_id, structKigyoMenu.in_menu_id, true);
                MenuSeq++;
            }

            // バインド
            this.DataContext = clsBindData;

        }

        #endregion

    }
}