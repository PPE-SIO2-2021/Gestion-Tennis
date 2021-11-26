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
        public int nbEquipeCategorie;
        public Boolean validEquipes;
        List<Journee> journees = new List<Journee>();
     
        public JourneePage()
        {
            InitializeComponent();
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
            gridDateValidationJournees.Visibility = Visibility.Hidden;
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            dataGridRecapJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Categorie).ThenBy(y => y.Date);
        }

    //CONCERNANT LES CATÉGORIES
        //POUR LE BOUTON SENIOR
        private void buttonSelectSenior_Click(object sender, RoutedEventArgs e)
        {
            categorie = "Senior";
            AfficherGridNbEquipes(categorie);
            SortJourneesByCategorie(categorie);
            nbEquipeCategorie = FiltrerEquipeCategorie(categorie);
        }

        //POUR LE BOUTON SENIOR + 
        private void buttonSelectSeniorPlus_Click(object sender, RoutedEventArgs e)
        {
            categorie = "Senior +";
            AfficherGridNbEquipes(categorie);
            SortJourneesByCategorie(categorie);
            nbEquipeCategorie = FiltrerEquipeCategorie(categorie);
        }

        //VALIDATION DES SAISIES
        private void buttonValiderJournees_Click(object sender, RoutedEventArgs e)
        {
            validEquipes = false;
            if (calendarDateJournee.SelectedDates.Count() == 0)
            {
                labelErreurJournees.Content = "Aucune date sélectionnée. Saisissez des dates !";
            }
            else if (categorie == "")
            {
                labelErreurJournees.Content = "Aucune catégorie sélectionnée !";
            }
            else
            {
                if (nbEquipeCategorie != nbEquipes)
                {
                    AfficherGridValiderNbEquipes(categorie);
                }
                else
                {   
                    gridDateValidationJournees.Visibility = Visibility.Visible;
                    foreach (DateTime date in calendarDateJournee.SelectedDates)
                    {
                        journees.Add(new Journee(0, date, categorie));
                    }
                }
            }
        }

    //CONCERNANT LE NOMBRE D'ÉQUIPES (GRIDVALIDATIONEQUIPES)
        //CONFIRMATION DU NOMBRE D'ÉQUIPES
        private void buttonValiderNbEquipes_Click(object sender, RoutedEventArgs e)
        {
            validEquipes = true;
            AfficherGridValiderNbEquipes(categorie);
        }
        private void buttonConfirmNbEquipes_Click(object sender, RoutedEventArgs ev)
        {
            if (validEquipes == true)
            {
                MainWindow.equipes.RemoveAll(
                    delegate (Equipe e)
                    {
                        return e.Categorie == categorie;
                    });
                for (int i = 0; i < nbEquipes; i++)
                {
                    MainWindow.equipes.Add(new Equipe(0, categorie, i));
                }
                gridValidationNbEquipes.Visibility = Visibility.Hidden;
            }
            else if (validEquipes == false)
            {
                //AJOUT DES JOURNÉES DANS UNE COLLECTION
                MainWindow.equipes = new List<Equipe>();
                for (int i = 0; i < nbEquipes; i++)
                {
                    MainWindow.equipes.Add(new Equipe(0, categorie, i));
                }
                gridValidationNbEquipes.Visibility = Visibility.Hidden;
                gridDateValidationJournees.Visibility = Visibility.Visible;
                foreach (DateTime date in calendarDateJournee.SelectedDates)
                {
                    journees.Add(new Journee(0, date, categorie));
                }
            }
            
            dataGridRecapValidationJournees.ItemsSource = journees.OrderBy(x => x.Date);
            dataGridRecapJournees.Items.Refresh();
        }
        //ANNULATION DU NOMBRE D'ÉQUIPES
        private void buttonAnnulerNbEquipes_Click(object sender, RoutedEventArgs e)
        {
            if (nbEquipes <= 0)
            {
                textBoxNbEquipes.Text = "";
            }
            nbEquipes = 0;
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
        }

    //CONCERNANT LES JOURNÉES (GRIDVALIDATIONJOURNEES)
        //CONFIRMATION DES JOURNÉES SÉLECTIONNÉES
        private void buttonConfirmerJournees_Click(object sender, RoutedEventArgs e)
        {
            //CRÉATION DU NOMBRE D'ÉQUIPES SAISI POUR LA CATÉGORIE
            for (int i = 0; i < nbEquipes; i++)
            {
                MainWindow.equipes.Add(new Equipe(0, categorie, i));
            }
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
            //CRÉATION DES JOURNÉES SÉLECTIONNÉES POUR LA CATÉGORIE
            foreach (Journee journee in journees)
            {
                MainWindow.journees.Add(journee);
            }
            journees = new List<Journee>();
            dataGridRecapJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Categorie).ThenBy(y => y.Date);
            textBoxNbEquipes.Text = "";
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            gridDateValidationJournees.Visibility = Visibility.Hidden;
        }
        //ANNULATION DES JOURNÉES SÉLECTIONNÉES
        private void buttonAnnulerJournees_Click(object sender, RoutedEventArgs e)
        {
            journees = new List<Journee>();
            textBoxNbEquipes.Text = "";
            gridValidationNbEquipes.Visibility = Visibility.Hidden;
            gridCalendrierJournees.Visibility = Visibility.Hidden;
            gridDateValidationJournees.Visibility = Visibility.Hidden;
        }

    // FONCTIONS DRY
        private void SortJourneesByCategorie(String cat)
        {
            dataGridRecapJournees.ItemsSource = MainWindow.journees.FindAll(
            delegate (Journee j)
            {
                return j.Categorie == cat;
            }).OrderBy(x => x.Date);
            dataGridRecapJournees.Items.Refresh();
        }
        public int FiltrerEquipeCategorie(String cat)
        {
            int nbEquipesBD = MainWindow.equipes.FindAll(
                delegate (Equipe e)
                {
                    return e.Categorie == cat;
                }).Count();
            return nbEquipesBD;
        }
        private void AfficherGridNbEquipes(String cat)
        {
            int nbEquipesBD = FiltrerEquipeCategorie(cat);

            labelTitreJournee.Content = "SAISIE DES JOURNEES " + cat;

            if (nbEquipesBD > 0)
            {
                labelNbEquipes.Content = "Vous avez inscris ce nombre d'équipe pour la catégorie " + cat ;
                textBoxNbEquipes.Text = nbEquipesBD.ToString();
            }
            else
            {
                labelNbEquipes.Content = "Saisissez le nombre d'équipes pour la catégorie " + cat + " :";
                textBoxNbEquipes.Text = "";
            }

            gridCalendrierJournees.Visibility = Visibility.Visible;
        }
        private void AfficherGridValiderNbEquipes(String cat)
        {
            try
            {
                labelErreurJournees.Content = "";
                nbEquipes = Int32.Parse(textBoxNbEquipes.Text);
                if (nbEquipes != 0)
                {
                    gridValidationNbEquipes.Visibility = Visibility.Visible;
                    labelValidationNbEquipes.Content = "Vous allez creer " + nbEquipes + " equipes pour la categorie " + cat + ".";
                }
                else
                {
                    labelErreurJournees.Content = "Le nombre d'équipe indiqué est nul. Saisissez un chiffre non-null.";
                }
            }
            catch (FormatException exception)
            {
                labelErreurJournees.Content = exception.Message;
            }
        }
    }
}
