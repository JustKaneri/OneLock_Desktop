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
        public UserControler User { get; set; }

        public WindowMain()
        {
            InitializeComponent();

            StpPass.Visibility = Visibility.Visible;

            CbxThems.Items.Add("Светлая");
            CbxThems.Items.Add("Темная");
            CbxThems.Items.Add("Фиолетово-зеленая");
            CbxThems.Items.Add("Темно-красная");
            CbxThems.Items.Add("Неоновая");

            for (int i = 4; i <= 16; i += 4)
            {
                CmxLeng.Items.Add(i);
            }

            CmxLeng.SelectedIndex = 0;
            CmbPass.SelectedIndex = 0;

            SetStyle();

        }

        private void SetStyle()
        {
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
    }
}
