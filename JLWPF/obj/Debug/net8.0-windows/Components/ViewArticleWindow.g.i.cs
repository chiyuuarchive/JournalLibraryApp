﻿#pragma checksum "..\..\..\..\Components\ViewArticleWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EA221EC2242D5A4FC0C4054C7FFADD25991A6BD1"
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


namespace JLWPF.Components {
    
    
    /// <summary>
    /// ViewArticleWindow
    /// </summary>
    public partial class ViewArticleWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal JLWPF.Components.Header UIHeader;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtArticleTitle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAbstract;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAuthors;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPublishedAt;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtYearOfPublication;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtCategory;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSource;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink linkSource;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Components\ViewArticleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSource;
        
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
            System.Uri resourceLocater = new System.Uri("/JLWPF;V1.0.0.0;component/components/viewarticlewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Components\ViewArticleWindow.xaml"
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
            
            #line 9 "..\..\..\..\Components\ViewArticleWindow.xaml"
            ((JLWPF.Components.ViewArticleWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UIHeader = ((JLWPF.Components.Header)(target));
            return;
            case 3:
            this.txtArticleTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtAbstract = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtAuthors = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtPublishedAt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txtYearOfPublication = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txtCategory = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.txtSource = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.linkSource = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 72 "..\..\..\..\Components\ViewArticleWindow.xaml"
            this.linkSource.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.linkSource_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnSource = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\Components\ViewArticleWindow.xaml"
            this.btnSource.Click += new System.Windows.RoutedEventHandler(this.btnSource_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

