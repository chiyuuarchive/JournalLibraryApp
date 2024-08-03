﻿#pragma checksum "..\..\..\..\..\MVVM\Views\LibraryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00332CEA39FE37D14EF1ABB4779D112920CF13B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JLWPF.Components;
using JLWPF.MVVM.Auxiliaries;
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
    /// LibraryView
    /// </summary>
    public partial class LibraryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ArticleDataGrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal JLWPF.Components.UserLibraryPanel UserLibrary;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal JLWPF.Components.AdminLibraryPanel AdminLibrary;
        
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
            System.Uri resourceLocater = new System.Uri("/JLWPF;component/mvvm/views/libraryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 11 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
            ((JLWPF.MVVM.Views.LibraryView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnReturn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
            this.btnReturn.Click += new System.Windows.RoutedEventHandler(this.btnReturn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ArticleDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 39 "..\..\..\..\..\MVVM\Views\LibraryView.xaml"
            this.ArticleDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ArticleDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UserLibrary = ((JLWPF.Components.UserLibraryPanel)(target));
            return;
            case 5:
            this.AdminLibrary = ((JLWPF.Components.AdminLibraryPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

