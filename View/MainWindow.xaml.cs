using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock? lastTextBlockClicked;
        bool isHidden = false;

        DispatcherTimer timer = new DispatcherTimer();
        int numMatches;
        int tenthOfSecondElapsed;

        public MainWindow()
        {
            InitializeComponent();

            SetupGame();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += TimerTick;
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            tenthOfSecondElapsed++;
            timerTextBlock.Text = (tenthOfSecondElapsed / 10F).ToString("0.0s");
        
            if (numMatches == 8)
            {
                timer.Stop();
                timerTextBlock.Text = timerTextBlock.Text + " - Play again";
            }
        }

        
        void SetupGame()
        {
            Random random = new Random();

            List<string> emojiList = new List<string>()
            {
                "🚚", "🚚",
                "😍", "😍",
                "😡", "😡",
                "🐵", "🐵",
                "🦁", "🦁",
                "🦋", "🦋",
                "🛒", "🛒",
                "🎨", "🎨"
            };

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name == "timerTextBlock")
                    break;

                int index = random.Next(emojiList.Count);
                textBlock.Text = emojiList[index];
                emojiList.RemoveAt(index);
            }

            timer.Start();
            tenthOfSecondElapsed = 0;
            numMatches = 0;

        }

        private void ToggleVisibility_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;

            if (!isHidden)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                isHidden = true;
            }
            else if (lastTextBlockClicked.Text == textBlock.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                numMatches++;
                isHidden = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                isHidden = false;
            }

        }
    }
}
