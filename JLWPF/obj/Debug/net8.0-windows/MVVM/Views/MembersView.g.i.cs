﻿#pragma checksum "..\..\..\..\..\MVVM\Views\MembersView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B99B52072E487A26AE4D0F83DCB4BCFF374D5B08"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JLWPF.MVVM.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace JLWPF.MVVM.Views {
    
    
    /// <summary>
    /// MembersView
    /// </summary>
    public partial class MembersView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MembersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdmin;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerify;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveMember;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewDownloadLog;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JLWPF;component/mvvm/views/membersview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            ((JLWPF.MVVM.Views.MembersView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnReturn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            this.btnReturn.Click += new System.Windows.RoutedEventHandler(this.btnReturn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MembersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 36 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            this.MembersDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MembersDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            this.btnAdmin.Click += new System.Windows.RoutedEventHandler(this.btnAdmin_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnVerify = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            this.btnVerify.Click += new System.Windows.RoutedEventHandler(this.btnVerify_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRemoveMember = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            this.btnRemoveMember.Click += new System.Windows.RoutedEventHandler(this.btnRemoveMember_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnViewDownloadLog = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\..\MVVM\Views\MembersView.xaml"
            this.btnViewDownloadLog.Click += new System.Windows.RoutedEventHandler(this.btnViewDownloadLog_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

