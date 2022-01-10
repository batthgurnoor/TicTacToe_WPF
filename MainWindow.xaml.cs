using System.Windows;

namespace TicTacToe_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            text.IsReadOnly = true;
        }

        string pOneName, pTwoName;


        private void btnP1_Click(object sender, RoutedEventArgs e)
        {
            user1.Clear();
        }

        private void btnP2_Click(object sender, RoutedEventArgs e)
        {
            user2.Clear();
        }



        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            user1.Clear();
            user2.Clear();
            user1.IsReadOnly = false;
            user2.IsReadOnly = false;

        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            pOneName = user1.Text.ToString();
            pTwoName = user2.Text.ToString();
            if (string.IsNullOrWhiteSpace(pOneName) || string.IsNullOrWhiteSpace(pTwoName))
            {
                MessageBox.Show("Player Names cannot be Empty or Whitespaces. Please Enter Valid Names", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                user1.IsReadOnly = true;

                user2.IsReadOnly = true;
                btnAll.IsEnabled = false;
                btnP1.IsEnabled = false;
                btnP2.IsEnabled = false;
                showChoice("X");
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            user1.Clear();
            user2.Clear();
            user1.IsReadOnly = false;
            user2.IsReadOnly = false;
            btnAll.IsEnabled = true;
            btnP1.IsEnabled = true;
            btnP2.IsEnabled = true;
        }

        public void showChoice(string choose)
        {
            MessageBoxResult Confirm = MessageBox.Show("Do you want to proceed with your choice?", "Proceed", MessageBoxButton.YesNo,MessageBoxImage.Exclamation);

            if (Confirm == MessageBoxResult.Yes)
            {
                Game game1 = new Game(choose, pOneName, pTwoName);
                game1.Show();
            }
            else
            {
                btnAll.IsEnabled = true;
                btnP1.IsEnabled = true;
                btnP2.IsEnabled = true;
            }

        }


    }
}
