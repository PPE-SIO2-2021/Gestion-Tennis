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
    /// Logique d'interaction pour VuePage.xaml
    /// </summary>
    public partial class VuePage : Page
    {
        public VuePage()
        {
            InitializeComponent();
            dataGridAffichageJournees.ItemsSource = MainWindow.journees.OrderBy(x => x.Date);

        }

        private void dataGridAffichageJournees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Journee journee = (Journee)dataGridAffichageJournees.SelectedItem;
            dataGridAffichageRencontresJournee.ItemsSource = journee.Rencontres;

        }

        private void dataGridAffichageRencontresJournee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Rencontre rencontre = (Rencontre)dataGridAffichageRencontresJournee.SelectedItem;
            dataGridRecapJoueursRencontre.ItemsSource = rencontre.Joueurs;
        }

        private void dataGridRecapJoueursRencontre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
