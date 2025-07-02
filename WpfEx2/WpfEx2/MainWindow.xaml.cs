using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEx2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Product> products = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
            //either listbox or datagrid, they are multi-row printing view
            //in this view, it connects to the array or list to print 
            //ItemsSource: connects to the list to print on listbox/dataGrid
            prodlist.ItemsSource = products;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(idv.Text);
            string name = namev.Text;
            int price = Int32.Parse(pricev.Text);
            int amount = Int32.Parse(amountv.Text);
            bool isout = false;
            if (isoutv.IsChecked != null) {
                isout = (bool)isoutv.IsChecked;
            }
            products.Add(new Product(id, name, price, amount, isout));
            prodlist.Items.Refresh();//list got changed -> refresh
            idv.Text = "";
            namev.Text = "";
            pricev.Text = "";
            amountv.Text = "";
            isoutv.IsChecked = false;

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int idx = prodlist.SelectedIndex;

            int id = Int32.Parse(idv.Text);
            string name = namev.Text;
            int price = Int32.Parse(pricev.Text);
            int amount = Int32.Parse(amountv.Text);
            bool isout = false;
            if (isoutv.IsChecked != null)
            {
                isout = (bool)isoutv.IsChecked;
            }
            products[idx] = new Product(id, name, price, amount, isout);
            prodlist.Items.Refresh();//list got changed -> refresh
            idv.Text = "";
            namev.Text = "";
            pricev.Text = "";
            amountv.Text = "";
            isoutv.IsChecked = false;
            idv.IsReadOnly = false;
        }

        private void prodlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            int idx = dg.SelectedIndex; // selection location
            if (idx < 0) return;
            Product product = products[idx];
            idv.Text = product.Id + "";
            namev.Text = product.Name;
            pricev.Text = product.Price + "";
            amountv.Text = product.Amount + "";
            isoutv.IsChecked = product.isOut;
            idv.IsReadOnly = true; //read Only 



        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int idx = prodlist.SelectedIndex;
            products.RemoveAt(idx);
            prodlist.Items.Refresh();
        }
    }
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public bool isOut { get; set; }
        public Product() { }
        public Product(int id, string name, int price, int amount, bool isout)
        {
            Id = id;
            Name = name; 
            Price = price;
            Amount = amount;
            isOut = isout;
        }
    }
}