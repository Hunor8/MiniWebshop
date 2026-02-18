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
using NetworkHelper;

namespace MiniWeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Termekek> termekekLista = new List<Termekek>();
        private const string baseUrl = "http://localhost:3000/products";
        
        public MainWindow()
        {
            InitializeComponent();
            DatagridFeltolt();
            KategoriaLenyilo();
            
        }

        private void KategoriaLenyilo()
        {
            /*List<Termekek> Kategoriak = 


            foreach (var item in Kategoriak)
            {
                if (!string.IsNullOrWhiteSpace(item.category))
                    Kategoria.Items.Add(item.category);
            }

            Kategoria.SelectedIndex = 0;*/

        }

        private void DatagridFeltolt()
        {
            termekekLista = Backend.GET(baseUrl).Send().As<List<Termekek>>();
            ProductsGrid.ItemsSource = termekekLista;
        }

        private void hozzaad_Click(object sender, RoutedEventArgs e)
        {
            /*if (ProductsGrid.SelectedItem is Termekek kivalasztott)
            {
                string url = $"http://localhost:3000/products/";

                Termekek UjTermek = new Termekek()
                {
                    name = txtNev.Text,
                    price = double.Parse(txtAr.Text),
                    category = Kategoria.Text,
                    inStock = (RaktaronE.IsChecked == true) ? 1 : 0
                };

                Backend.POST(url).Body(UjTermek).Send();

                DatagridFeltolt();
            }*/
        }

        private void ment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void torol_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedItem is Termekek kivalasztott)
            {
                string url = $"http://localhost:3000/products/{kivalasztott.id}";
                Backend.DELETE(url).Send();
                DatagridFeltolt(); 
            }
        }

        private void SzuroAlk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Friss_Click(object sender, RoutedEventArgs e)
        {
            DatagridFeltolt();
        }

        
    }
}
