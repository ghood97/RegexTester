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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace RegexTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Regex pattern;
        private MatchCollection matches;
        private string matchText;
        public MainWindow()
        {
            InitializeComponent();
            this.pattern = new Regex("");
            matchButton.Click += MatchButton_Click;
        }

        private void MatchButton_Click(object sender, RoutedEventArgs e)
        {
            if(validRegex(patternBox.Text))
            {
                this.pattern = new Regex(patternBox.Text);
                this.matchText = matchTextBox.Text;
                this.matches = this.pattern.Matches(this.matchText);
            }
            else
            {
                MessageBox.Show("Please enter a valid regular expression.");
            }
        }

        private bool validRegex(string pattern)
        {
            bool isValid = true;
            if ((pattern != null) && (pattern.Trim().Length > 0))
            {
                try
                {
                    Regex.Match("", pattern);
                }
                catch (ArgumentException)
                {
                    // BAD PATTERN: Syntax error
                    isValid = false;
                }
            }
            else
            {
                //BAD PATTERN: Pattern is null or blank
                isValid = false;
            }
            return isValid;
        }
    }
}
