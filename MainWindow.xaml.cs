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
using System.Windows.Threading;

namespace Automatische_Bewegung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rng = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            // Ereignisse können auch an dieser Stelle generiert werden
            // wir schreiben timer.Tick += und drücken Tab.

            timer.Tick += Timer_Tick;
            TimeSpan timespan = TimeSpan.FromSeconds(dt);
            timer.Interval = timespan;
        }
        double dt = 1.0 / 60.0; //ist die Zeitveränderung pro Tick

        private void Timer_Tick(object sender, EventArgs e)
        {
            //x(t) = vx * t + x0;
            x = vx * dt + x;
            y = vy * dt + y;
            SetPosition(box, x, y);
        }
        

        double x, y;
        double vx = 50, vy = 20;


        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            /*         (x(t))
             *  s(t) = (y(t))
             *  x(t) = vx * t;
             *  y(t) = vy * t;
             */

            x = Canvas.GetLeft(box);
            y = Canvas.GetBottom(box);
            timer.Start();
        }
        private void SetPosition (UIElement moving, double neuesX, double neuesY)
        {
            Canvas.SetBottom(moving, neuesY);
            Canvas.SetLeft(moving, neuesX);
        }

        

    }
}
