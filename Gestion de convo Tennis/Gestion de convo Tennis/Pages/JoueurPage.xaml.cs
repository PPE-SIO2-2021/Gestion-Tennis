using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.AccessControl;
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
using System.Windows.Forms;
using Gestion_de_convo_Tennis.Classes;
using Gestion_de_convo_Tennis.Pages;

namespace Gestion_de_convo_Tennis.Pages
{
    /// <summary>
    /// Logique d'interaction pour JoueurPage.xaml
    /// </summary>
    public partial class JoueurPage : Page 
    {
        bool joueurSupprimer = false; // Permet de gérer une erreur lors de la suppression d'un joueur sélectionné
        bool state = false; // Permet d'indiqué qu'un joueur est sélectionné
        String categorie;
        String certificat = "";
        String licence = "";
        String dossierJoueurs = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\TSATGD_Convocations\Documents_Joueurs";
        String extension;

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

                        AjoutFichiersJoueur();
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
                        if (comboBoxClassementJoueur.SelectedItem == null || comboBoxClassementJoueur.SelectedIndex == -1)
                        {
                            j = new Joueur(textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, categorie);
                        }
                        else
                        {
                            j = new Joueur(textBoxNomJoueur.Text, textBoxPrenomJoueur.Text, age, textBoxMailJoueur.Text, categorie, (Classement)comboBoxClassementJoueur.SelectedItem);
                        }

                        AjoutFichiersJoueur();

                        MainWindow.joueurs.Add(j);
                        j = new Joueur();
                    }
                }

                certificat = "";
                licence = "";
                unloadFormJoueur();
                dataGridRecapJoueurs.Items.Refresh();
            }
            catch (FormatException)
            {
                labelErreurJoueur.Content = "Erreur : L'âge n'est pas au bon format. Saisissez un chiffre.";
            }
        }
        private void buttonSupprimerJoueur_Click(object sender, RoutedEventArgs e)
        {
            state = false;
            joueurSupprimer = true;
            String dossierJoueur = dossierJoueurs + @"\" + j.Nom + "_" + j.Prenom;
            if (j.Certificat != "")
            {
                File.Delete(j.Certificat);
            }
            if (j.Licence != "")
            {
                File.Delete(j.Licence);
            }
            if (Directory.Exists(dossierJoueur))
            {
                Directory.Delete(dossierJoueur);
            }            

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
            state = false;
            j = new Joueur();
            textBoxNomJoueur.Text = "";
            textBoxPrenomJoueur.Text = "";
            textBoxMailJoueur.Text = "";
            textBoxAgeJoueur.Text = "";
            comboBoxClassementJoueur.SelectedIndex = -1;
            labelCertificatJoueur.Content = "";
            labelLicenceJoueur.Content = "";
            certificat = "";
            licence = "";
            labelErreurFichierJoueur.Content = "";
        }
        
        private void dataGridRecapJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unloadFormJoueur();
            labelErreurJoueur.Content = "";
            labelErreurFichierJoueur.Content = "";
            //CHARGEMENT DU FORMULAIRE PAR LES INFOS DU JOUEUR SELECTIONNE
            state = true;
            j = (Joueur)dataGridRecapJoueurs.SelectedItem;
            if (!joueurSupprimer)
            {
                LabelCreerJoueur.Content = "MODIFIER UN JOUEUR";
                textBoxNomJoueur.Text = j.Nom;
                textBoxPrenomJoueur.Text = j.Prenom;
                textBoxMailJoueur.Text = j.Mail;
                textBoxAgeJoueur.Text = j.Age.ToString();
                comboBoxClassementJoueur.SelectedItem = j.Classement;

                if (j.Certificat.Trim() != "")
                {
                    certificat = j.Certificat;
                    labelCertificatJoueur.Content = certificat;
                    labelCertificatJoueur.Foreground = Brushes.Green;
                }
                else
                {
                    certificat = "";
                    labelCertificatJoueur.Content = "Pas de Certificat enregistré.";
                    labelCertificatJoueur.Foreground = Brushes.Red;
                }

                if (j.Licence.Trim() != "")
                {
                    licence = j.Licence;
                    labelLicenceJoueur.Content = licence;
                    labelLicenceJoueur.Foreground = Brushes.Green;
                }
                else
                {
                    licence = "";
                    labelLicenceJoueur.Content = "Pas de License enregistré.";
                    labelLicenceJoueur.Foreground = Brushes.Red;
                }
                joueurSupprimer = false;
            }
        }

        private void buttonResetJoueur_Click(object sender, RoutedEventArgs e)
        {
            //RESET DU FORMULAIRE
            dataGridRecapJoueurs.Items.Refresh();
            unloadFormJoueur();
        }

        private void buttonAjouterCertificat_Click(object sender, RoutedEventArgs e)
        {
            certificat = SelectionFichier("Certificat");
        }

        private void buttonVisualiserCertificat_Click(object sender, RoutedEventArgs e)
        {
            if (state == false && certificat != "")
            {
                Process.Start(certificat);
            }
            else if (state == true && j.Certificat != "")
            {
                Process.Start(j.Certificat);
            }
            else if (certificat == "")
            {
                System.Windows.MessageBox.Show("Pas de Certificat à visualiser", "Erreur");
            }
        }

        private void buttonAjouterLicence_Click(object sender, RoutedEventArgs e)
        {
            licence = SelectionFichier("Licence");
        }

        private void buttonVisualiserLicence_Click(object sender, RoutedEventArgs e)
        {
            if (state = false && licence != "")
            {
                Process.Start(licence);
            }
            else if (state == true && j.Licence != "")
            {
                Process.Start(j.Licence);
            }
            else if (licence == "")
            {
                System.Windows.MessageBox.Show("Pas de Licence à visualiser", "Erreur");
            }
        }

        private String SelectionFichier(string fichier)
        {
            System.Windows.Controls.Label label = FindName("label" + fichier + "Joueur") as System.Windows.Controls.Label;
            OpenFileDialog explorer = new OpenFileDialog();
            if (explorer.ShowDialog() == DialogResult.OK)
            {
                extension = System.IO.Path.GetExtension(explorer.FileName);
                if (extension != ".pdf")
                {
                    labelErreurFichierJoueur.Content = "ERREUR : Le fichier choisit \ndoit être un PDF.";
                    return "";
                }
                else
                {
                    labelErreurFichierJoueur.Content = "";
                    label.Content = explorer.FileName;
                    label.Foreground = Brushes.Green;
                    return explorer.FileName;
                }
            }
            else
            {
                labelErreurFichierJoueur.Content = "ERREUR : L'explorateur n'a pas pû s'ouvrir. \nRecommencez sinon redémarrez l'explorateur.";
                return "";
            }
        }
        private String EnregistrerFichierJoueur(String chemin, String fichier)
        {
            System.Windows.Controls.Label label = FindName("label" + fichier + "Joueur") as System.Windows.Controls.Label;

            if (label.Content == null || label.Content.ToString() == "")
            {
                labelErreurFichierJoueur.Content = "ATTENTION : Le joueur a été \ncréé sans " + fichier;
                return "";
            }
            else
            {
                labelErreurFichierJoueur.Content = "";

                //CHEMINS DES DOSSIERS
                String dossierJoueur = j.Nom + "_" + j.Prenom;
                String cheminFichier = dossierJoueurs + @"\" + dossierJoueur + @"\" + fichier + "_" + dossierJoueur + extension;

                //REGLES DE SECURITE
                DirectorySecurity securityRules = new DirectorySecurity();
                securityRules.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + @"\" + Environment.UserName, FileSystemRights.Read, AccessControlType.Allow));
                securityRules.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + @"\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow));

                //CREATION DU DOSSIER REFERENCE DANS %APPDATA%
                if (!Directory.Exists(dossierJoueurs))
                {
                    Directory.CreateDirectory(dossierJoueurs, securityRules);
                }

                //CREATION DU DOSSIER DU JOUEUR
                if (!Directory.Exists(dossierJoueurs + @"\" + dossierJoueur))
                {
                    Directory.CreateDirectory(dossierJoueurs + @"\" + dossierJoueur);
                }

                //COPY DU FICHIER SELECTIONNE
                File.Copy(chemin, cheminFichier, true);
                return cheminFichier;
            }

        }
        private void AjoutFichiersJoueur()
        {
            //AJOUT DES FICHIERS
            if (certificat != "")
            {
                j.Certificat = EnregistrerFichierJoueur(labelCertificatJoueur.Content.ToString(), "Certificat");
            }
            if (licence != "")
            {
                j.Licence = EnregistrerFichierJoueur(labelLicenceJoueur.Content.ToString(), "Licence");
            }
        }
    }
}
