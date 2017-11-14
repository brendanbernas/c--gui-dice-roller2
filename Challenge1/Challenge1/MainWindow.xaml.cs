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

namespace Challenge1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int opponentScore = 0;
        int userScore = 0;
        bool isFirstGame = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {

            //check for flag, if first game, initialize the controls to visible
            if (isFirstGame)
                InitializeGame();


            Dice dice = new Dice();

            //rolling dice for int from 1-6
            int userRoll = dice.roll();
            int opponentRoll = dice.roll();

            //setting the label to the roll
            lblUserRoll.Content = userRoll;
            lblOpponentRoll.Content = opponentRoll;

            //setting the dice image to the roll
            SwitchImageDiceImage(imageUserRoll, userRoll);
            SwitchImageDiceImage(imageOpponentRoll, opponentRoll);

            //get outcome of the game and display it
            if (userRoll > opponentRoll)
            {
                lblOutcome.Content = "You win!";
                userScore++;
            }   
            else if (opponentRoll > userRoll)
            {
                lblOutcome.Content = "You lose";
                opponentScore++;
            }
            else
                lblOutcome.Content = "Tie";

            this.updateScore();
        }

        private void SwitchImageDiceImage(Image imageControl, int rollNum)
        {
            //get roll number and based on integer, change the image of the image control
            switch(rollNum)
            {
                case 1:
                    imageControl.Source = new BitmapImage(new Uri("Images/side1.png", UriKind.Relative));
                    break;
                case 2:
                    imageControl.Source = new BitmapImage(new Uri("Images/side2.png", UriKind.Relative));
                    break;
                case 3:
                    imageControl.Source = new BitmapImage(new Uri("Images/side3.png", UriKind.Relative));
                    break;
                case 4:
                    imageControl.Source = new BitmapImage(new Uri("Images/side4.png", UriKind.Relative));
                    break;
                case 5:
                    imageControl.Source = new BitmapImage(new Uri("Images/side5.png", UriKind.Relative));
                    break;
                case 6:
                    imageControl.Source = new BitmapImage(new Uri("Images/side6.png", UriKind.Relative));
                    break;
            }
        }

        private void InitializeGame()
        {
            //set controls to visible
            lblYourRollDesc.Visibility = Visibility.Visible;
            lblOpponentRollDesc.Visibility = Visibility.Visible;
            lblUserRoll.Visibility = Visibility.Visible;
            lblOpponentRoll.Visibility = Visibility.Visible;
            lblOutcome.Visibility = Visibility.Visible;
            imageUserRoll.Visibility = Visibility.Visible;
            imageOpponentRoll.Visibility = Visibility.Visible;
            //set flag to false so this code doesn't run again
            isFirstGame = false;
        }

        private void updateScore()
        {
            lblScore.Content = "Score: " +
                "\nUser - " + userScore +
                "\nOpponent - " + opponentScore;
        }
    }
}
