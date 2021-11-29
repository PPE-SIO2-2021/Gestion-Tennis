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
        String categorie;
        Joueur joueur = new Joueur();
        Journee journee = new Journee();
        public DispoPage()
        {
            InitializeComponent();
            dataGridAffichageJoueurs.ItemsSource = MainWindow.joueurs;
        }

        private void dataGridAffichageJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            joueur = (Joueur)dataGridAffichageJoueurs.SelectedItem;
            categorie = joueur.Categorie.ToString();
            AffichagesJournees();
        }

        private void checkBoxDispo_Unchecked(object sender, RoutedEventArgs e)
        {
            journee = (Journee)dataGridRecapJourneesJoueur.SelectedItem;
            journee.Dispo.Remove(joueur);
            AffichagesJournees();            
        }

        private void checkBoxDispo_Checked(object sender, RoutedEventArgs e)
        {
            journee = (Journee)dataGridAffichageJournees.SelectedItem;
            journee.Dispo.Add(joueur, true);
            AffichagesJournees();
        }

        private void AffichagesJournees()
        {
            //AFFICHAGE DES JOURNEES OU LE JOUEUR N'EST PAS DISPONIBLE FILTRER SELON LA CATEGORIE
            if (categorie == "Senior")
            {
                dataGridAffichageJournees.ItemsSource = MainWindow.journees.Where(
                    x => !x.Dispo.ContainsKey(joueur) && x.Categorie == categorie
                    ).OrderBy(x => x.Date);
            }
            else if (categorie == "Senior +")
            {
                dataGridAffichageJournees.ItemsSource = MainWindow.journees.Where(
                    x => !x.Dispo.ContainsKey(joueur)
                    ).OrderBy(x => x.Categorie).ThenBy(x => x.Date);
            }

            //AFFICHAGE DES JOURNEES OU LE JOUEUR EST DISPONIBLE
            dataGridRecapJourneesJoueur.ItemsSource = MainWindow.journees.Where(
                x => x.Dispo.ContainsKey(joueur));
        }
    }
}