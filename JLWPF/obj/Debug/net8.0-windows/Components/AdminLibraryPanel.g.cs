﻿#pragma checksum "..\..\..\..\Components\AdminLibraryPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E4FA6ECFCEE28CE381ED33C4BDE65E34E2A68A2E"
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
    /// AdminLibraryPanel
    /// </summary>
    public partial class AdminLibraryPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Components\AdminLibraryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveArticle;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Components\AdminLibraryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditArticle;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Components\AdminLibraryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewArticle;
        
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
            System.Uri resourceLocater = new System.Uri("/JLWPF;component/components/adminlibrarypanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Components\AdminLibraryPanel.xaml"
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
            
            #line 9 "..\..\..\..\Components\AdminLibraryPanel.xaml"
            ((JLWPF.Components.AdminLibraryPanel)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnRemoveArticle = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Components\AdminLibraryPanel.xaml"
            this.btnRemoveArticle.Click += new System.Windows.RoutedEventHandler(this.btnRemoveArticle_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnEditArticle = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Components\AdminLibraryPanel.xaml"
            this.btnEditArticle.Click += new System.Windows.RoutedEventHandler(this.btnEditArticle_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnViewArticle = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Components\AdminLibraryPanel.xaml"
            this.btnViewArticle.Click += new System.Windows.RoutedEventHandler(this.btnViewArticle_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

