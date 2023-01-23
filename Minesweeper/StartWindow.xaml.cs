using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void BtnSetMinedFields_Click(object sender, RoutedEventArgs e)
        {
            SetMinedFields setMinedFields = new SetMinedFields();
            setMinedFields.Show();
            this.Close();
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            PlayWindow playWindow = new PlayWindow();
            playWindow.Show();
            this.Close();
        }
    }
}
