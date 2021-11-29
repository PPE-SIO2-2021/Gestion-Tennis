
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
        bool state = false;
        Joueur j = new Joueur();
        public JoueurPage()
        {
            InitializeComponent();
            comboBoxClassementJoueur.ItemsSource = MainWindow.classements;
            dataGridRecapJoueurs.ItemsSource = MainWindow.joueurs;
        }

        private void buttonValiderJoueur_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("j",j);
            Console.WriteLine("NEW",new Joueur());
            Console.WriteLine("test" + (j != new Joueur()));
            Console.WriteLine("test2" + (j == new Joueur()));
            string categorie = "";
            if (state)
            {
                j.Nom = textBoxNomJoueur.Text;
                j.Prenom = textBoxPrenomJoueur.Text;
                j.Mail = textBoxMailJoueur.Text;
                j.Age = Convert.ToInt32(textBoxAgeJoueur.Text);
                if (j.Age < 35)
                {
                    categorie = "Senior";
                }
                else
                {
                    categorie = "Senior +";
                }
                j.Categorie = categorie;
                MainWindow.joueurs.Find(
                    delegate (Joueur jou)
                    {
                        return jou.Id == j.Id;
                    });
            }
            else
            {
                labelErreurJoueur.Content = "";
                int age = Int32.Parse(textBoxAgeJoueur.Text);
                Joueur joueur = new Joueur();
                Console.WriteLine("0");
                if (age < 35)
                {
                    categorie = "Senior";
                }
                else
                {
                    categorie = "Senior +";
                }
                Console.WriteLine("1");
                if (comboBoxClassementJoueur.SelectedItem == null)
                {
                    joueur = new Joueur(0, textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, "", "", categorie);
                }
                else
                {
                    joueur = new Joueur(0, textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, "", "", categorie, (Classement)comboBoxClassementJoueur.SelectedItem);
                }
                Console.WriteLine("2");
                MainWindow.joueurs.Add(joueur);
            }
            dataGridRecapJoueurs.Items.Refresh();
            unloadFormJoueur();
        }
        private void unloadFormJoueur()
        {
            textBoxNomJoueur.Text = "";
            textBoxPrenomJoueur.Text = "";
            textBoxMailJoueur.Text = "";
            textBoxAgeJoueur.Text = "";
            comboBoxClassementJoueur.SelectedIndex = -1;
            dataGridRecapJoueurs.Items.Refresh();
        }

        private void buttonValiderJoueurs_Click(object sender, RoutedEventArgs e)
        {
            dataGridRecapJoueurs.Items.Refresh();
        }

        
        private void dataGridRecapJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            state = true;
            j = (Joueur)dataGridRecapJoueurs.SelectedItem;
            labelcreerunjoueur.Content = "MODIFIER UN JOUEUR";
            textBoxNomJoueur.Text = j.Nom;
            textBoxPrenomJoueur.Text = j.Prenom;
            textBoxMailJoueur.Text = j.Mail;
            textBoxAgeJoueur.Text = Convert.ToString(j.Age);
        }
        private void buttonResetJoueur_Click(object sender, RoutedEventArgs e)
        {
            unloadFormJoueur();
        }
    }
}
