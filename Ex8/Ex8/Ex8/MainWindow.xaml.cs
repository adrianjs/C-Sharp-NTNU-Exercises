using System;
using System.Collections.Generic;
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

namespace Ex8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] ColorTab = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };

        public MainWindow()
        {
            InitializeComponent();
            RoutedCommand AboutShortcut = new RoutedCommand();
            RoutedCommand ExitShortcut = new RoutedCommand();
            AboutShortcut.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));
            ExitShortcut.InputGestures.Add(new KeyGesture(Key.Q, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(AboutShortcut, AboutMenu_Click));
            CommandBindings.Add(new CommandBinding(ExitShortcut, ExitMenu_Click));


            List<Colors> items = new List<Colors>();
            foreach (string color in ColorTab) {
                items.Add(new Colors() { Color = color });
            }
            items.Add(new Colors() { Color = "Transparent" });
            ComboColor.SelectedItem = 0;
            ComboColor.ItemsSource = items;
            RadioSmile.IsChecked = true;
        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            string AboutInfo = "Course:\t\t IINI4002 \n Exercise 8:\tGUI, part 2\nName:\t\tAdrian Steffenakk";
            MessageBox.Show(AboutInfo, "Information");
            TextStatus.Text = "About";
        }

        private void RandomColor_Click(object sender, RoutedEventArgs e)
        {
            RandomColorThrow();
            TextStatus.Text = "Color changed";
        }

        private void RandomImage_Click(object sender, RoutedEventArgs e)
        {
            RandomImageThrow();
            TextStatus.Text = "Image changed";
        }

        private void RandomImageColor_Click(object sender, RoutedEventArgs e)
        {
            RandomColorThrow();
            RandomImageThrow();
            TextStatus.Text = "Image and color changed";
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(this, "Exit program?", "Exit Prompt", buttons);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        

        private void ButtonShowFigure_Click(object sender, RoutedEventArgs e)
        {
            if (RadioSmile.IsChecked == true)
            {
                MyImage.Source = new BitmapImage(new Uri("C:\\Users\\adrst\\Documents\\Bachelor-i-Informatikk-NTNU\\Semester-6\\IINI4002-C#.NET\\Ex8\\Ex8\\Ex8\\img\\bilde_smil.png", UriKind.RelativeOrAbsolute));
            }
            else if (RadioHouse.IsChecked == true)
            {
                MyImage.Source = new BitmapImage(new Uri("C:\\Users\\adrst\\Documents\\Bachelor-i-Informatikk-NTNU\\Semester-6\\IINI4002-C#.NET\\Ex8\\Ex8\\Ex8\\img\\house_logo.png", UriKind.RelativeOrAbsolute));
            }
            else if (RadioBoat.IsChecked == true)
            {
                MyImage.Source = new BitmapImage(new Uri("C:\\Users\\adrst\\Documents\\Bachelor-i-Informatikk-NTNU\\Semester-6\\IINI4002-C#.NET\\Ex8\\Ex8\\Ex8\\img\\boat_logo.png", UriKind.RelativeOrAbsolute));
            }
            string ChosenColor;
            try
            {
                ChosenColor = (ComboColor.SelectedItem as Colors).Color;
            }
            catch (Exception)
            {
                ChosenColor = "Transparent";
            }
            ColorHandler(ChosenColor);
            TextStatus.Text = "Showing image with given color";
        }

        private void ColorHandler(string s)
        {
            if (s == "Red") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Red); }
            else if (s == "Orange") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Orange); }
            else if (s == "Yellow") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow); }
            else if (s == "Green") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Green); }
            else if (s == "Blue") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue); }
            else if (s == "Violet") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Violet); }
            else if (s == "Indigo") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Indigo); }
            else if (s == "Transparent") { BackgroundColor.Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent); }
        }

        private void RandomColorThrow()
        {
            Random random = new Random();
            int i = random.Next(ColorTab.Length - 1);
            ColorHandler(ColorTab[i]);
        }

        private void RandomImageThrow()
        {
            Random random = new Random();
            int dice = random.Next(3);
            if (dice == 0) { MyImage.Source = new BitmapImage(new Uri("C:\\Users\\adrst\\Documents\\Bachelor-i-Informatikk-NTNU\\Semester-6\\IINI4002-C#.NET\\Ex8\\Ex8\\Ex8\\img\\bilde_smil.png", UriKind.RelativeOrAbsolute)); }
            else if (dice == 1) { MyImage.Source = new BitmapImage(new Uri("C:\\Users\\adrst\\Documents\\Bachelor-i-Informatikk-NTNU\\Semester-6\\IINI4002-C#.NET\\Ex8\\Ex8\\Ex8\\img\\house_logo.png", UriKind.RelativeOrAbsolute)); }
            else { MyImage.Source = new BitmapImage(new Uri("C:\\Users\\adrst\\Documents\\Bachelor-i-Informatikk-NTNU\\Semester-6\\IINI4002-C#.NET\\Ex8\\Ex8\\Ex8\\img\\boat_logo.png", UriKind.RelativeOrAbsolute)); }
        }
    }
}
