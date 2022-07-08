using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
