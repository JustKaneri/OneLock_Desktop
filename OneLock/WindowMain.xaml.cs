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
        public WindowMain()
        {
            InitializeComponent();
            StpPass.Visibility = Visibility.Visible;

            CbxThems.Items.Add("Светлая");
            CbxThems.Items.Add("Темная");
            CbxThems.Items.Add("Фиолетовая-зеленая");

            for (int i = 4; i <= 16; i+=4)
            {
                CmxLeng.Items.Add(i);
            }

            CmxLeng.SelectedIndex = 0;
            CmbPass.SelectedIndex = 0;

            SetStyle();
        }

        private void SetStyle()
        {
            string them = "";

            if (File.Exists("LightThem.cnf"))
            {
                them = "LightThem";
                CbxThems.SelectedIndex = 0;
            }


            if (File.Exists("DarkThem.cnf"))
            {
                them = "DarkThem";
                CbxThems.SelectedIndex = 1;
            }

            if (File.Exists("PurpureThem.cnf"))
            {
                them = "PurpureThem";
                CbxThems.SelectedIndex = 2;
            }


            var uri = new Uri("Styles\\" + them + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

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

        }

        private void CbxThems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentThem = CbxThems.SelectedItem.ToString().ToLower();

            currentThem = currentThem == "светлая" ? "LightThem" : currentThem;
            currentThem = currentThem == "темная" ? "DarkThem" : currentThem;
            currentThem = currentThem == "фиолетовая-зеленая" ? "PurpureThem" : currentThem;

            if (File.Exists("LightThem.cnf"))
                File.Delete("LightThem.cnf");

            if (File.Exists("DarkThem.cnf"))
                File.Delete("DarkThem.cnf");

            if (File.Exists("PurpureThem.cnf"))
                File.Delete("PurpureThem.cnf");

            var uri = new Uri("Styles\\" + currentThem+ ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);


            File.Create(currentThem + ".cnf");
        }
    }
}
