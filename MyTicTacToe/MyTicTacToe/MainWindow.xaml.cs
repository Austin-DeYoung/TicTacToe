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

namespace MyTicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> playButtons = new List<Button>();
        private List<int> xLocations = new List<int>();
        private List<int> oLocations = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            playButtons.Add(btn1);
            playButtons.Add(btn2);
            playButtons.Add(btn3);
            playButtons.Add(btn4);
            playButtons.Add(btn5);
            playButtons.Add(btn6);
            playButtons.Add(btn7);
            playButtons.Add(btn8);
            playButtons.Add(btn9);
            
        }

        private int turnCount = 0;
        //private bool gameWon = false;
        

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            turnCount++;
            Button currentButton = sender as Button;
            currentButton.IsEnabled = false;
            //bool gameWon = false;
            
            if ((turnCount) % 2 == 1)
            {
                currentButton.Content = "X";
                xLocations.Add(Convert.ToInt32(currentButton.Tag));
                DisplayText(turnCount, "X", CheckWinCondition(xLocations));
            }
            else
            {
                currentButton.Content = "O";
                oLocations.Add(Convert.ToInt32(currentButton.Tag));
                DisplayText(turnCount, "O", CheckWinCondition(oLocations));

            }


            
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            xLocations.Clear();
            oLocations.Clear();
            turnCount = 0;
            txtInfo.Text = "X's Turn";
            foreach (Button button in playButtons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
        }

        private static bool CheckWinCondition(List<int> currentList)
        {
            currentList.Sort();
            
            // 3/8
            if (currentList.Contains(1))
            {
                if (currentList.Contains(2))
                {
                    if (currentList.Contains(3))
                    {
                        return true;
                    }
                }

                if (currentList.Contains(4))
                {
                    if (currentList.Contains(7))
                    {
                        return true;
                    }
                }

                if (currentList.Contains(5))
                {
                    if (currentList.Contains(9))
                    {
                        return true;
                    }
                }
            }

            // 1/8
            if (currentList.Contains(2))
            {
                if (currentList.Contains(5))
                {
                    if (currentList.Contains(8))
                    {
                        return true;
                    }
                }

            }

            // 2/8
            if (currentList.Contains(3))
            {
                if (currentList.Contains(5))
                {
                    if (currentList.Contains(7))
                    {
                        return true;
                    }
                }

                if (currentList.Contains(6))
                {
                    if (currentList.Contains(9))
                    {
                        return true;
                    }
                }
            }

            // 1/8
            if (currentList.Contains(4))
            {
                if (currentList.Contains(5))
                {
                    if (currentList.Contains(6))
                    {
                        return true;
                    }
                }

            }

            // 1/8
            if (currentList.Contains(7))
            {
                if (currentList.Contains(8))
                {
                    if (currentList.Contains(9))
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        private void DisplayText(int turns, string letter, bool gameWon)
        {
            if (turns < 9 && !gameWon)
            {
                if (letter == "X")
                {
                    letter = "O";
                }
                else
                {
                    letter = "X";
                }
                txtInfo.Text = letter + "'s Turn";
            }

            if (turns == 9 && !gameWon)
            {
                txtInfo.Text = "Tie Game";
            }

            if (gameWon)
            {
                txtInfo.Text = letter + "'s Won";
                foreach (Button button in playButtons)
                {
                    button.IsEnabled = false;
                }
            }
        }

        
    }
}
