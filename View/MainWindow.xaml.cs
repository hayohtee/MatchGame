using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock? lastTextBlockClicked;
        bool isHidden = false;

        public MainWindow()
        {
            InitializeComponent();

            SetupGame();
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
                int index = random.Next(emojiList.Count);
                textBlock.Text = emojiList[index];
                emojiList.RemoveAt(index);
            }
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
