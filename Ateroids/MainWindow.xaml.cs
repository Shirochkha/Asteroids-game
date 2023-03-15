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

namespace Ateroids
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Окно главного меню.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();

            ChooseShip chooseShip = new ChooseShip();
            chooseShip.Show();
            
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            WindowRules rules = new WindowRules();
            rules.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape) { Application.Current.Shutdown(); }
        }
    }
}
