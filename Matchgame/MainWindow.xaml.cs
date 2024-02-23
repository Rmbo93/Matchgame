using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Matchgame
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int tenthsOfSecondsElapsed;
        private int matchesFound;

        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();

            // Set up the game timer
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void SetUpGame()
        {
            // List of emojis for the game
            List<string> animalEmoji = new List<string>()
            {
                "🦁","🦁",
                "🐶","🐶",
                "🐯","🐯",
                "🐴","🐴",
                "🐼","🐼",
                "🐭","🐭",
                "🦉","🦉",
                "🦜","🦜",
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock") // Ensure we don't set an emoji to the timer TextBlock
                {
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text += " - Play again?";
            }
        }

        // Event handlers for TextBlocks
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }

            public void Timer_Tick(object sender, EventArgs e)
            {
                tenthsOfSecondsElapsed++;
                timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
                if (matchesFound == 8)
                {
                    timer.Stop();
                    timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
                }
            }
        }
        // Other methods...
    }
}
