using System;
using System.IO;
using System.Windows;

namespace OneLock.Controlls
{
    public static class StyleControler
    {
        public static void UpadateStyle(string currentThem)
        {
            currentThem = currentThem == "светлая" ? "LightThem" : currentThem;
            currentThem = currentThem == "темная" ? "DarkThem" : currentThem;
            currentThem = currentThem == "фиолетово-зеленая" ? "PurpureThem" : currentThem;
            currentThem = currentThem == "темно-красная" ? "RedThem" : currentThem;
            currentThem = currentThem == "неоновая" ? "NeonThem" : currentThem;

            DeleteOldThem();

            var uri = new Uri("Styles\\" + currentThem + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            File.Create(currentThem + ".cnf");
        }

        private static void DeleteOldThem()
        {
            var dir = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);

            foreach (var item in dir)
            {
                if (Path.GetExtension(item) == ".cnf")
                    File.Delete(item);
            }
        }

        public static void SetStyle()
        {
            string them = "";

            var dir = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);

            foreach (var item in dir)
            {
                if (Path.GetExtension(item) == ".cnf")
                    them = Path.GetFileNameWithoutExtension(item);
            }

            var uri = new Uri("Styles\\" + them + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
