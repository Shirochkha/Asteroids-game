using GameComponents;
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
using System.Windows.Shapes;

namespace Ateroids
{
    /// <summary>
    /// Логика взаимодействия для GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        /// <summary>
        /// Окно конца игры.
        /// </summary>
        public GameOver()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) { Application.Current.Shutdown(); }
        }
    }
}
