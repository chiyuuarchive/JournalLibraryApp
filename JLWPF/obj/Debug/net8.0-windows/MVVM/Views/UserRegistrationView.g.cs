﻿#pragma checksum "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6F0F594986F66656A58202C86525ED0DA93D38BB"
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
    /// UserRegistrationView
    /// </summary>
    public partial class UserRegistrationView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFirstName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLastName;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIsAdmin;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
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
            System.Uri resourceLocater = new System.Uri("/JLWPF;component/mvvm/views/userregistrationview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
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
            
            #line 9 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            ((JLWPF.MVVM.Views.UserRegistrationView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.txtFirstName = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtFirstName.GotFocus += new System.Windows.RoutedEventHandler(this.txtFirstName_GotFocus);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtFirstName.LostFocus += new System.Windows.RoutedEventHandler(this.txtFirstName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtLastName = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtLastName.GotFocus += new System.Windows.RoutedEventHandler(this.txtLastName_GotFocus);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtLastName.LostFocus += new System.Windows.RoutedEventHandler(this.txtLastName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.chkIsAdmin = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 69 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtEmail.GotFocus += new System.Windows.RoutedEventHandler(this.txtEmail_GotFocus);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtEmail.LostFocus += new System.Windows.RoutedEventHandler(this.txtEmail_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 80 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtPassword.GotFocus += new System.Windows.RoutedEventHandler(this.txtPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 80 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.txtPassword.LostFocus += new System.Windows.RoutedEventHandler(this.txtPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\..\..\MVVM\Views\UserRegistrationView.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

