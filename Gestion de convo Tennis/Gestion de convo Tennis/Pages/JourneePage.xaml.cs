using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_de_convo_Tennis.Pages
{
    /// <summary>
    /// Logique d'interaction pour JourneePage.xaml
    /// </summary>
    public partial class JourneePage : Page
    {
        public JourneePage()
        {
            InitializeComponent();
            gridValidateJoueur.Visibility = Visibility.Hidden;
            gridCalendrier.Visibility = Visibility.Hidden;
            
        }

        private void buttonSenior_Click(object sender, RoutedEventArgs e)
        {
            LabelTitreJournee.Content = "SAISIE DES JOURNEES SENIOR";
            LabelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie senior :";
            gridCalendrier.Visibility = Visibility.Visible;
        }

        private void buttonSeniorPlus_Click(object sender, RoutedEventArgs e)
        {
            LabelTitreJournee.Content = "SAISIE DES JOURNEES SENIOR+";
            LabelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie senior+ :";
            gridCalendrier.Visibility = Visibility.Visible;
        }

        private void buttonValiderJournees_Click(object sender, RoutedEventArgs e)
        {
            gridValidateJoueur.Visibility = Visibility.Visible;
        }

        private void buttonConfirmerJournees_Click(object sender, RoutedEventArgs e)
        {
            switchValidateVisibility();
        }
        private void buttonAnnulerJournees_Click(object sender, RoutedEventArgs e)
        {
            switchValidateVisibility();
        }
        private void switchValidateVisibility()
        {
            if (gridCalendrier.Visibility == Visibility.Visible)
            {
                gridValidateJoueur.Visibility = Visibility.Hidden;
            }
        }
    }
}
