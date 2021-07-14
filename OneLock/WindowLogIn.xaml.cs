using System;
using System.Collections.Generic;
using System.IO;
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

namespace OneLock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            BtnShow.Click += BtnShow_Click;
            BtnLogIn.Click += BtnLogIn_Click;
            BtnReg.Click += BtnReg_Click;

            SetStyle();
        }

        private void SetStyle()
        {
            string them = "";

            if (File.Exists("LightThem.cnf"))
            {
                them = "LightThem";
            }
                

            if (File.Exists("DarkThem.cnf"))
            {
                them = "DarkThem";
            }

            if (File.Exists("PurpureThem.cnf"))
            {
                them = "PurpureThem";
            }



            var uri = new Uri("Styles\\"+them + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            WindowRegestry regestry = new WindowRegestry();
            this.Hide();
            regestry.ShowDialog();
            this.Show();
            
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            WindowMain main = new WindowMain();
            main.Show();
            this.Close();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if(TbxPass.PasswordChar == '\0')
            {
                TbxPass.PasswordChar = '●';
                TbxOpenPass.Visibility = Visibility.Hidden;
                TbxPass.Visibility = Visibility.Visible;
                TbxPass.Password = TbxOpenPass.Text;
            }
            else
            {
                TbxPass.PasswordChar = '\0';
                TbxOpenPass.Visibility = Visibility.Visible;
                TbxPass.Visibility = Visibility.Hidden;
                TbxOpenPass.Text = TbxPass.Password;
            }
            
        }
    }
}
