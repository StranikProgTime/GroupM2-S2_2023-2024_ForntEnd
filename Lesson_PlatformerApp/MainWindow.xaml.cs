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

using System.Diagnostics;   // for Debug
using System.Windows.Threading; // for timer

namespace Lesson_PlatformerApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // fields
        private bool bLeft;
        private bool bRight;

        private int drop = 10;
        private int speed = 10;

        private int coins = 0;

        public MainWindow()
        {
            InitializeComponent();
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // gravity
            double y = Canvas.GetTop(Player);
            Canvas.SetTop(Player, y + drop);

            // collision 
            Rect playerCollision = new Rect(
                Canvas.GetLeft(Player),
                y,
                Player.Width,
                Player.Height
            );

            var rectanlges = MyCanvas.Children.OfType<Rectangle>().ToList();

            for (int i = 0; i < rectanlges.Count; i++)
            {
                if (rectanlges[i].Tag != null)
                {
                    if (rectanlges[i].Tag.ToString() == "platform")
                    {
                        Rect platformCollision = new Rect(
                            Canvas.GetLeft(rectanlges[i]),
                            Canvas.GetTop(rectanlges[i]),
                            rectanlges[i].Width,
                            rectanlges[i].Height
                        );

                        if (platformCollision.IntersectsWith(playerCollision))
                        {
                            drop = 0;
                            Canvas.SetTop(Player, Canvas.GetTop(rectanlges[i]) - Player.Height);
                        }
                        else
                        {
                            drop = 10;
                        }
                    }

                    if (rectanlges[i].Tag.ToString() == "coin")
                    {
                        Rect coinCollision = new Rect(
                            Canvas.GetLeft(rectanlges[i]),
                            Canvas.GetTop(rectanlges[i]),
                            rectanlges[i].Width,
                            rectanlges[i].Height
                        );

                        if (coinCollision.IntersectsWith(playerCollision))
                        {
                            coins++;
                            MyCanvas.Children.Remove(rectanlges[i]);
                            Debug.WriteLine("Coin collected");
                        }
                    }

                    if (rectanlges[i].Tag.ToString() == "portal")
                    {
                        Rect portalCollision = new Rect(
                            Canvas.GetLeft(rectanlges[i]),
                            Canvas.GetTop(rectanlges[i]),
                            rectanlges[i].Width,
                            rectanlges[i].Height
                        );

                        if (portalCollision.IntersectsWith(playerCollision))
                        {
                            MessageBox.Show("Collected coins: " + coins);
                        }
                    }
                }
            }

            // player move
            if (bLeft)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - speed);
            }

            if (bRight)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + speed);
            }
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                bLeft = true;
            }
            else if (e.Key == Key.D)
            {
                bRight = true;
            }

            Debug.WriteLine("bLeft: " + bLeft + ", bRight: " + bRight);
        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                bLeft = false;
            }
            else if (e.Key == Key.D)
            {
                bRight = false;
            }

            Debug.WriteLine("bLeft: " + bLeft + ", bRight: " + bRight);
        }
    }
}
