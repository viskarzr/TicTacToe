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

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для WinMainMenu.xaml
    /// </summary>
    public partial class WinMainMenu : Window
    {
        public WinMainMenu()
        {
            InitializeComponent();
        }

        private void btnGameSimple_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Owner = this;
            f.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Style style = new Style();
            style.Setters.Add(new Setter(
                Xceed.Wpf.Toolkit.MessageBox.YesButtonContentProperty, "Выйти"));
            style.Setters.Add(new Setter(
                Xceed.Wpf.Toolkit.MessageBox.NoButtonContentProperty, "Остаться"));

            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(
               "Вы уверены, что хотите выйти из игры?",
               "Выход из игры",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.Yes,
                style);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGameBFild_Click(object sender, RoutedEventArgs e)
        {
            winGameSecondPlace f = new winGameSecondPlace();
            f.Owner = this;
            f.ShowDialog();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            var msgBox = new Xceed.Wpf.Toolkit.MessageBox
            {
                Text = $"Данная программа представляет собой курсовой проект \nпо дисциплине МДК 01.01 РПМ,\nстудентки гр.ИСП-41 Кирюшовой Виктории",
                Caption = "О программе КРЕСТИКИ-НОЛИКИ",
                WindowBackground = System.Windows.Media.Brushes.LightPink,
                WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
                OkButtonContent = "Понятно"
            };
            var result = msgBox.ShowDialog();
        }
    }
}
