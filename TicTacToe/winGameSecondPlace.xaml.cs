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
    /// Логика взаимодействия для winGameSecondPlace.xaml
    /// </summary>
    public partial class winGameSecondPlace : Window
    {
        private readonly string[] board = new string[36];
        private int turn = 0;
        private int scoreX = 0;
        private int scoreO = 0;

        private Button[] buttons;
        public winGameSecondPlace()
        {
            InitializeComponent();
            buttons = new[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18,
                            btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36 };
            ResetGame();
            UpdateScoreDisplay();
        }

        private void ResetGame()
        {
            turn = 0;
            for (int i = 0; i < board.Length; i++)
                board[i] = "";
            UpdateButtons();
            UpdateTurnDisplay();
        }

        /// <summary>
        /// TODO: Настроить проверку на выигрыш для поля 6на6
        /// </summary>
        private void CheckForWin()
        {
            for (int i = 0; i < 6; i++)
            {
                int startIdx = i * 6;
                if (board[startIdx] != "" && board[startIdx] == board[startIdx + 1] && board[startIdx + 1] == board[startIdx + 2] &&
                    board[startIdx + 2] == board[startIdx + 3] && board[startIdx + 3] == board[startIdx + 4] && board[startIdx + 4] == board[startIdx + 5])
                {
                    RegisterWin(board[i * 3]);
                    var msgBox = new Xceed.Wpf.Toolkit.MessageBox
                    {
                        Text = $"Игрок {board[i * 3]} выиграл!",
                        Caption = "Результат игры!",
                        WindowBackground = System.Windows.Media.Brushes.LightPink,
                        WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
                        OkButtonContent = "Играть снова"
                    };
                    var result = msgBox.ShowDialog();
                    ResetGame();
                    return;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (board[i] != "" && board[i] == board[i + 6] && board[i + 6] == board[i + 12] &&  board[i + 12] == board[i + 18] &&
                   board[i + 18] == board[i + 24] && board[i + 24] == board[i + 30])
                {
                    RegisterWin(board[i]);
                    var msgBox = new Xceed.Wpf.Toolkit.MessageBox
                    {
                        Text = $"Игрок {board[i]} выиграл!",
                        Caption = "Результат игры!",
                        WindowBackground = System.Windows.Media.Brushes.LightPink,
                        WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
                        OkButtonContent = "Играть снова"
                    };
                    var result = msgBox.ShowDialog();
                    ResetGame();
                    return;
                }
            }

            if (board[0] != "" &&
                board[0] == board[7] &&
                board[7] == board[14] &&
                board[14] == board[21] &&
                board[21] == board[28] &&
                board[28] == board[35])
            {
                RegisterWin(board[0]);
                var msgBox = new Xceed.Wpf.Toolkit.MessageBox
                {
                    Text = $"Игрок {board[4]} выиграл!",
                    Caption = "Результат игры!",
                    WindowBackground = System.Windows.Media.Brushes.LightPink,
                    WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
                    OkButtonContent = "Играть снова"
                };
                var result = msgBox.ShowDialog();
                ResetGame();
                return;
            }

            if (board[5] != "" &&
               board[5] == board[10] &&
               board[10] == board[15] &&
               board[15] == board[20] &&
               board[20] == board[25] &&
               board[25] == board[30])
            {
                RegisterWin(board[5]);
                var msgBox = new Xceed.Wpf.Toolkit.MessageBox
                {
                    Text = $"Игрок {board[5]} выиграл!",
                    Caption = "Результат игры!",
                    WindowBackground = System.Windows.Media.Brushes.LightPink,
                    WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
                    OkButtonContent = "Играть снова"
                };
                var result = msgBox.ShowDialog();
                ResetGame();
            }

            if (Array.TrueForAll(board, s => s != ""))
            {
                var msgBox = new Xceed.Wpf.Toolkit.MessageBox
                {
                    Text = $"Ничья!",
                    Caption = "Результат игры!",
                    WindowBackground = System.Windows.Media.Brushes.LightPink,
                    WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
                    OkButtonContent = "Играть снова"
                };
                var result = msgBox.ShowDialog();
                ResetGame();
            }
        }

        private void UpdateButtons()
        {
            for (int i = 0; i < board.Length; i++)
            {
                buttons[i].Content = board[i];
            }
        }

        private void UpdateTurnDisplay()
        {
            if (turn == 0)
            {
                tbPlayerMove.Text = "Ход: Крестики (X)";
            }
            else
            {
                tbPlayerMove.Text = "Ход: Нолики (O)";
            }
        }

        private void UpdateScoreDisplay()
        {
            tbGameScore.Text = $"Счет: X ({scoreX}) — O ({scoreO})";
        }
        private void RegisterWin(string winner)
        {
            if (winner == "X") scoreX++;
            else if (winner == "O") scoreO++;

            UpdateScoreDisplay();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                int index = Array.IndexOf(buttons, btn);
                if (index == -1 || board[index] != "")
                    return;

                board[index] = turn == 0 ? "X" : "O";
                turn = 1 - turn;

                UpdateButtons();
                UpdateTurnDisplay();
                CheckForWin();
            }
        }

        private void btnRules_Click(object sender, RoutedEventArgs e)
        {
            var msgBox = new Xceed.Wpf.Toolkit.MessageBox
            {
                Text = $"ПОДГОТОВКА И УЧАСТНИКИ:\r\nИграют два человека.Один играет за «крестики» (X), другой — за «нолики» (O).\r\nИгровое поле — квадрат 6 на 6 клетки (всего 6 ячеек).\r\nКАК ХОДЯТ:\r\n1. Первый ход всегда делают крестики.\r\n2. Игроки ходят по очереди, каждый ставит свой знак в любую свободную клетку.\r\n3. В одну клетку можно поставить только один знак; переставлять уже поставленные фигуры нельзя.\r\nУСЛОВИЯ ПОБЕДЫ:\r\nИгрок побеждает, если первым выстроит ШЕСТЬ СВОИХ ЗНАКА ПОДРЯД::\r\n- по горизонтали (в строке),\r\n- по вертикали (в столбце),\r\n- по диагонали (две возможные диагонали).",
                Caption = "Правила игры в КРЕСТИКИ-НОЛИКИ",
                WindowBackground = System.Windows.Media.Brushes.LightPink,
                WindowBorderBrush = System.Windows.Media.Brushes.DarkOrchid,
                OkButtonContent = "Понятно"
                //Height = 550,
                //Width = 300
            };
            var result = msgBox.ShowDialog();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Style style = new Style();
            style.Setters.Add(new Setter(
                Xceed.Wpf.Toolkit.MessageBox.YesButtonContentProperty, "Выйти"));
            style.Setters.Add(new Setter(
                Xceed.Wpf.Toolkit.MessageBox.NoButtonContentProperty, "Остаться"));

            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(
               "Вы уверены, что хотите выйти из игры? Счет игры будет утерян!",
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
    }
}
