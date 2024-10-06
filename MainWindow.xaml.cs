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

namespace TIC_TAC_TOE_GAME_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int player;
        
        public MainWindow()
        {
           
            InitializeComponent();
            player = 1;
            CurrentPlayer.Content = TextBox1.Text; 
            Restart.Foreground =  new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Restart.FontSize = 40;

            
        }

        private void Cell1_Click(object sender, RoutedEventArgs e)
        {
            
           

            if (sender is Button button)
            {
                button.FontSize = 50;
                button.IsEnabled = false;
                

                switch (player)
                {
                    case 1:
                        button.Content = "X";  
                        button.Foreground = new SolidColorBrush(Color.FromRgb(0, 3, 166));
                        button.FontWeight = FontWeights.Bold;
                        player = 0;
                        
                        CurrentPlayer.Content = TextBox2.Text; ;
                        break;

                    case 0:
                        button.Content = "O";
                        button.Foreground = new SolidColorBrush(Color.FromRgb(255, 28, 28));
                        button.FontWeight = FontWeights.Bold;
                        player = 1;
                        CurrentPlayer.Content = TextBox1.Text; 
                        break;
                }
                CheckWin();
            }



        }

        private void CheckWin()
        {
            string[,] cells = new string[3, 3]
            {
        { Cell1.Content?.ToString(), Cell2.Content?.ToString(), Cell3.Content?.ToString() },
        { Cell4.Content?.ToString(), Cell5.Content?.ToString(), Cell6.Content?.ToString() },
        { Cell7.Content?.ToString(), Cell8.Content?.ToString(), Cell9.Content?.ToString() }
            };

            var winningCombinations = new string[]
            {
                        "012", // H        /*   0 1 2
                        "345",  // H            3 4 5
                        "678",  // H            6 7 8  */
                        "036", // V
                        "147",   // V
                        "258",   // V
                        "048",  // D
                        "246"   // D
                            };

            foreach (string combination in winningCombinations)

            {
                
                char firstCellContent = cells[int.Parse(combination[0].ToString()) / 3, int.Parse(combination[0].ToString()) % 3]?.FirstOrDefault() ?? '\0';
                
                if (firstCellContent != '\0' && combination.All(cellIndex => cells[int.Parse(cellIndex.ToString()) / 3, int.Parse(cellIndex.ToString()) % 3]?.FirstOrDefault() == firstCellContent))
                {
                    string winner = CurrentPlayer.Content.ToString() == TextBox1.Text ? TextBox2.Text : TextBox1.Text;
                    GAME_OVER gameOverForm = new GAME_OVER();
                    gameOverForm.game_over_lb.Content = "GAME OVER!";
                    gameOverForm.have_winner_lb.Content = "WE HAVE A WINNER :";
                    gameOverForm.winner_lb.Content = winner;
                  
                    gameOverForm.ShowDialog(); 
                    var cellsa = new List<Button> { Cell1, Cell2, Cell3, Cell4, Cell5, Cell6, Cell7, Cell8, Cell9 };
                    foreach (Button button in cellsa)
                    {
                        button.IsEnabled = false;
                    }
                    return;
                }
            }
        }

        private void RestartButton(object sender, RoutedEventArgs e)
        {
            player = 1;
            CurrentPlayer.Content = null;
            var cells = new List<Button> { Cell1, Cell2, Cell3, Cell4, Cell5, Cell6, Cell7, Cell8, Cell9 };
            foreach (var cell in cells)
            {
                cell.Content = null;
                cell.IsEnabled = true;
            }
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
