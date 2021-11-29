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
            dataGridAffichageJournees.ItemsSource = MainWindow.journees;
        }

        private void dataGridAffichageJournees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Création des différents éléments
            Grid grid = new Grid();
            Grid gridAdv = new Grid();
            Grid gridLieu = new Grid();
            Grid gridJoueur = new Grid();
            Label lbl = new Label();
            Label lbl2 = new Label();
            TextBox txtb = new TextBox();
            TextBox txtb2 = new TextBox();
            var B1 = new Border();

            // Mise en place des settings
            gridAdv.Width = 255;
            gridAdv.Height = 30;
            gridAdv.VerticalAlignment = VerticalAlignment.Center;
            gridLieu.Width = 255;
            gridLieu.Height = 30;
            gridAdv.Margin = new Thickness(0, -20, 0, 0);
            gridLieu.Margin = new Thickness(0, 40, 0, 0);
            gridJoueur.VerticalAlignment = VerticalAlignment.Center;
            gridJoueur.Margin = new Thickness(0, 100, 0,0);
            gridJoueur.Height = 200;
            gridLieu.VerticalAlignment = VerticalAlignment.Center;

            // Label Adversaire
            lbl.Content = "Adversaire : ";
            lbl.HorizontalAlignment = HorizontalAlignment.Left;
            gridAdv.Children.Add(lbl);

                // Label Lieux
            lbl2.HorizontalAlignment = HorizontalAlignment.Left;
            lbl2.Content = "Lieux : ";
            gridLieu.Children.Add(lbl2);

            // Bordure de la Grid
            B1.BorderBrush = Brushes.Gray;
            B1.BorderThickness = new Thickness(2);
            B1.CornerRadius = new CornerRadius(15);
            grid.Children.Add(B1);
            grid.Children.Add(gridAdv);
            grid.Children.Add(gridLieu);
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


            // Grid
            grid.Height = Double.NaN;
            grid.Width = 275;
            grid.Background = new SolidColorBrush(Colors.LightGray);
            grid.Margin = new Thickness(0, 0, 0, 10);
            stackPanelRencontre.Children.Add(grid);
        }
    }
}
