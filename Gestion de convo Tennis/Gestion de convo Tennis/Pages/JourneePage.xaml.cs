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
using Gestion_de_convo_Tennis.Classes;

namespace Gestion_de_convo_Tennis.Pages
{
    /// <summary>
    /// Logique d'interaction pour JourneePage.xaml
    /// </summary>
    public partial class JourneePage : Page
    {
        public String categorie;
        public JourneePage()
        {
            InitializeComponent();
            gridDateValidationJoueur.Visibility = Visibility.Hidden;
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            dataGridRecapJournees.ItemsSource = MainWindow.journees;
        }




        //Visibilité des grids
        private void buttonSelectSenior_Click(object sender, RoutedEventArgs e)
        {
            labelTitreJournee.Content = "SAISIE DES JOURNEES "+ buttonSelectSenior.Content;
            labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie " + buttonSelectSenior.Content + " :";
            gridCalendrierJournees.Visibility = Visibility.Visible;
            categorie = "Senior";
        }
        private void buttonSelectSeniorPlus_Click(object sender, RoutedEventArgs e)
        {
            labelTitreJournee.Content = "SAISIE DES JOURNEES " + buttonSelectSeniorPlus.Content;
            labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie " + buttonSelectSeniorPlus.Content + " :";
            gridCalendrierJournees.Visibility = Visibility.Visible;
            categorie = "Senior +";
        }
        private void buttonValiderJournees_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                labelErreurJournees.Content = "";
                Int32.Parse(textBoxNbEquipes.Text);
                gridDateValidationJoueur.Visibility = Visibility.Visible;
                foreach (DateTime date in calendarDateJournee.SelectedDates)
                {
                    MainWindow.journees.Add(new Journee(0, date, categorie));
                }
                dataGridRecapJournees.Items.Refresh();

            }
            catch (FormatException exception)
            {
                labelErreurJournees.Content = exception.Message;
            }
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
