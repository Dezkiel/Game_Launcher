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
        FileHelper FileHelper = new FileHelper();
        public string path = AppDomain.CurrentDomain.BaseDirectory;

        public MainWindow()
        {
            
            InitializeComponent();

            Poe_Browser.Navigate(Uris.PoeMainWeb);

            FileHelper.LoadFile();
            textBox.Text = FileHelper.readData;                   
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
            FileHelper.SaveFile();
            textBox.Text = FileHelper.poePath;           
        }
        private void Exit_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
       
    }
}
