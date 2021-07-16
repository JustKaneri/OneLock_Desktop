using System.Windows;
using System.Windows.Controls;
using OneLock.Controlls;

namespace OneLock
{
    /// <summary>
    /// Interaction logic for WindowRegestry.xaml
    /// </summary>
    public partial class WindowRegestry : Window
    {
        public WindowRegestry()
        {
            InitializeComponent();
            BtnShow.Click += BtnShow_Click;

            StyleControler.SetStyle();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (TbxPass.PasswordChar == '\0')
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

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxLogin.Text))
            {
                MessageBox.Show("Укажите логин", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TbxPass.Password))
            {
                MessageBox.Show("Укажите пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UserControler user = new UserControler();

            try
            {
                user.Regestry(TbxLogin.Text, TbxPass.Password);
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            MessageBox.Show("Успешная регистрация", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }

        private void BtnReg_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Opacity = 0.75;
        }

        private void BtnReg_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Opacity = 1;
        }
    }
}
