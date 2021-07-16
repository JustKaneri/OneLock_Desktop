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
using OneLock.Controlls;

namespace OneLock
{

    public partial class MainWindow : Window
    {
        private UserControler user;

        public MainWindow()
        {
            InitializeComponent();
            BtnShow.Click += BtnShow_Click;
            BtnLogIn.Click += BtnLogIn_Click;
            BtnReg.Click += BtnReg_Click;

            StyleControler.SetStyle();
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
            if(string.IsNullOrWhiteSpace(TbxLogin.Text))
            {
                MessageBox.Show("Укажите логин","Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TbxPass.Password) && string.IsNullOrWhiteSpace(TbxOpenPass.Text))
            {
                MessageBox.Show("Укажите пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            user = new UserControler();
            try
            {
                user.Authorization(TbxLogin.Text, TbxPass.Password==""?TbxOpenPass.Text:TbxPass.Password);
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            WindowMain main = new WindowMain(user);
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
                TbxOpenPass.Text = "";
            }
            else
            {
                TbxPass.PasswordChar = '\0';
                TbxOpenPass.Visibility = Visibility.Visible;
                TbxPass.Visibility = Visibility.Hidden;
                TbxOpenPass.Text = TbxPass.Password;
                TbxPass.Password = "";
            }
            
        }

        private void BtnLogIn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Opacity = 0.75;
        }

        private void BtnLogIn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Opacity = 1;
        }
    }
}
