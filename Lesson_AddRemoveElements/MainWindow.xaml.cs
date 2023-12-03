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

using System.Windows.Threading; // for timer

namespace Lesson_AddRemoveElements
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Canvas) // is - проверка является ли объект типом данных
            {
                Rectangle rectangle = new Rectangle();

                rectangle.Width = 50;
                rectangle.Height = 50;
                rectangle.Fill = Brushes.Blue;

                Canvas.SetTop(rectangle, e.GetPosition(MyCanvas).Y - rectangle.Height / 2);
                Canvas.SetLeft(rectangle, e.GetPosition(MyCanvas).X - rectangle.Width / 2);

                MyCanvas.Children.Add(rectangle);

                rectangles.Add(rectangle);
            }    
            else
            {
                MyCanvas.Children.Remove((Rectangle)e.Source);

                rectangles.Remove((Rectangle)e.Source);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < rectangles.Count; i++)
            {
                Canvas.SetLeft(rectangles[i], Canvas.GetLeft(rectangles[i]) + 5);
            }
        }
    }
}
