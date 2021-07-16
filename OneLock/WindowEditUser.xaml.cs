using OneLock.Controlls;
using System.Windows;
using System.Windows.Input;

namespace OneLock
{
    /// <summary>
    /// Interaction logic for WindowEditUser.xaml
    /// </summary>
    public partial class WindowEditUser : Window
    {
        private string _oldPassword;

        public string _newPassword { get; private set; }

        public WindowEditUser(string oldPassword)
        {
            InitializeComponent();
            _oldPassword = oldPassword;
            StyleControler.SetStyle();
        }

        private void BtnSave_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnSave.Opacity = .75;
        }

        private void BtnSave_MouseEnter(object sender, MouseEventArgs e)
        {
            BtnSave.Opacity = 1;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TbxPassOld.Password) && string.IsNullOrWhiteSpace(TbxOpenPassOld.Text))
            {
                MessageBox.Show("Укажите старый пароль","Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TbxPassNew.Password) && string.IsNullOrWhiteSpace(TbxOpenPassNew.Text))
            {
                MessageBox.Show("Укажите старый пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(TbxOpenPassOld.Text != _oldPassword && TbxPassOld.Password != _oldPassword)
            {
                MessageBox.Show("Не верный старый пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            _newPassword = TbxOpenPassNew.Text;
            _newPassword = TbxPassNew.Password;

            MessageBox.Show("Пароль успешно изменён", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }

        private void BtnShowOld_Click(object sender, RoutedEventArgs e)
        {
            if (TbxPassOld.PasswordChar == '\0')
            {
                TbxPassOld.PasswordChar = '●';
                TbxOpenPassOld.Visibility = Visibility.Hidden;
                TbxPassOld.Visibility = Visibility.Visible;
                TbxPassOld.Password = TbxOpenPassOld.Text;
                TbxOpenPassOld.Text = "";
            }
            else
            {
                TbxPassOld.PasswordChar = '\0';
                TbxOpenPassOld.Visibility = Visibility.Visible;
                TbxPassOld.Visibility = Visibility.Hidden;
                TbxOpenPassOld.Text = TbxPassOld.Password;
                TbxPassOld.Password = "";
            }
        }

        private void BtnShowNew_Click(object sender, RoutedEventArgs e)
        {
            if (TbxPassNew.PasswordChar == '\0')
            {
                TbxPassNew.PasswordChar = '●';
                TbxOpenPassNew.Visibility = Visibility.Hidden;
                TbxPassNew.Visibility = Visibility.Visible;
                TbxPassNew.Password = TbxOpenPassNew.Text;
                TbxOpenPassNew.Text = "";
            }
            else
            {
                TbxPassNew.PasswordChar = '\0';
                TbxOpenPassNew.Visibility = Visibility.Visible;
                TbxPassNew.Visibility = Visibility.Hidden;
                TbxOpenPassNew.Text = TbxPassNew.Password;
                TbxPassNew.Password = "";
            }
        }
    }
}
