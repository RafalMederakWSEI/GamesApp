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

namespace GamesApp.Pages
{
    /// <summary>
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Page
    {
        public AddGame()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaGierEntities db = new WypozyczalniaGierEntities();

            Gra gameObject = new Gra()
            {
                id_gry = Convert.ToInt32(txtGameId.Text),
                nazwa_gry = txtGameName.Text,
                producent = txtGameProducent.Text,
                kategoria_wiekowa_PEGI = txtGameAgeCategory.Text,
                typ_gry = txtGameType.Text,
                cena = Convert.ToDecimal(txtGamePrice.Text),
                platforma = txtGamePlatform.Text,
            };

            db.Gras.Add(gameObject);
            db.SaveChanges();
            MessageBox.Show("Dodano grę");
        }
    }
}
