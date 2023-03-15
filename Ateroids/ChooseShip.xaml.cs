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
    /// Логика взаимодействия для ChooseShip.xaml
    /// </summary>
    public partial class ChooseShip : Window
    {
        /// <summary>
        /// Выбор типа корабля первого игрока.
        /// </summary>
        public int num = 0;

        /// <summary>
        /// Выбор типа корабля второго игрока.
        /// </summary>
        public int num2 = 0;

        /// <summary>
        /// Окно выбора корабля.
        /// </summary>
        public ChooseShip()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Pl1.Text == "" || Pl2.Text == "") MessageBox.Show("Выберите тип корабля!");
            else
            {
                Choose();
                Close();
                Engine game = new Engine();
                game.typeShip1 = num;
                game.typeShip2 = num2;
                game.Run(60, 60);
            }
        }

        private void Choose()
        {
            switch (Pl1.Text)
            {
                case "Обычный":
                    num = 1;
                    break;
                case "Скоростной":
                    num = 2;
                    break;
                case "Защитный":
                    num = 3;
                    break;
            }
            switch (Pl2.Text)
            {
                case "Обычный":
                    num2 = 1;
                    break;
                case "Скоростной":
                    num2 = 2;
                    break;
                case "Защитный":
                    num2 = 3;
                    break;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) { Application.Current.Shutdown(); }
        }
    }
}
