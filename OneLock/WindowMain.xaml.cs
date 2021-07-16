using OneLock.Controlls;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OneLock
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        private UserControler User;

        public WindowMain(UserControler user)
        {
            InitializeComponent();
            User = user;

            for (int i = 4; i <= 16; i += 4)
            {
                CmxLeng.Items.Add(i);
            }

            CmxLeng.SelectedIndex = 0;

            SetStyle();

            FillCmbPassword();

            CmbPass.SelectedIndex = 0;

        }

        private void FillCmbPassword()
        {
            CmbPass.Items.Clear();

            foreach (var item in User.GetNameAccount())
            {
                CmbPass.Items.Add(item);
            }
        }

        private void SetStyle()
        {
            CbxThems.Items.Add("Светлая");
            CbxThems.Items.Add("Темная");
            CbxThems.Items.Add("Фиолетово-зеленая");
            CbxThems.Items.Add("Темно-красная");
            CbxThems.Items.Add("Неоновая");

            if (File.Exists("LightThem.cnf"))
                CbxThems.SelectedIndex = 0;

            if (File.Exists("DarkThem.cnf"))
                CbxThems.SelectedIndex = 1;

            if (File.Exists("PurpureThem.cnf"))
                CbxThems.SelectedIndex = 2;

            if (File.Exists("RedThem.cnf"))
                CbxThems.SelectedIndex = 3;

            if (File.Exists("NeonThem.cnf"))
                CbxThems.SelectedIndex = 4;
        }

        private void BtnPassw_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Opacity = 0.5;
        }

        private void BtnPassw_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Opacity = 1;
        }

        private void BtnPassw_Click(object sender, RoutedEventArgs e)
        {
            StpPass.Visibility = Visibility.Visible;
            StpPropert.Visibility = Visibility.Hidden;
            StpCreate.Visibility = Visibility.Hidden;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            StpPass.Visibility = Visibility.Hidden;
            StpPropert.Visibility = Visibility.Hidden;
            StpCreate.Visibility = Visibility.Visible;
        }

        private void BtnProperties_Click(object sender, RoutedEventArgs e)
        {
            StpPass.Visibility = Visibility.Hidden;
            StpPropert.Visibility = Visibility.Visible;
            StpCreate.Visibility = Visibility.Hidden;
        }

        private void BtnAddPass_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Opacity = 0.5;
        }

        private void BtnAddPass_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Opacity = 1;
        }

        private void BtnGetPass_Click(object sender, RoutedEventArgs e)
        {
  
        }

        private void EditPass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditPass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddPass_Click(object sender, RoutedEventArgs e)
        {
            WindowAccount account = new WindowAccount();
            if (account.ShowDialog() == true)
            {
                User.AddAccount(account.Account);

                FillCmbPassword();
                CmbPass.SelectedIndex = CmbPass.Items.Count - 1;

                User.SaveUsers();
            }
        }

        private void BtnGenPass_Click(object sender, RoutedEventArgs e)
        {
            TbxGenPass.Text = "";

            if (CbxEngChar.IsChecked == false & CbxRuChar.IsChecked == false & CbxNumChar.IsChecked == false & CbxOtherChar.IsChecked == false)
            {
                MessageBox.Show("Выберите критерии для создания пароля", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TbxGenPass.Text = PasswordControler.GeneratingPassword(int.Parse(CmxLeng.Text), CbxRuChar.IsChecked ?? false,
                CbxEngChar.IsChecked ?? false, CbxNumChar.IsChecked ?? false, CbxOtherChar.IsChecked ?? false);
        }

        private void CbxThems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentThem = CbxThems.SelectedItem.ToString().ToLower();

            StyleControler.UpadateStyle(currentThem);
        }

        private void CmbPass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbPass.SelectedIndex > 0)
                User.GetLognAccount(CmbPass.SelectedIndex);
        }
    }
}
