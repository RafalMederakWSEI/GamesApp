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
    }
}
