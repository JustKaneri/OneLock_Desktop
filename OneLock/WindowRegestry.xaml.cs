using System.Windows;
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

            StyleControl.SetStyle();
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

        }
    }
}
