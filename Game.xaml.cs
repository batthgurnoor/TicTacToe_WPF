using System.Windows;
using System.Windows.Controls;

namespace TicTacToe_WPF
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        string choice, player1, player2;
        int x = 1;
        Button clickBtn;
        MessageBoxResult res;

        string[,] vs = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        public Game()
        {
            InitializeComponent();
        }

        public Game(string choice, string player1, string player2)
        {
            InitializeComponent();
            this.choice = choice;
            this.player1 = player1;
            this.player2 = player2;
            txtBlock.Text = player1;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            clickBtn = sender as Button;

            if (x % 2 != 0)
            {
                txtBlock.Text = player2;
                proceedTurn();
                choice = "O";
            }
            else
            {
                txtBlock.Text = player1;
                proceedTurn();
                choice = "X";
            }
            int dec = checkWin();
            if (dec == 1)
            {
                declareWin();
            }
            else if (dec == -1)
            {
                res = MessageBox.Show("Match Tied", "Result", MessageBoxButton.OK);


            }




        }

        public void proceedTurn()
        {
            // Displays the choice of the Player on the button clicked
            clickBtn.Content = choice;
            clickBtn.FontSize = 100;
            clickBtn.Padding = new Thickness(-10);
            clickBtn.IsEnabled = false;
            vs[Grid.GetRow(clickBtn), Grid.GetColumn(clickBtn)] = choice;
            x++;
        }
        public int checkWin()
        {
            int win = 0;
            // Checking Horizontal Wins
            if ((vs[0, 0] == vs[0, 1] && vs[0, 1] == vs[0, 2]) || (vs[1, 0] == vs[1, 1] && vs[1, 1] == vs[1, 2]) || (vs[2, 0] == vs[2, 1] && vs[2, 1] == vs[2, 2]))
            {
                return 1;

            }
            // Checking Vertical Wins
            else if ((vs[0, 0] == vs[1, 0] && vs[1, 0] == vs[2, 0]) || (vs[0, 1] == vs[1, 1] && vs[1, 1] == vs[2, 1]) || (vs[0, 2] == vs[1, 2] && vs[1, 2] == vs[2, 2]))
            {

                return 1;
            }
            //checking Diagonal Wins
            else if ((vs[0, 0] == vs[1, 1] && vs[1, 1] == vs[2, 2]) || (vs[2, 0] == vs[1, 1] && vs[1, 1] == vs[0, 2]))
            {
                return 1;
            }
            //checking for draw
            else if (win == 0 && x == 10)
            {
                return -1;
            }
            else
            {
                return 0;
            }


        }

        public void declareWin()
        {
            if ((x - 1) % 2 == 0)
            {
                MessageBox.Show(player2 + " Wins :)", "Result", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show(player1 + " Wins :)", "Result", MessageBoxButton.OK);

            }
        }
    }

}
