﻿#pragma checksum "C:\Users\asus1\Desktop\14331148_梁乐生_期中project\AccountBook\AccountBook\AddAccount.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FE7087C2CADD9079C6881D5AD6BECD50"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountBook
{
    partial class AddAccount : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.pivot = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                }
                break;
            case 2:
                {
                    this.textBox_Expenses = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3:
                {
                    this.textBox_ExpensesDesc = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.listPickerExpenses = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5:
                {
                    this.DatePickerExpenses = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 6:
                {
                    this.TimePickerExpenses = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 7:
                {
                    this.textBox_Income = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8:
                {
                    this.textBox_IncomeDesc = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9:
                {
                    this.listPickerIncome = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 10:
                {
                    this.DatePickerIncome = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 11:
                {
                    this.TimePickerIncome = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 12:
                {
                    this.backButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 15 "..\..\..\AddAccount.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.backButton).Click += this.backButton_Click;
                    #line default
                }
                break;
            case 13:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element13 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 62 "..\..\..\AddAccount.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element13).Click += this.appbar_buttonAdd_Click;
                    #line default
                }
                break;
            case 14:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element14 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 67 "..\..\..\AddAccount.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element14).Click += this.appbar_buttonFinish_Click;
                    #line default
                }
                break;
            case 15:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element15 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 72 "..\..\..\AddAccount.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element15).Click += this.appbar_buttonCancel_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

