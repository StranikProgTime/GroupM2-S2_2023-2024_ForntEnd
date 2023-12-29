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

using System.Diagnostics;   // Stopwatch, Debug

namespace Lesson_RenderingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double x = 0;
        private double y = 0;

        private double speedX = 100;
        private double speedY = 200;

        private TimeSpan prevTime;
        private Stopwatch stopwatch = Stopwatch.StartNew();

        public MainWindow()
        {
            InitializeComponent();

            CompositionTarget.Rendering += CompositionTarget_Rendering;

            prevTime = stopwatch.Elapsed;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopwatch.Elapsed;
            double delta = (currentTime - prevTime).TotalSeconds;
            prevTime = currentTime;

            lblInfo.Content = delta;
            // 0.016

            // action
            x = x + speedX * delta;
            y = y + speedY * delta;

            if (x < 0)
            {
                speedX = -speedX;
            }
            else if (x > MyCanvas.ActualWidth - Ball.Width)
            {
                speedX = -speedX;
            }

            if (y < 0)
            {
                speedY = -speedY;
            }
            else if (y > MyCanvas.ActualHeight - Ball.Height)
            {
                speedY = -speedY;
            }

            Canvas.SetLeft(Ball, x);
            Canvas.SetTop(Ball, y);
        }
    }
}
