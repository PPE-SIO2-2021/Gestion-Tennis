using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Gestion_de_convo_Tennis.Pages;
using System.ComponentModel;
using System.Net.Mail;

namespace Gestion_de_convo_Tennis.Pages
{
    /// <summary>
    /// Logique d'interaction pour JoueurPage.xaml
    /// </summary>
    public partial class JoueurPage : Page 
    {
        bool joueurSupprimer = false;
        bool state = false;
        string categorie;
        Joueur j = new Joueur();

        public JoueurPage()
        {
            InitializeComponent();
            comboBoxClassementJoueur.ItemsSource = MainWindow.classements;
            dataGridRecapJoueurs.ItemsSource = MainWindow.joueurs;
        }

        private void buttonValiderJoueur_Click(object sender, RoutedEventArgs e)
        {
            try
            {   //GESTION DES CHAMPS
                if (textBoxNomJoueur.Text == "")
                {
                    labelErreurJoueur.Content = "ERREUR : Le champ " + textBoxNomJoueur.Name + " est vide. Remplissez-le !";
                }
                else if (textBoxPrenomJoueur.Text == "")
                {
                    labelErreurJoueur.Content = "ERREUR : Le champ " + textBoxPrenomJoueur.Name + " est vide. Remplissez-le !";
                }
                else if (textBoxMailJoueur.Text == "")
                {
                    try
                    {
                        MailAddress m = new MailAddress(textBoxMailJoueur.Text);
                        labelErreurJoueur.Content = "ERREUR : Le champ " + textBoxNomJoueur.Name + " est vide. Remplissez-le !";
                    }
                    catch (FormatException)
                    {
                        labelErreurJoueur.Content = "ERREUR : Le texte saisi dans le champ Mail n'est pas au bon format.";
                    }
                }
                else
                {
                    labelErreurJoueur.Content = "";
                    //UPDATE DU JOUEUR SELECTIONNE
                    if (state == true)
                    {
                        j.Nom = textBoxNomJoueur.Text;
                        j.Prenom = textBoxPrenomJoueur.Text;
                        j.Mail = textBoxMailJoueur.Text;
                        j.Age = Int32.Parse(textBoxAgeJoueur.Text);
                        if (j.Age < 35)
                        {
                            j.Categorie = "Senior";
                        }
                        else
                        {
                            j.Categorie = "Senior +";
                        }
                        j.Classement = (Classement)comboBoxClassementJoueur.SelectedItem;
                    }
                    else
                    {
                        //CREATION D'UN JOUEUR
                        labelErreurJoueur.Content = "";
                        int age = Int32.Parse(textBoxAgeJoueur.Text);
                        if (age < 35)
                        {
                            categorie = "Senior";
                        }
                        else
                        {
                            categorie = "Senior +";
                        }
                        //AJOUT EN DIRECTION DE LA DB
                        if (comboBoxClassementJoueur.SelectedItem == null)
                        {
                            MainWindow.joueurs.Add(new Joueur(textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, "", "", categorie));
                        }
                        else
                        {
                            MainWindow.joueurs.Add(new Joueur(textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, "", "", categorie, (Classement)comboBoxClassementJoueur.SelectedItem));
                        }

                    }
                }

                unloadFormJoueur();
                dataGridRecapJoueurs.Items.Refresh();
            }
            catch (FormatException)
            {
                labelErreurJoueur.Content = "Erreur : Le nombre d'équipe doit être saisi en chiffres.";
            }
        }
        private void buttonSupprimerJoueur_Click(object sender, RoutedEventArgs e)
        {
            state = false;
            joueurSupprimer = true;
            foreach (Journee journee in MainWindow.journees)
            {
                if (journee.Dispo.ContainsKey(j))
                {
                    journee.Dispo.Remove(j);
                }
            }
            MainWindow.joueurs.Remove(j);

            unloadFormJoueur();
            dataGridRecapJoueurs.Items.Refresh();
        }

        private void unloadFormJoueur()
        {
            //RESET DU FORMULAIRE
            j = new Joueur();
            textBoxNomJoueur.Text = "";
            textBoxPrenomJoueur.Text = "";
            textBoxMailJoueur.Text = "";
            textBoxAgeJoueur.Text = "";
            comboBoxClassementJoueur.SelectedIndex = -1;
        }
        
        private void dataGridRecapJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //CHARGEMENT DU FORMULAIRE PAR LES INFOS DU JOUEUR SELECTIONNE
            state = true;
            j = (Joueur)dataGridRecapJoueurs.SelectedItem;
            if (!joueurSupprimer)
            {
                labelcreerunjoueur.Content = "MODIFIER UN JOUEUR";
                textBoxNomJoueur.Text = j.Nom;
                textBoxPrenomJoueur.Text = j.Prenom;
                textBoxMailJoueur.Text = j.Mail;
                textBoxAgeJoueur.Text = j.Age.ToString();
                comboBoxClassementJoueur.SelectedItem = j.Classement;
                joueurSupprimer = false;
            }
        }

        private void buttonResetJoueur_Click(object sender, RoutedEventArgs e)
        {
            //RESET DU FORMULAIRE
            unloadFormJoueur();
            dataGridRecapJoueurs.Items.Refresh();
        }
    }
}
