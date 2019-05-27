#region Using
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
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using Poe_Launcher.Classes;

#endregion

namespace Poe_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Uris uris = new Uris();
        public string path = AppDomain.CurrentDomain.BaseDirectory;

        public MainWindow()
        {
            
            InitializeComponent();
            
            Poe_Browser.Navigate(uris.PoeMainWeb);

            if (File.Exists(path + "poeData.txt") == true)
            {
               textBox.Text = File.ReadAllText(path + "poeData.txt");                
            }            
        }        
        private void Start_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                Process.Start(textBox.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
        private void Open_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            var result = ofd.ShowDialog();

            if (result == true)
            {
                textBox.Text = ofd.FileName;
                string value = ofd.FileName;
                File.WriteAllText(path + "poeData.txt", value);
            }
        }
        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void PoeMain_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Poe_Browser.Navigate(uris.PoeMainWeb);
        }

        private void PoeTradeExternal_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Poe_Browser.Navigate(uris.PoeTradeExternal);
        }

        private void PoeTradeInternal_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Poe_Browser.Navigate(uris.PoeTradeInternal);
        }

        private void PoeNinja_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Poe_Browser.Navigate(uris.PoeNinja);
        }
    }
}
