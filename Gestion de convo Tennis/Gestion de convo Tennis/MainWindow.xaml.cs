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

namespace Gestion_de_convo_Tennis
{

    public partial class MainWindow
    {
       public MainWindow()
        {
            InitializeComponent();
            this.Content = new JoueurPage();
        }
        private void JoueurPage(object sender, RoutedEventArgs e)
        {
            this.Content = new JoueurPage();
        }
        private void DispoPage(object sender, RoutedEventArgs e)
        {
            this.Content = new DispoPage();
        }
        private void JourneePage(object sender, RoutedEventArgs e)
        {
            this.Content = new JourneePage();
        }
        private void RencontrePage(object sender, RoutedEventArgs e)
        {
            this.Content = new RencontrePage();
        }
        private void VuePage(object sender, RoutedEventArgs e)
        {
            this.Content = new VuePage();
        }
    }
}
