﻿#pragma checksum "..\..\..\WomensDay.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "02D07C356324EAF1A1013F5F5042D03C9452AE57481A0F66A5B829FF9ED506A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SMELuckyDraw.UC;
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


namespace SMELuckyDraw {
    
    
    /// <summary>
    /// WomensDay
    /// </summary>
    public partial class WomensDay : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonStart;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonStop;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbMsg;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SMELuckyDraw.UC.NumberGroup numberGroupMain;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbWinner;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbBackground;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSubContent;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRest;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\WomensDay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBlank;
        
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
            System.Uri resourceLocater = new System.Uri("/SMELuckyDraw;component/womensday.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WomensDay.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 5 "..\..\..\WomensDay.xaml"
            ((SMELuckyDraw.WomensDay)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonStart = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\WomensDay.xaml"
            this.buttonStart.Click += new System.Windows.RoutedEventHandler(this.buttonStart_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonStop = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\WomensDay.xaml"
            this.buttonStop.Click += new System.Windows.RoutedEventHandler(this.buttonStop_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbMsg = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.numberGroupMain = ((SMELuckyDraw.UC.NumberGroup)(target));
            return;
            case 6:
            this.lbWinner = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cbBackground = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.lblSubContent = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.btnRest = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\WomensDay.xaml"
            this.btnRest.Click += new System.Windows.RoutedEventHandler(this.btnRest_Click);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\WomensDay.xaml"
            this.btnRest.GotFocus += new System.Windows.RoutedEventHandler(this.btnRest_GotFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnBlank = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

