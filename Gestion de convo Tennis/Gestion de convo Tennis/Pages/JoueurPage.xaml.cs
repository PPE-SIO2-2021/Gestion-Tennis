
using Gestion_de_convo_Tennis.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_de_convo_Tennis.Pages
{
    /// <summary>
    /// Logique d'interaction pour JoueurPage.xaml
    /// </summary>
    public partial class JoueurPage : Page 
    {
        public JoueurPage()
        {
            InitializeComponent();
            comboBoxClassementJoueur.ItemsSource = AdoClassement.all();
            dataGridRecapJoueurs.ItemsSource = MainWindow.joueurs;
        }

        private void buttonValiderJoueur_Click(object sender, RoutedEventArgs e)
        {
            //Création du joueur avec gestion des exceptions de conversion
            try
            {
                labelErreurJoueur.Content = "";
                int age = Int32.Parse(textBoxAgeJoueur.Text);
                string categorie = "";
                Joueur joueur = new Joueur();
                if (age < 35)
                {
                    categorie = "Senior";
                }
                else
                {
                    categorie = "Senior +";
                }
                if (comboBoxClassementJoueur.SelectedItem == null)
                {
                    joueur = new Joueur(0, textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, "", "", categorie);
                }
                else
                {
                    joueur = new Joueur(0, textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, "", "", categorie, (Classement)comboBoxClassementJoueur.SelectedItem);
                }
                MainWindow.joueurs.Add(joueur);
                dataGridRecapJoueurs.Items.Refresh();
                unloadFormJoueur();

            }
            catch (FormatException exception)
            {
                labelErreurJoueur.Content = exception.Message;
            }
        }
        private void unloadFormJoueur()
        {
            textBoxNomJoueur.Text = "";
            textBoxPrenomJoueur.Text = "";
            textBoxMailJoueur.Text = "";
            textBoxAgeJoueur.Text = "";
            comboBoxClassementJoueur.SelectedIndex = -1;
        }
    }
}
