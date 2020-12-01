using System;


/// <summary>
/// 入力項目　テキストボックス
/// </summary>
public class TextItem
{
    public string text { get; set; }
    public string errMsg { get; set; }
    public string errVisibility { get; set; }

    public TextItem(string _text, string _errMsg)
    {
        SetPropates(_text, _errMsg);
    }

    /// <summary>
    /// 初期設定処理
    /// </summary>
    /// <param name="_text"></param>
    /// <param name="_errMsg"></param>
    private void SetPropates(string _text, string _errMsg)
    {
        this.text = _text;
        this.errMsg = _errMsg;
        if (this.errMsg.Trim() != "")
        {
            this.errVisibility = "Visible";
        }
        else
        {
            this.errVisibility = "Hidden";
        }
    }
}


/// <summary>
/// 入力項目　チェックボックス
/// </summary>
public class CheckItem
{
    public bool check { get; set; }
    public string errMsg { get; set; }
    public string errVisibility { get; set; }

    public CheckItem(bool _check, string _errMsg)
    {
        SetPropates(_check, _errMsg);
    }

    /// <summary>
    /// 初期設定処理
    /// </summary>
    /// <param name="_check"></param>
    /// <param name="_errMsg"></param>
    private void SetPropates(bool _check, string _errMsg)
    {
        this.check = _check;
        this.errMsg = _errMsg;
        if (this.errMsg.Trim() != "")
        {
            this.errVisibility = "Visible";
        }
        else
        {
            this.errVisibility = "Hidden";
        }
    }
}