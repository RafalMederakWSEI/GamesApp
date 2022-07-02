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
    /// Interaction logic for GamesList.xaml
    /// </summary>
    public partial class GamesList : Page
    {
        public GamesList()
        {
            InitializeComponent();

            WypozyczalniaGierEntities db = new WypozyczalniaGierEntities();
            var docs = from d in db.Gras select d;

            gridGames.ItemsSource = docs.ToList();
        }

        private void gridGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(gridGames.SelectedIndex >= 0)
            {
                if (gridGames.SelectedItems.Count >= 0)
                {
                    if (gridGames.SelectedItems[0].GetType() == typeof(Gra))
                    {
                        Gra g = (Gra)gridGames.SelectedItems[0];
                        txtGameIdUpdate.Text = Convert.ToString(g.id_gry);
                        txtGameNameUpdate.Text = g.nazwa_gry;
                        txtGameProducentUpdate.Text = g.producent;
                        txtGameAgeCategoryUpdate.Text = g.kategoria_wiekowa_PEGI;
                        txtGameTypeUpdate.Text = g.typ_gry;
                        txtGamePriceUpdate.Text = Convert.ToString(g.cena);
                        txtGamePlatformUpdate.Text = g.platforma;
                        updatingGameID = g.id_gry;
                    }
                }
            }               
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            WypozyczalniaGierEntities db = new WypozyczalniaGierEntities();

            var result = from g in db.Gras where g.id_gry == updatingGameID select g;

            Gra game = result.SingleOrDefault();

            if(game != null)
            {
                game.id_gry = Convert.ToInt32(txtGameIdUpdate.Text);
                game.nazwa_gry = txtGameNameUpdate.Text;
                game.producent = txtGameProducentUpdate.Text;
                game.kategoria_wiekowa_PEGI = txtGameAgeCategoryUpdate.Text;
                game.typ_gry = txtGameTypeUpdate.Text;
                game.cena = Convert.ToDecimal(txtGamePriceUpdate.Text);
                game.platforma = txtGamePlatformUpdate.Text;
            }

            db.SaveChanges();

            MessageBox.Show("The game has been updated.");

            LoadGames();
        }

        private int updatingGameID = 0;

        private void LoadGames()
        {
            WypozyczalniaGierEntities db = new WypozyczalniaGierEntities();
            gridGames.ItemsSource = db.Gras.ToList();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult =  MessageBox.Show("Are you sure that you want to remove game?", "Delete game",MessageBoxButton.YesNo, MessageBoxImage.Warning,MessageBoxResult.No);

            if(messageBoxResult == MessageBoxResult.Yes)
            {

                WypozyczalniaGierEntities db = new WypozyczalniaGierEntities();

                var result = from g in db.Gras where g.id_gry == updatingGameID select g;

                Gra game = result.SingleOrDefault();

                if (game != null)
                {
                    db.Gras.Remove(game);
                    db.SaveChanges();
                }

                LoadGames();
            }
        }
    }
}
