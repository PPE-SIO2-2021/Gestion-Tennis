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
            gridDateValidationJoueur.Visibility = Visibility.Hidden;
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            
        }

        private void buttonSelectSenior_Click(object sender, RoutedEventArgs e)
        {
            labelTitreJournee.Content = "SAISIE DES JOURNEES SENIOR";
            labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie senior :";
            gridCalendrierJournees.Visibility = Visibility.Visible;
        }

        private void buttonSelectSeniorPlus_Click(object sender, RoutedEventArgs e)
        {
            labelTitreJournee.Content = "SAISIE DES JOURNEES SENIOR+";
            labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie senior+ :";
            gridCalendrierJournees.Visibility = Visibility.Visible;
        }

        private void buttonValiderJournees_Click(object sender, RoutedEventArgs e)
        {
            gridDateValidationJoueur.Visibility = Visibility.Visible;
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
            if (gridCalendrierJournees.Visibility == Visibility.Visible)
            {
                gridDateValidationJoueur.Visibility = Visibility.Hidden;
            }
        }
    }
}
