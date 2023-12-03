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

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                bLeft = true;
                Debug.WriteLine("Start move left");
            }
            else if (e.Key == Key.D)
            {
                bRight = true;
                Debug.WriteLine("Start move right");
            }
        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                bLeft = false;
                Debug.WriteLine("End move left");
            }
            else if (e.Key == Key.D)
            {
                bRight = false;
                Debug.WriteLine("End move right");
            }
        }
    }
}
