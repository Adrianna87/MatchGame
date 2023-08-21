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

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "😸", "😸",
                "🐷", "🐷",
                "🐮", "🐮",
                "🐸", "🐸",
                "🐼", "🐼",
                "🐰", "🐰",
                "🦒", "🦒",
                "🐵", "🐵",
            };

            Random randon = new Random();

            foreach (TextBlock textblock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = randon.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textblock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textblock = (TextBlock)sender as TextBlock;
            if (findingMatch == false)
            {
                textblock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textblock;
                findingMatch = true;
            }
            else if (textblock.Text == lastTextBlockClicked.Text)
            {
                textblock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}
