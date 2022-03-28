/************************************************************************************
* Class Name    : ListItem
* Author        : 
* Created Date  : 
* Version       : 
* Description   : This class used to define the listitem properties
*************************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;

namespace Captain.Common.Utilities
{
    [Serializable()]
    public class ListItem : IComparable<ListItem>
    {
        public ListItem()
        {
            Text = string.Empty;
            Value = string.Empty;
            ValueDisplayCode = string.Empty;
            ID = string.Empty;
            IsInstanceItem = false;
        }

        public ListItem(string text)
        {
            Text = text.Trim();
            Value = text.Trim();
            ID = text.Trim();
            IsInstanceItem = false;
        }

        public ListItem(string text, object value)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = string.Empty;            
            IsInstanceItem = false;
        }

        public ListItem(string text, object value, string id,Color favoriteColor)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            FavoriteColor = favoriteColor;
            IsInstanceItem = false;
        }

        public ListItem(string text, object value, string id, Color favoriteColor,string defaultvalue)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            FavoriteColor = favoriteColor;
            IsInstanceItem = false;
            DefaultValue = defaultvalue.Trim();
        }

        public ListItem(string text, object value, string id, Color favoriteColor, string defaultvalue,string valueDisplaycode)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            FavoriteColor = favoriteColor;
            IsInstanceItem = false;
            DefaultValue = defaultvalue.Trim();
            ValueDisplayCode = valueDisplaycode.Trim();
        }

        public ListItem(string text, object value, string id, string code)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            ValueDisplayCode = code.Trim();          
        }

        public ListItem(string text, object value, string id, string code,string screenCode,string screenType)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            ValueDisplayCode = code.Trim();
            ScreenCode = screenCode.Trim();
            ScreenType = screenType.Trim();
        }
        public ListItem(string text, object value, string id, string code, string screenCode, string screenType, Color favoriteColor)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            ValueDisplayCode = code.Trim();
            ScreenCode = screenCode.Trim();
            ScreenType = screenType.Trim();
            FavoriteColor = favoriteColor;
        }

        public ListItem(string text, object value, string id, bool isInstanceItem)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            IsInstanceItem = isInstanceItem;
        }

        public ListItem(string text, object value, string id, string code, string screenCode, string screenType, string stramount,string strdetails)
        {
            Text = text.Trim();
            Value = value.ToString().Trim();
            ID = id.Trim();
            ValueDisplayCode = code.Trim();
            ScreenCode = screenCode.Trim();
            ScreenType = screenType.Trim();
            
            Amount = stramount;
            Details = strdetails;
        }


        public string ID { get; set; }

        public string Text { get; set; }

        [Browsable(false)]
        public object Value { get; set; }

        public string ValueDisplayCode { get; set; }

        public string ScreenType { get; set; }

        public string ScreenCode{ get; set; }

        public bool IsInstanceItem { get; set; }

        public Color FavoriteColor { get; set; }

        public string DefaultValue { get; set; }

        public string ToolTip { get; set; }

        public string Details { get; set; }

        public string Amount { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public string GetValues()
        {
            return Text + Consts.Common.Tilda + ID + Consts.Common.Tilda + Value.ToString();
        }

        public int CompareTo(ListItem other)
        {
            return Text.CompareTo(other.Text);
        }
    }
}
