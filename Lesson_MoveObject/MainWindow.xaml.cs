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

namespace Lesson_MoveObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            // Down
            if (e.Key == Key.S && Canvas.GetTop(rectangle) + rectangle.Height < 410)
            {
                Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) + 10);
            }

            // Up
            if (e.Key == Key.W && Canvas.GetTop(rectangle) > 0)
            {
                Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) - 10);
            }

            // Right
            if (e.Key == Key.D && Canvas.GetLeft(rectangle) + rectangle.Width < 790)
            {
                Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) + 10);
            }

            // Left
            if (e.Key == Key.A && Canvas.GetLeft(rectangle) > 0)
            {
                Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) - 10);
            }
        }
    }
}