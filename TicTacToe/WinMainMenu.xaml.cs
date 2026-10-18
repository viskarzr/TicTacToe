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
            f.ShowDialog();
            this.Close();
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

            //var msgBox = new Xceed.Wpf.Toolkit.MessageBox
            //{
            //    Text = "Вы уверены, что хотите выйти из игры?",
            //    Caption = "Выход из игры",
            //    WindowBackground = System.Windows.Media.Brushes.LightPink,
            //    WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
            //    YesButtonContent = "Выйти",
            //    YesButtonStyle = (Style)FindResource("MyYesButtonStyle"),
            //    NoButtonContent = "Остаться"
            //};
            //bool? result = msgBox.ShowDialog();
            //if (result == true)
            //{
            //    this.Close();
            //}
        }
    }
}
