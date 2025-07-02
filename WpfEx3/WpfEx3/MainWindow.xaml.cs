using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
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

namespace WpfEx3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NetworkStream stream;
        private StreamWriter writer;
        private StreamReader reader;
        private TcpClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            client = new TcpClient();
            string serverIP = "192.168.0.179";
            client.Connect(serverIP, 1234);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            Thread th = new Thread(new ThreadStart(readMsg));
            th.Start();

        }

        public void readMsg()
        {
            string str;
            while (true)
            {
                str = reader.ReadLine();
                if (str.StartsWith("/stop"))
                {
                    break;
                }
                //can't access to ui directly from the background
                //access to ui using the object, Current.Dispatcher 
                Application.Current.Dispatcher.Invoke(() => {
                    body.Text += str + "\n";
                });

            }
            client.Close();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            writer.WriteLine(input.Text);
            writer.Flush();
            input.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            writer.WriteLine("/stop");
            writer.Flush();
        }
    }

}
