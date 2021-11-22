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
        public int nbEquipes;
        List<Journee> journees = new List<Journee>();
        public JourneePage()
        {
            InitializeComponent();
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
            gridDateValidationJournees.Visibility = Visibility.Hidden;
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            dataGridRecapJournees.ItemsSource = MainWindow.journees;
        }

    //Concernant les catégories
        //Pour le bouton Senior
        private void buttonSelectSenior_Click(object sender, RoutedEventArgs e)
        {
            textBoxNbEquipes.Text = "";
            labelTitreJournee.Content = "SAISIE DES JOURNEES "+ buttonSelectSenior.Content;
            labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie " + buttonSelectSenior.Content + " :";
            gridCalendrierJournees.Visibility = Visibility.Visible;
            categorie = "Senior";
        }
        //Pour le bouton Senior + 
        private void buttonSelectSeniorPlus_Click(object sender, RoutedEventArgs e)
        {
            textBoxNbEquipes.Text = "";
            labelTitreJournee.Content = "SAISIE DES JOURNEES " + buttonSelectSeniorPlus.Content;
            labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie " + buttonSelectSeniorPlus.Content + " :";
            gridCalendrierJournees.Visibility = Visibility.Visible;
            categorie = "Senior +";
        }

    //Validation des saisies
        private void buttonValiderJournees_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                labelErreurJournees.Content = "";
                nbEquipes = Int32.Parse(textBoxNbEquipes.Text);
                gridValidationNbEquipes.Visibility = Visibility.Visible;
                labelValidationNbEquipes.Content = "Vous allez creer " + nbEquipes + " equipes pour la categorie " + categorie + ".";
            }
            catch (FormatException exception)
            {
                labelErreurJournees.Content = exception.Message;
            }
        }
    
    //Concernant le nombre d'équipes
        //Confirmation du nombre d'équipes
        private void buttonConfirmNbEquipes_Click(object sender, RoutedEventArgs e)
        {
            //Ajout des journées dans une collection
            gridDateValidationJournees.Visibility = Visibility.Visible;
            foreach (DateTime date in calendarDateJournee.SelectedDates)
            {
                journees.Add(new Journee(0, date, categorie));
            }
            dataGridRecapValidationJournees.ItemsSource = journees;
            dataGridRecapJournees.Items.Refresh();
        }
        //Annulation du nombre d'équipes
        private void buttonAnnulerNbEquipes_Click(object sender, RoutedEventArgs e)
        {
            textBoxNbEquipes.Text = "";
            nbEquipes = 0;
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
        }

    //Concernant les journées
        //Confirmation des journées sélectionnées
        private void buttonConfirmerJournees_Click(object sender, RoutedEventArgs e)
        {
            //Création du nombre d'équipes saisi pour la catégorie
            for (int i = 0; i < nbEquipes; i++)
            {
                MainWindow.equipes.Add(new Equipe(0, categorie, i));
            }
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
            //Création des journées sélectionnées pour la catégorie
            foreach (Journee journee in journees)
            {
                MainWindow.journees.Add(journee);
            }
            journees = new List<Journee>();
            dataGridRecapJournees.Items.Refresh();
            textBoxNbEquipes.Text = "";
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            gridDateValidationJournees.Visibility = Visibility.Hidden;
        }
        //Annulation des journées sélectionnées
        private void buttonAnnulerJournees_Click(object sender, RoutedEventArgs e)
        {
            journees = new List<Journee>();
            textBoxNbEquipes.Text = "";
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            gridDateValidationJournees.Visibility = Visibility.Hidden;
        }

        
    }
}
