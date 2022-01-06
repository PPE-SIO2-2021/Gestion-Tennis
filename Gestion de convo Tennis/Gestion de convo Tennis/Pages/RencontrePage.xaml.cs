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
        // Importation des ressources de style
        ResourceDictionary bordureStyle = (ResourceDictionary)Application.LoadComponent(new Uri("Ressources/BorderFormulaireRessource.xaml", UriKind.Relative));
        ResourceDictionary buttonStyle = (ResourceDictionary)Application.LoadComponent(new Uri("Ressources/ButtonRessource.xaml", UriKind.Relative));
        ResourceDictionary dataGridStyle = (ResourceDictionary)Application.LoadComponent(new Uri("Ressources/DataGridRessource.xaml", UriKind.Relative));
        ResourceDictionary labelTitreStyle = (ResourceDictionary)Application.LoadComponent(new Uri("Ressources/LabelTitreRessource.xaml", UriKind.Relative));
        ResourceDictionary textBoxStyle = (ResourceDictionary)Application.LoadComponent(new Uri("Ressources/TextBoxRessource.xaml", UriKind.Relative));

        int nbrEquipe;

        public RencontrePage()
        {
            InitializeComponent();
            dataGridAffichageJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Date);
        }

        private void dataGridAffichageJournees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Journee journee = (Journee)dataGridAffichageJournees.SelectedItem;
            dataGridAffichageJoueursJournee.ItemsSource = null;
            nbrEquipe = MainWindow.equipes.FindAll(x => x.Categorie == journee.Categorie).Count();
            dataGridAffichageJoueursJournee.ItemsSource = journee.Dispo.Keys;
            stackPanelRencontre.Children.Clear();
            stackPanelButtonEquipe.Children.Clear();

            // Création des différents éléments
            for (int numEquipe = 0; numEquipe < nbrEquipe; numEquipe++)
            {
                int nbLignes = 5;
                // Création des différents éléments
                Border borderEquipe = AjoutBordureStackPanel();
                Grid grid = AjouterGrilleBordure(borderEquipe, nbLignes);
                AjouterTitreGrille(numEquipe, grid);
                AjouterLabelGrille(grid, 1, 1, "Adversaire");
                AjouterTextBoxGrille(grid, 1, 2);
                AjouterLabelGrille(grid, 2, 1, "Date");
                AjouterTextBoxGrille(grid, 2, 2);
                AjouterLabelGrille(grid, 3, 1, "Lieu");
                AjouterTextBoxGrille(grid, 3, 2);
                DataGrid dataGrid = AjouterDataGridGrille(grid, nbLignes, 1);
                AjouterButtonStackPanel(stackPanelButtonEquipe, numEquipe);
                try
                {
                    dataGrid.ItemsSource = MainWindow.journees[dataGridAffichageJournees.SelectedIndex].Rencontres[numEquipe].Joueurs;
                }
                catch (Exception error)
                {
                    Console.WriteLine("Aucune rencontre n'existe", error);
                }
            }
        }

        private Border AjoutBordureStackPanel()
        {
            // CREATION DE LA BORDURE D'UN FORMULAIRE RENCONTRE
            var border = new Border();
            border.Style = (Style)bordureStyle["BorderFormulaire"];
            border.Margin = new Thickness(0, 10, 0, 0);
            border.MaxWidth = 400;
            border.MinHeight = 150;
            stackPanelRencontre.Children.Add(border);
            return border;
        }

        private Grid AjouterGrilleBordure(Border border, int nbLigne)
        {
            // AJOUT D'UNE GRILLE DANS UN FORMULAIRE RENCONTRE
            Grid grid = new Grid();
            border.Child = grid;
            for (int i = 0; i <= 4; i++)
            {
                // 4 colonnes
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                // la première et la dernière colonne font office de marge
                if (i == 0 || i >= 3)
                {
                    grid.ColumnDefinitions[i].Width = new GridLength(50);
                }
            }
            for (int i = 0; i < nbLigne; i++)
            {
                // Nombre de lignes selon le nombre de champs
                grid.RowDefinitions.Add(new RowDefinition());

            }
            return grid;
        }

        private void AjouterTitreGrille(int numEquipe, Grid grid)
        {
            // AJOUT DU TITRE A LA GRILLE
            Label titre = new Label();
            grid.Children.Add(titre);
            Grid.SetColumnSpan(titre, 4);
            titre.Content = "Rencontre n°" + (numEquipe+1);
            titre.Style = (Style)labelTitreStyle["LabelTitre"];
        }

        private void AjouterLabelGrille(Grid grid, int row, int column, String content)
        {
            // AJOUT DU LABEL ADVERSAIRE A LA GRILLE
            Label label = new Label();
            grid.Children.Add(label);
            Grid.SetRow(label, row);
            Grid.SetColumn(label, column);
            label.Content = content + " : ";
            label.Style = (Style)labelTitreStyle["LabelTitre"];
        }

        private void AjouterTextBoxGrille(Grid grid, int row, int column)
        {
            // AJOUT DE LA TEXTBOX ADVERSAIRE A LA GRILLE
            TextBox textBox = new TextBox();
            grid.Children.Add(textBox);
            Grid.SetRow(textBox, row);
            Grid.SetColumn(textBox, column);
            Grid.SetColumnSpan(textBox, 2);
            textBox.Style = (Style)textBoxStyle["TextBoxStyle"];
        }

        private DataGrid AjouterDataGridGrille(Grid grid, int row, int column)
        {
            DataGrid dataGrid = new DataGrid();
            dataGrid.Columns.Add(AjouterColonneDataGrid("Nom", "Nom"));
            dataGrid.Columns.Add(AjouterColonneDataGrid("Prénom", "Prenom"));
            dataGrid.Columns.Add(AjouterColonneDataGrid("Classement", "Classement"));
            dataGrid.MinHeight = 80;
            dataGrid.Margin = new Thickness(0,10,0,10);
            grid.Children.Add(dataGrid);
            Grid.SetRow(dataGrid, row);
            Grid.SetColumn(dataGrid, column);
            Grid.SetColumnSpan(dataGrid, 3);
            dataGrid.Style = (Style)dataGridStyle["DataGridStyle"];
            return dataGrid;
        }

        private DataGridTextColumn AjouterColonneDataGrid(string columnTitre, string binding)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = columnTitre;
            textColumn.Binding = new Binding(binding);
            textColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            return textColumn;
        }

        private void AjouterButtonStackPanel(StackPanel stackPanel, int numEquipe)
        {
            Button buttonNumEquipe = new Button();
            stackPanel.Children.Add(buttonNumEquipe);
            buttonNumEquipe.Click += new RoutedEventHandler(buttonNumEquipe_Clicked);
            buttonNumEquipe.Style = (Style)buttonStyle["ButtonStyle"];
            buttonNumEquipe.Width = 30;
            buttonNumEquipe.Content = numEquipe + 1;
        }

        private void buttonNumEquipe_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int nbrChild = (int)button.Content - 1;
            Border border = (Border)(stackPanelRencontre.Children[nbrChild]);
            Grid grid = (Grid)border.Child;
            DataGrid joueurs = (DataGrid)grid.Children[7];
            Joueur player = (Joueur)dataGridAffichageJoueursJournee.SelectedItem;
            Journee j = MainWindow.journees[dataGridAffichageJournees.SelectedIndex];
            j.addRencontre();
            Boolean b = MainWindow.journees[dataGridAffichageJournees.SelectedIndex].Rencontres[nbrChild].Joueurs.Contains(player);
            Boolean a = true;
            if (!b)
            {
                Journee journee = (Journee)dataGridAffichageJournees.SelectedItem;
                nbrEquipe = MainWindow.equipes.FindAll(x => x.Categorie == journee.Categorie).Count();
                for (int numEquipe = 0; numEquipe < nbrEquipe; numEquipe++)
                {
                    try
                    {
                        if (MainWindow.journees[dataGridAffichageJournees.SelectedIndex].Rencontres[numEquipe].Joueurs.Contains(player))
                        {
                            a = false;
                            System.Windows.MessageBox.Show("Le joueur est déjà dans une équipe", "Erreur");
                        }
                    }
                    catch (Exception  errror)
                    {
                        Console.WriteLine("Aucune rencontre n'ex", errror);
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Le joueur a déjà été ajouté à l'équipe", "Erreur");
                a = false;
            }
            if (a)
            {
                j.Rencontres[nbrChild].Joueurs.Add(player);

            }

            joueurs.ItemsSource = null;
           
            joueurs.ItemsSource = MainWindow.journees[dataGridAffichageJournees.SelectedIndex].Rencontres[nbrChild].Joueurs;

        }

        private void dataGridAffichageJoueursJournee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
