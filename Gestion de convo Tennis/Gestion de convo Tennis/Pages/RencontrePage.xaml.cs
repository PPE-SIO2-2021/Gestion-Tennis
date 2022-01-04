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
    /// Logique d'interaction pour RencontrePage.xaml
    /// </summary>
    public partial class RencontrePage : Page
    {
        public RencontrePage()
        {
            InitializeComponent();
            dataGridAffichageJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Date);
        }

        private void dataGridAffichageJournees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Journee journee = (Journee)dataGridAffichageJournees.SelectedItem;
            dataGridAffichageJoueursJournee.ItemsSource = journee.Dispo.Keys;
            int nbrEquipe = MainWindow.equipes.FindAll(x => x.Categorie == journee.Categorie).Count();
            stackPanelRencontre.Children.Clear();
            stackPanelToEquipe.Children.Clear();
            // Création des différents éléments
            for (int i = 0; i < nbrEquipe; i++)
            {
                // Création des différents éléments
                Grid grid = new Grid();
                Grid gridAdv = new Grid();
                Grid gridDateHeure = new Grid();
                Grid gridLieu = new Grid();
                DataGrid gridJoueur = new DataGrid();
                Label lbl = new Label();
                Label lbl2 = new Label();
                Label lbl3 = new Label();
                TextBox txtb = new TextBox();
                TextBox txtb2 = new TextBox();
                TextBox txtb3 = new TextBox();
                var B1 = new Border();

                // Mise en place des settings
                gridAdv.Width = 255;
                gridAdv.Height = 30;
                gridAdv.VerticalAlignment = VerticalAlignment.Center;
                gridAdv.Margin = new Thickness(0, -80, 0, 0);

                gridLieu.Width = 255;
                gridLieu.Height = 30;
                gridLieu.Margin = new Thickness(0, -20, 0, 0);
                gridLieu.VerticalAlignment = VerticalAlignment.Center;

                gridDateHeure.Width = 255;
                gridDateHeure.Height = 30;
                gridDateHeure.VerticalAlignment = VerticalAlignment.Center;
                gridDateHeure.Margin = new Thickness(0, 40, 0, 0);

                gridJoueur.VerticalAlignment = VerticalAlignment.Center;
                gridJoueur.Margin = new Thickness(0, 100, 0, 10);
                gridJoueur.Width = 255;
                gridJoueur.Height = Double.NaN;

                // Grid joueur 
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = "Joueur";
                textColumn.Binding = new Binding("Joueur");
                textColumn.Width = 50;
                DataGridTextColumn textColumn1 = new DataGridTextColumn();
                textColumn1.Header = "Rang";
                textColumn1.Binding = new Binding("Rang");
                textColumn1.Width = 50;
                gridJoueur.Columns.Add(textColumn);
                gridJoueur.Columns.Add(textColumn1);


                // Label Adversaire
                lbl.Content = "Adversaire : ";
                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                gridAdv.Children.Add(lbl);

                // Label Lieux
                lbl2.HorizontalAlignment = HorizontalAlignment.Left;
                lbl2.Content = "Lieux : ";
                gridLieu.Children.Add(lbl2);


                // Label Lieux
                lbl3.HorizontalAlignment = HorizontalAlignment.Left;
                lbl3.Content = "Heure : ";
                gridDateHeure.Children.Add(lbl3);

                // Bordure de la Grid
                B1.BorderBrush = Brushes.Gray;
                B1.BorderThickness = new Thickness(2);
                B1.CornerRadius = new CornerRadius(15);
                // Ajout des grid
                grid.Children.Add(B1);
                grid.Children.Add(gridAdv);
                grid.Children.Add(gridLieu);
                grid.Children.Add(gridDateHeure);
                grid.Children.Add(gridJoueur);

                // TextBox Adversaire
                txtb.Height = 20;
                txtb.Width = 150;
                txtb.Text = "";
                txtb.HorizontalAlignment = HorizontalAlignment.Right;
                txtb.HorizontalContentAlignment = HorizontalAlignment.Left;
                txtb.VerticalContentAlignment = VerticalAlignment.Center;
                gridAdv.Children.Add(txtb);

                // TextBox Lieux
                txtb2.Height = 20;
                txtb2.Width = 150;
                txtb2.HorizontalAlignment = HorizontalAlignment.Right;
                txtb2.Text = "";
                txtb2.HorizontalContentAlignment = HorizontalAlignment.Left;
                txtb2.VerticalContentAlignment = VerticalAlignment.Center;
                gridLieu.Children.Add(txtb2);

                // TextBox Lieux
                txtb3.Height = 20;
                txtb3.Width = 150;
                txtb3.HorizontalAlignment = HorizontalAlignment.Right;
                txtb3.Text = "";
                txtb3.HorizontalContentAlignment = HorizontalAlignment.Left;
                txtb3.VerticalContentAlignment = VerticalAlignment.Center;
                gridDateHeure.Children.Add(txtb3);

                // Grid
                grid.Height = Double.NaN;
                grid.Width = 275;
                grid.Background = new SolidColorBrush(Colors.LightGray);
                grid.Margin = new Thickness(0, 0, 0, 10);
                stackPanelRencontre.Children.Add(grid);

                Button btn = new Button();
                btn.Height = 20;
                btn.Width = 50;
                btn.Content = i + 1;
                btn.Click += new RoutedEventHandler(btn_Clicked);
                stackPanelToEquipe.Children.Add(btn);
            }
        }
        private void btn_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int nbrChild = (int)button.Content - 1;
            Grid grid = (Grid)stackPanelRencontre.Children[nbrChild];
            DataGrid joueurs = (DataGrid)grid.Children[4];
            Joueur player = (Joueur)dataGridAffichageJoueursJournee.SelectedItem;
            Journee j = MainWindow.journees[dataGridAffichageJournees.SelectedIndex];
            j.addRencontre();
            j.Rencontres[nbrChild].Joueurs.Add(player);

            joueurs.ItemsSource = null;
            joueurs.ItemsSource = MainWindow.journees[dataGridAffichageJournees.SelectedIndex].Rencontres[nbrChild].Joueurs;

        }

        private void dataGridAffichageJoueursJournee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
