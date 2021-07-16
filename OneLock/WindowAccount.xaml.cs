using OneLock.Controlls;
using OneLock.Model;
using System.Windows;
using System.Windows.Controls;

namespace OneLock
{
    /// <summary>
    /// Interaction logic for WindowAccount.xaml
    /// </summary>
    public partial class WindowAccount : Window
    {
        public Account Account;

        public WindowAccount(string Name,string Login,string Pass)
        {
            InitializeComponent();
            StyleControler.SetStyle();

            if(Name != null)
            {
                TbxName.Text = Name;
                TbxLogin.Text = Login;
                TbxPass.Password = Pass;
            }
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TbxName.Text) || string.IsNullOrWhiteSpace(TbxLogin.Text))
            {
                MessageBox.Show("Заполните все поля", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(string.IsNullOrWhiteSpace(TbxPass.Password) && string.IsNullOrWhiteSpace(TbxOpenPass.Text))
            {
                MessageBox.Show("Укажите пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Account = new Account();
            Account.NameAccount = TbxName.Text;
            Account.Login = TbxLogin.Text;
            Account.Password = TbxPass.Password;

            DialogResult = true;
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (TbxPass.PasswordChar == '\0')
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

        private void BtnLogIn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Opacity = 0.75;
        }

        private void BtnLogIn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Opacity = 1;
        }
    }
}
