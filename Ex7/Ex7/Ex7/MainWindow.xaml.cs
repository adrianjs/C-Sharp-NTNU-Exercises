using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ex7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string StartText;
        private bool IsBold, IsItalic, LowerUpper, BackgroundChanged;
        SolidColorBrush color1 = new SolidColorBrush(Color.FromRgb(0,255,255));
        SolidColorBrush color2 = new SolidColorBrush(Color.FromRgb(128, 0, 0));

        public MainWindow()
        {
            InitializeComponent();
            StartText = TextEdit.Text;
            LowerUpper = true;
            IsBold = false;
            IsItalic = false;
            Cursor = Cursors.Arrow;
        }

        private void ReverseTextButton_Click(object sender, RoutedEventArgs e)
        {
            char[] temp = TextView.Text.ToArray();
            string res = "";
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                res += temp[i];
            }
            TextView.Text = res;
        }


        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            TextView.Text = TextEdit.Text;
            TextCharCount.Text = CountCharacters(TextEdit.Text.ToString()).ToString();
            if (TextEdit.Text == "") { MessageBox.Show("TextField is empty, nothing to show!\n Try again!", "Warning"); }
        }

        private void RemoveTextButton_Click(object sender, RoutedEventArgs e)
        {
            TextView.Text = "";
            TextEdit.Text = "";
            TextCharCount.Text = "0";
            MessageBox.Show("Text removed", "Message");
        }


        private void RemoveCharButton_Click(object sender, RoutedEventArgs e)
        {
            string temp = Regex.Replace(TextView.Text, "[^0-9a-zA-Z]+", " ");
            TextView.Text = temp;
        }



        private void BackwardsButton_Click(object sender, RoutedEventArgs e)
        {
            string temp = TextView.Text;
            string[] reverseWord = temp.Split();
            temp = "";

            for (int i = reverseWord.Length-1; i >= 0; i--)
            {
                temp += reverseWord[i];
                if (i != 0)
                {
                    temp += " ";
                }
            }
            TextView.Text = temp;
        }


        private void CaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (LowerUpper)
            {
                TextView.Text = TextView.Text.ToLower();
                LowerUpper = false;
            }
            else
            {
                TextView.Text = TextView.Text.ToUpper();
                LowerUpper = true;
            }
        }



        private void CapitalLetterButton_Click(object sender, RoutedEventArgs e)
        {
            string[] temp = TextView.Text.ToString().Split();
            string s = "";
            for (int i = 0; i < temp.Length; i++)
            {
                s += CapitalLetterText(temp[i]);
            }
            TextView.Text = s;
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsItalic)
            {
                TextView.FontStyle = FontStyles.Italic;
                IsItalic = true;
            }
            else
            {
                TextView.FontStyle = FontStyles.Normal;
                IsItalic = false;
            }
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsBold)
            {
                TextView.FontWeight = FontWeights.Bold;
                IsBold = true;
            }
            else
            {
                TextView.FontWeight = FontWeights.Normal;
                IsBold = false;
            }
        }

        private void BGCButton_Click(object sender, RoutedEventArgs e)
        {
            if (!BackgroundChanged)
            {
                Grid.Background = Brushes.Black;
                BackgroundChanged = true;
            }
            else
            {
                Grid.Background = Brushes.CadetBlue;
                BackgroundChanged = false;
            }
        }


        // Helper methods

        private bool TextChanged(string a, string b)
        {
            return a == b;
        }

        private void InformTextChanged(string a, string b)
        {
            if (TextChanged(a, b))
            {
                MessageBox.Show("Text not changed!", "Try again");
            }
        }

        private string CapitalLetterText(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private int CountCharacters(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString() != " ")
                {
                    count++;
                }
            }
            return count;
        }

        private void RemoveCharButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.IBeam;
        }

        private void RemoveCharButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void CaseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Pen;
        }

        private void CaseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void BackwardsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Wait;
        }

        private void BackwardsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void RemoveTextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.ArrowCD;
        }

        private void RemoveTextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void ReverseTextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void ReverseTextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Button_StyleEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }


        private void Button_StyleDefault(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
