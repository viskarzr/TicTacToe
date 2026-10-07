using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] board = new string[9];
        private int turn = 0;

        private Button[] buttons;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            ResetGame();
        }

        private void ResetGame()
        {
            turn = 0;
            for (int i = 0; i < board.Length; i++)
                board[i] = "";
            UpdateButtons();
        }

        private void CheckForWin()
        {
            for (int i = 0; i<3; i++)
            {
                if (board[i*3] == board[i*3+1] && board[i*3+1] == board[i*3+2] && board[i*3]!="")
                {
                    MessageBox.Show($"{board[i * 3]} выиграл!");
                    ResetGame();
                    return;
                }
            }

            for (int i =0; i<3; i++)
            {
                if (board[i] == board[i+3] && board[i+3] == board[i+6] && board[i] !="")
                {
                    MessageBox.Show($"{board[i]} выиграл!");
                    ResetGame();
                    return;
                }
            }

            if (board[0] == board[4] && board[4] == board[8] && board[0]!=""
                || board[2] == board[4]&& board[4] == board[6] && board[2]!="")
            {
                MessageBox.Show($"{board[4]} выиграл!");
                ResetGame();
                return;
            }

            if (Array.TrueForAll(board, s=>s!=""))
            {
                MessageBox.Show("Ничья!");
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
                CheckForWin();
            }
        }
    }
}