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

namespace Lesson_GenerateElements
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button button = new Button();

        public MainWindow()
        {
            InitializeComponent();

            button.Background = Brushes.Yellow;
            button.Content = "Click ME!";
            button.Width = 350;
            button.Height = 100;
            button.FontSize = 30;

            // add event
            button.Click += Button_Click;

            Grid1.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            button.Background = Brushes.Green;
        }
    }
}