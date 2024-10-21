using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Wpf21._10._2024
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        private DispatcherTimer timer;
        private bool _flag = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            redText.ToolTip = "красный цвет";
            greenText.ToolTip = "зеленый цвет";
            blueText.ToolTip = "синий цвет";

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_Tick;
            timer.Start();        
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb((byte)redSlider.Value,
                                        (byte)greenSlider.Value,
                                        (byte)blueSlider.Value);
            Background = new SolidColorBrush(color);
        }

        private void timer_Tick(object sender, EventArgs e) 
        {
            
            if (_flag)
            {
                status.Items.Clear();
                status.Items.Add(DateTime.Now.ToShortDateString());
            }
            else
            {              
                status.Items.Clear();
                status.Items.Add(DateTime.Now.ToShortTimeString());
            }

            _flag = !_flag;
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hide_Window(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
