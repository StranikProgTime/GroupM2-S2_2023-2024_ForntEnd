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

using System.Windows.Threading;     // for timer

namespace Lesson_TimerApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // fields
        int left = 0;
        int speed = 10;

        public MainWindow()
        {
            InitializeComponent();

            left = (int)Ball.Margin.Left;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            left += speed;
            Ball.Margin = new Thickness(left, 0, 0, 20);

            if (Ball.Margin.Left > 800 - Ball.Width - 20)
            {
                speed = -5;
            }

            if (Ball.Margin.Left < 0)
            {
                speed = 5;
            }
        }
    }
}
