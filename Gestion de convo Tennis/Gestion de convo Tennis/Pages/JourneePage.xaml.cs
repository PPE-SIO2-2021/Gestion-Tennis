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
        public int nbEquipesByCategorie;
        public Boolean validEquipes = false;
        public Boolean validJournees = false;
        Visibility visible = Visibility.Visible;
        Visibility cacher = Visibility.Hidden;
        List<Calendar> calendars = new List<Calendar>();
        Calendar cal = new Calendar();
     
        public JourneePage()
        {
            //INITIALISATION DES AFFICHAGES ET PROPRIETES DES CALENDRIERS
            InitializeComponent();
            gridValidationNbEquipes.Visibility = cacher;
            gridValidationJournees.Visibility = cacher;
            gridCalendrierJournees.Visibility = cacher;
            calendars.Add(calendarDateJourneeSenior);
            calendars.Add(calendarDateJourneeSeniorP);
            foreach (Calendar calendar in calendars)
            {
                calendar.DisplayDateStart = DateTime.Today.AddYears(-1);
                calendar.DisplayDateEnd = DateTime.Today.AddYears(2);
                calendar.Visibility = cacher;
            }
            dataGridRecapJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Categorie).ThenBy(y => y.Date);
        }

    //CONCERNANT LES CATÉGORIES
        //POUR LE BOUTON SENIOR
        private void buttonSelectSenior_Click(object sender, RoutedEventArgs e)
        {
            categorie = "Senior";
            AfficherCalendrier(categorie);
        }

        //POUR LE BOUTON SENIOR + 
        private void buttonSelectSeniorPlus_Click(object sender, RoutedEventArgs e)
        {
            categorie = "Senior +";
            AfficherCalendrier(categorie);
        }

    //CONCERNANT LE NOMBRE D'ÉQUIPES (GRIDVALIDATIONEQUIPES)
        //MODIFICAITON DU NOMBRE D'EQUIPES
        private void textBoxNbEquipes_TextChanged(object sender, TextChangedEventArgs e)
        {
            //GESTION DES ERREURS SUR LE NOMBRE D'EQUIPES
            try
            {
                int nb = Int32.Parse(textBoxNbEquipes.Text);
                if (nb != nbEquipesByCategorie)
                {
                    validEquipes = false;
                }
                else
                {
                    validEquipes = true;
                }
            }
            catch (FormatException)
            {
                if (textBoxNbEquipes.Text != "")
                {
                    labelErreurJournees.Content = "Erreur : Le nombre d'équipe doit être saisi en chiffres.";
                }
            }
        }
        //VALIDATION
        private void buttonValiderNbEquipes_Click(object sender, RoutedEventArgs e)
        {
            //GESTION DES AFFICHAGES
            if (validEquipes == false)
            {
                AfficherConfirmationEquipes();
            }
            else
            {
                labelErreurJournees.Content = "Erreur : Le nombre d'équipes voulu est egal à celui déjà créé";
            }
        }
        //CONFIRMATION
        private void buttonConfirmNbEquipes_Click(object sender, RoutedEventArgs e)
        {
            //RESET DES EQUIPES 
            MainWindow.equipes.RemoveAll(x => x.Categorie.Trim() == categorie);
            //REAJOUT DU NOMBRE D'EQUIPES VOULU
            for (int i = 0; i < nbEquipes; i++)
            {
                MainWindow.equipes.Add(new Equipe(0, categorie, i+1));
            }
            //GESTION ET MISE A JOUR DES AFFICHAGES
            validEquipes = true;
            labelNbEquipes.Content = "Voici le nombre d'équipes pour cette catégorie ";
            nbEquipesByCategorie = MainWindow.equipes.FindAll(x => x.Categorie.Trim() == categorie).Count();
            textBoxNbEquipes.Text = nbEquipesByCategorie.ToString();
            gridValidationNbEquipes.Visibility = cacher;

            if (validJournees == true)
            {
                gridValidationJournees.Visibility = visible;
            }
        }
        //ANNULATION
        private void buttonAnnulerNbEquipes_Click(object sender, RoutedEventArgs e)
        {
            textBoxNbEquipes.Text = nbEquipesByCategorie.ToString();
            nbEquipes = 0;
            gridValidationNbEquipes.Visibility = cacher;
        }

    //CONCERNANT LES JOURNÉES (GRIDVALIDATIONJOURNEES)
        //VALIDATION DES JOURNÉES SÉLECTIONNÉES
        private void buttonValiderJournees_Click(object sender, RoutedEventArgs e)
        {
            //PAS DE MODIFICATIONS SI AUCUNE JOURNEE N'EST SELECTIONNEE
            int nbjournees = cal.SelectedDates.Count();
            if (nbjournees <= 0)
            {
                labelErreurJournees.Content = "Erreur : aucune journée n'est sélectionnée.";
            }
            else
            {
                //ON PASSE A LA VALIDATION DES JOURNEE SI LA VALIDATION D'EQUIPE A ETE FAITE
                if (validEquipes == false)
                {
                    validJournees = true;
                    AfficherConfirmationEquipes();
                }
                else if(validEquipes == true || nbEquipes == nbEquipesByCategorie)
                {
                    gridValidationJournees.Visibility = visible;
                }
                dataGridRecapValidationJournees.ItemsSource = cal.SelectedDates.OrderBy(x => x.Date);
            }
        }
        //CONFIRMATION
        private void buttonConfirmerJournees_Click(object sender, RoutedEventArgs e)
        {
            //AJOUT DES DATES SELECTIONNEES DANS LA LISTE PRINCIPALE
            foreach (DateTime date in cal.SelectedDates)
            {
                MainWindow.journees.Add(new Journee(0, date, categorie));
            }

            //GESTION ET MISE A JOUR DES AFFICHAGES
            BlockerJourneeCalendrier(categorie);
            dataGridRecapJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Categorie).ThenBy(y => y.Date);
            gridValidationJournees.Visibility = cacher;
        }
        //ANNULATION
        private void buttonAnnulerJournees_Click(object sender, RoutedEventArgs e)
        {
            gridValidationJournees.Visibility = cacher;
            validJournees = false;
        }
        //SUPPRESSION
        private void buttonSupprimerJournee_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.journees.Remove((Journee)dataGridRecapJournees.SelectedItem);
            dataGridRecapJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Categorie).ThenBy(y => y.Date);
            BlockerJourneeCalendrier(categorie);
        }

    // FONCTIONS DRY
        public void AfficherCalendrier(string cat)
        {
            //AFFICHAGE DU CALENDRIER SELON LA CATEGORIE
            if (cat == "Senior")
            {
                calendars[0].Visibility = visible;
                calendars[1].Visibility = cacher;
                cal = calendars[0];
            }
            else if (cat == "Senior +")
            {
                calendars[1].Visibility = visible;
                calendars[0].Visibility = cacher;
                cal = calendars[1];
            }

            //GESTION ET MISE A JOUR DES AFFICHAGES SELON LA CATEGORIE
            BlockerJourneeCalendrier(categorie);
            gridCalendrierJournees.Visibility = visible;
            nbEquipesByCategorie = MainWindow.equipes.FindAll(x => x.Categorie.Trim() == cat).Count();
            dataGridRecapJournees.ItemsSource = MainWindow.journees.FindAll(x => x.Categorie == cat);

            labelTitreJournee.Content = "SAISIE DES JOURNEES " + cat.ToUpper();
            if (nbEquipesByCategorie == 0)
            {
                validEquipes = false;
                labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie " + cat;
                textBoxNbEquipes.Text = "";
            }
            else
            {
                validEquipes = true;
                labelNbEquipes.Content = "Voici le nombre d'équipes pour la catégorie " + cat;
                textBoxNbEquipes.Text = nbEquipesByCategorie.ToString();
            }
        }
        public void AfficherConfirmationEquipes()
        {
            //AFFICHAGE DU POP-UP DE CHANGEMENT DE NOMBRE D'EQUIPES
            try
            {
                nbEquipes = Int32.Parse(textBoxNbEquipes.Text);
                if (nbEquipes > 0 && nbEquipes != nbEquipesByCategorie)
                {
                    gridValidationNbEquipes.Visibility = visible;
                    labelValidationNbEquipes.Content = "Vous allez créer " + nbEquipes + " équipes.";
                    labelErreurJournees.Content = "";
                }
                else if (nbEquipes <= 0) //GESTION DES ERREURS
                {
                    labelErreurJournees.Content = "Erreur : Le nombre d'équipes doit être supérieur à 0.";
                    textBoxNbEquipes.Text = "";
                }
                else if(nbEquipes != nbEquipesByCategorie)
                {
                    labelErreurJournees.Content = "Erreur : Le nombre d'équipes voulu est egal à celui déjà créé";
                }
            }
            catch (FormatException)
            {
                labelErreurJournees.Content = "Erreur : Le nombre d'équipe doit être saisi en chiffres.";
                textBoxNbEquipes.Text = "";
            }
        }
        public void BlockerJourneeCalendrier(String cat)
        { 
            //GESTION DES DATES BLOQUEES DANS LES CALENDRIERS
            cal.SelectedDates.Clear();
            cal.BlackoutDates.Clear();
            cal.BlackoutDates.AddDatesInPast();
            foreach (Journee journee in MainWindow.journees.FindAll(x => x.Categorie.Trim() == cat))
            {
                cal.BlackoutDates.Add(new CalendarDateRange(journee.Date));
            }
        }
    }
}