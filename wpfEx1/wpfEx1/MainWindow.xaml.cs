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

namespace wpfEx1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> list = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            list.Add("aaa");
            list.Add("bbb");
            list.Add("ccc");
            lst1.ItemsSource = list; //ui의 리스트박스와 list를 바인딩
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click button");
            txt.Text = input.Text;
        }

        //sender:이벤트 발생 객체(클릭된 라디오버튼)
        private void ra1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ra = (RadioButton)sender;
            MessageBox.Show(ra.Content+"");
            
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return "[id="+Id+", name:"+Name+"]";
        }
    }
}