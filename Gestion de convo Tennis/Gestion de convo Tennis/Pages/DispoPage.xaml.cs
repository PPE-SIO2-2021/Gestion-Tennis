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
    /// Logique d'interaction pour DispoPage.xaml
    /// </summary>
    public partial class DispoPage : Page
    {
        Joueur joueur = new Joueur();
        List<Journee> journees = MainWindow.journees;
        List<Journee> journeesSenior = MainWindow.journees.FindAll(
            delegate(Journee j)
            {
                return j.Categorie == "Senior";
            });

        public DispoPage()
        {
            InitializeComponent();
            dataGridAffichageJoueurs.ItemsSource = MainWindow.joueurs;
        }
        
    //Concernant la sélection d'un joueur
        private void dataGridAffichageJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Affichage du joueur sélectionné dans gridRecapJoueur
            joueur = (Joueur)dataGridAffichageJoueurs.SelectedItem;
            labelNomJoueur.Content = "Nom : " + joueur.Nom;
            labelPrenomJoueur.Content = "Prenom : " + joueur.Prenom;
            labelAgeJoueur.Content = "Age : " + joueur.Age;
            labelCategorieJoueur.Content = "Categorie : " + joueur.Categorie;
            labelClassementJoueur.Content = "Classement : " + joueur.Classement.Rang;
            

            //Filtre de dataGridAffichageJournees selon la catégorie du joueur
            if (joueur.Categorie.Trim() != "Senior")
            {
                dataGridAffichageJournees.ItemsSource = MainWindow.journees;
                AffichageDisposJoueur(MainWindow.journees);
            }
            else
            {
                dataGridAffichageJournees.ItemsSource = journeesSenior;
                AffichageDisposJoueur(journeesSenior);
            }

            dataGridRecapJourneesJoueur.Items.Refresh();  
            dataGridAffichageJournees.Items.Refresh();
        }
        
        private void CheckBoxIsDispo(object sender, RoutedEventArgs e)
        {
            Journee journee = (Journee)dataGridAffichageJournees.SelectedItem;
            journee.Dispo.Add(joueur, true);
            int index = MainWindow.journees.FindIndex(x => x.Id == journee.Id);
            MainWindow.journees[index] = journee;

        }
        private void CheckBoxIsNotDispo(object sender, RoutedEventArgs e)
        {

        }

        public void AffichageDisposJoueur(List<Journee> journees)
        {
            List<Journee> j = new List<Journee>();
            bool disponible = true;
            foreach (Journee journee in journees)
            {
                if (journee.Dispo.TryGetValue(joueur, out disponible))
                {
                    j.Add(journee);
                }
            }
            dataGridRecapJourneesJoueur.ItemsSource = j;
        }
    }
}
