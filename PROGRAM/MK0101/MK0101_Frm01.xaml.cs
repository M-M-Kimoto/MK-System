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

namespace MK0101
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
        /// <param name="name"></param>
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string strKigyoCode_val;
        private string strUserID_val;
        private string strPassWord_val;
        private string strAppMessage_val;
        private DataTable DatSystemNews_val;

        /// <summary>
        /// 企業コード
        /// </summary>
        public string KigyoCode
        {
            get { return strKigyoCode_val; }
            set
            {
                strKigyoCode_val = value;
                OnPropertyChanged("KigyoCode");
            }
        }
        /// <summary>
        /// ユーザID
        /// </summary>
        public string UserID
        {
            get { return strUserID_val; }
            set
            {
                strUserID_val = value;
                OnPropertyChanged("UserID");
            }
        }
        /// <summary>
        /// パスワード
        /// </summary>
        public string PassWord
        {
            get { return strPassWord_val; }
            set
            {
                strPassWord_val = value;
                OnPropertyChanged("PassWord");
            }
        }
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

        /// <summary>
        /// 新着情報
        /// </summary>
        public DataTable DatSystemNews
        {
            get { return DatSystemNews_val; }
            set
            {
                DatSystemNews_val = value;
                OnPropertyChanged("DatSystemNews");
            }
        }

    }

    #endregion

    /// <summary>
    /// Interaction logic for MK0101_Frm01.xaml
    /// ※View
    /// </summary>
    public partial class View01 : Window

    {
        // データバインディングクラスの宣言
        private BindingData clsBindData;

        #region 初期処理

        /// <summary>
        /// 初期処理
        /// </summary>
        public View01()
        {
            InitializeComponent();

            // ソリューション共通初期処理
            Com01.SystemInit();

            // 初期処理
            clsBindData = new BindingData();

            // データベースへ接続
            SqlServer clsSqlServer = new SqlServer(Com01.clsSystemInfo.LoginDatabase);
            clsSqlServer.Connect();

            // 新着情報取得処理
            Set_DatSystemNews(clsSqlServer, clsBindData);

            // 画面表項目初期値設定
            this.DataContext = clsBindData;
        }

        /// <summary>
        /// 新着情報の取得
        /// </summary>
        /// <param name="clsSqlServer"></param>
        /// <param name="clsBindData"></param>
        private void Set_DatSystemNews(SqlServer clsSqlServer, BindingData clsBindData)
        {
            string strSql = "";

            DataTable DatSqlResult = new DataTable();
            Dictionary<string, struct_sys003> Dic_sys003 = new Dictionary<string, struct_sys003>();

            strSql += Environment.NewLine + " " + "select ";
            strSql += Environment.NewLine + " " + "   format(toroku_datetime, 'yyyy/MM/dd HH:mm:ss') as '日付',";
            strSql += Environment.NewLine + " " + "   news            as '内容'";
            strSql += Environment.NewLine + " " + "from sys003";
            strSql += Environment.NewLine + " " + "where 1 = 1";
            strSql += Environment.NewLine + " " + "and invalid_flg = 0";

            // sqlの実行
            DatSqlResult = clsSqlServer.ExeSQL_Select(strSql);

            // データバインディング用のプロパティへ
            clsBindData.DatSystemNews = DatSqlResult;

        }

        #endregion


        /// <summary>
        /// フォームキーボード入力処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm01_KeyDown(object sender, KeyEventArgs e)
        {

            object obj = new object();
            RoutedEventArgs rea = new RoutedEventArgs();

            var key = e.SystemKey == Key.F10 ? Key.F10 : e.Key;
            switch (key)
            {
                case Key.F1:
                    Login_Click(obj, rea);
                    break;
                case Key.F12:
                    End_Click(obj, rea);
                    break;
            }

        }

        #region ボタンクリックイベント

        /// <summary>
        /// ログインボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            string strMsg = "";
            string strErrMsg = "";
            Dictionary<string, SQL_Server.struct_vew001> Dic_vew001 = new Dictionary<string, SQL_Server.struct_vew001>();

            try
            {
                #region 初期処理
                // カーソルを待機カーソルに変更
                Mouse.OverrideCursor = Cursors.Wait;

                SqlServer clsSqlServer = new SqlServer(Com01.clsSystemInfo.LoginDatabase);
                clsSqlServer.Connect();

                #endregion

                #region ユーザ情報の取得とエラーチェック
                Dic_vew001 = Com02.Select_vew001(clsSqlServer, clsBindData.KigyoCode, clsBindData.UserID, clsBindData.PassWord);
                if (Dic_vew001.Count == 0)
                {
                    // 取得件数が0件
                    strMsg = "ログインすることが出来ませんでした。入力内容を確認してください。";
                    return;
                }
                else if (Dic_vew001[clsBindData.KigyoCode].status != 0)
                {
                    // 取得件数出来たがステータスが正常以外の場合
                    strMsg = "ログインすることが出来ませんでした。入力内容を確認し、間違いがなければ管理者へ御連絡ください。";
                    return;
                }
                #endregion

                #region メニュー画面起動
                string strMenuExe = "MK0102";

                // 引数を作成
                SystemInfo.struct_CommandLineArgs SetComArgs = new SystemInfo.struct_CommandLineArgs();
                SetComArgs.kigyo_code = clsBindData.KigyoCode;
                SetComArgs.user_id = clsBindData.UserID;

                // 実行
                if (Com01.CallMenuExe(strMenuExe, SetComArgs) == false)
                {
                    strMsg = "メニュー画面起動処理に失敗しました。";
                    return;
                }
                else
                {
                    // 終了処理を実行
                    object obj = new object();
                    RoutedEventArgs rea = new RoutedEventArgs();
                    End_Click(obj, rea);
                }
                #endregion

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

        /// <summary>
        /// 終了ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}