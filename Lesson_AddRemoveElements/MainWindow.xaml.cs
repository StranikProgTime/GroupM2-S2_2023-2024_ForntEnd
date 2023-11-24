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

namespace Lesson_AddRemoveElements
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = new Rectangle();

            rectangle.Width = 50;
            rectangle.Height = 50;
            rectangle.Fill = Brushes.Blue;

            Canvas.SetTop(rectangle, e.GetPosition(MyCanvas).Y - rectangle.Height / 2);
            Canvas.SetLeft(rectangle, e.GetPosition(MyCanvas).X - rectangle.Width / 2);

            MyCanvas.Children.Add(rectangle);
        }
    }
}
