﻿#pragma checksum "..\..\..\Pages\DispoPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4A5FBF7DDB6444EFA694FB5046975FB121BA2097CFC5EC7E27432DE466E5B423"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Gestion_de_convo_Tennis.Pages;
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


namespace Gestion_de_convo_Tennis.Pages {
    
    
    /// <summary>
    /// DispoPage
    /// </summary>
    public partial class DispoPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 15 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridAffichageJoueurs;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridAffichageJournees;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridRecapJoueur;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelNomJoueur;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelPrenomJoueur;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelAgeJoueur;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelCategorieJoueur;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelClassementJoueur;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridFichiersJoueur;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Pages\DispoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridRecapJourneesJoueur;
        
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
            System.Uri resourceLocater = new System.Uri("/Gestion de convo Tennis;component/pages/dispopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DispoPage.xaml"
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
            this.dataGridAffichageJoueurs = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\Pages\DispoPage.xaml"
            this.dataGridAffichageJoueurs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridAffichageJoueurs_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGridAffichageJournees = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.gridRecapJoueur = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.labelNomJoueur = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.labelPrenomJoueur = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.labelAgeJoueur = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.labelCategorieJoueur = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.labelClassementJoueur = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.dataGridFichiersJoueur = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.dataGridRecapJourneesJoueur = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 32 "..\..\..\Pages\DispoPage.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.checkBoxDispo_Checked);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 67 "..\..\..\Pages\DispoPage.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.checkBoxDispo_Unchecked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

