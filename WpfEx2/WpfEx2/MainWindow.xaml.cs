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
            prodlist.ItemsSource = products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
            prodlist.Items.Refresh();//항목이 변경됐으므로 뷰 리프레시
            idv.Text = "";
            namev.Text = "";
            pricev.Text = "";
            amountv.Text = "";
            isoutv.IsChecked = false;

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