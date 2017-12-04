﻿#pragma checksum "..\..\AddExpenses.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0E64299BF50F433C37FD37BA0B9F0E46"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using WalletManager;


namespace WalletManager {
    
    
    /// <summary>
    /// AddExpenses
    /// </summary>
    public partial class AddExpenses : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\AddExpenses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValue;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\AddExpenses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AddExpenses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbWallet;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AddExpenses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCategory;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\AddExpenses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WalletManager;component/addexpenses.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddExpenses.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtValue = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\AddExpenses.xaml"
            this.txtValue.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.valuePreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dtpDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.cmbWallet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 54 "..\..\AddExpenses.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.newWalletClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 63 "..\..\AddExpenses.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.newCategoryClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\AddExpenses.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAddClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

