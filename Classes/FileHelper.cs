using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poe_Launcher.Classes
{
    public class FileHelper
    {
        public string path = AppDomain.CurrentDomain.BaseDirectory;
        public string poePath;
        public string readData;

        public void SaveFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            var result = ofd.ShowDialog();

            if (result == true)
            {
                poePath = ofd.FileName;
                string value = ofd.FileName;
                File.WriteAllText(path + "poeData.txt", value);
            }
        }

        public void LoadFile()
        {
            if (File.Exists(path + "poeData.txt") == true)
            {
                readData = File.ReadAllText(path + "poeData.txt");
            }
        }
    }
}
