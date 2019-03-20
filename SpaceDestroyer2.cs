using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceDestroyer2
{
    class SpaceDestroyer2
    {

        public void Clean()
        {
            do
            {
                string fileName = SelectFile();
                bool result = false;
                if (fileName != "")
                    result = CleanFile(fileName);
                if (result)
                    Console.WriteLine("SUCCESS");

            } while (AskAnother());
        }
   
        private static string SelectFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            Console.WriteLine("CHOOSE FILE TO CLEAN");
            if (fileDialog.ShowDialog() == DialogResult.OK)
                return fileDialog.FileName;
            else
                return "";
        }

     
        private static bool CleanFile(string fileName)
        {
            Console.WriteLine("CLEANING......");
            try
            {
                List<string> outputLines = new List<string>();
                List<string> lines = System.IO.File.ReadAllLines(fileName).ToList();
                foreach (string line in lines)
                {
                    string tempLine = line;
                    while (tempLine.IndexOf("  ") != -1)
                        tempLine = tempLine.Replace("  ", " ");
                    outputLines.Add(tempLine);
                }
                System.IO.File.Delete(fileName);
                System.IO.File.WriteAllLines(fileName, outputLines);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool AskAnother()
        {
            Console.WriteLine("CLEAN ANOTHER FILE?");
            var result = "";
            do
                result = Console.ReadLine().ToUpper().TrimEnd();
            while (result != "Y" && result != "N");
            if (result == "Y")
                return true;
            else
                return false;
        }

    }
}
