﻿#pragma checksum "C:\Users\MS-USER\Documents\Visual Studio 2015\Projects\KelimeOyunu\KelimeOyunu\Levels\Level4.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A10C2755FE99CDAEC9B229255045BE01"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KelimeOyunu.Levels
{
    partial class Level4 : 
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
                    this.appbtnhome = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 12 "..\..\..\Levels\Level4.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.appbtnhome).Click += this.appbtnhome_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.txttime = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.txtdefault = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.txtnew = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.btnok = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 46 "..\..\..\Levels\Level4.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btnok).Click += this.btnok_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.txtpoint = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.txtlevel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

