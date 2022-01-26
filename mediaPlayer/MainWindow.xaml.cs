using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Threading;

namespace mediaPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filename;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mePlayer.Source != null)
            {
                if (mePlayer.NaturalDuration.HasTimeSpan)
                {
                    lblStatus.Content = String.Format("{0} / {1}", mePlayer.Position.ToString(@"mm\:ss"), mePlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                }
            }
            else
            {
                lblStatus.Content = "No file selected...";
            }
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();
        }
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = false,
                DefaultExt = ".mp3"
            };
            fileDialog.ShowDialog();
            filename = fileDialog.FileName;
            //mePlayer(new Uri(filename));
        }
    }
}
