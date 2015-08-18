using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;

namespace BabyNames_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window_Loaded);

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(@"C:\Users\Alexander\Source\Repos\Hallo World\BabyNames_Lab\BabyNames_Lab\bin\Debug\babynames.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, Encoding.Default);
                string str;
                StringWriter swr = new StringWriter();

                str = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    swr.Write(str);                   
                    DecadeTopNames.Items.Add(swr.ToString());
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }

    }
}
