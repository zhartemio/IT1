using System;
using System.IO;
using System.Windows;


namespace ТI1
{
    class FileWriter
    {
        private string FileName;

        public FileWriter(string fileName)
        {
            FileName = fileName;
        }

        public void WriteToFile(string text)
        {
            try
            {
                
                using (StreamWriter writer = new StreamWriter(FileName, true))
                {
                    writer.WriteLine(text); 
                }
                MessageBox.Show("Результат записан в файл!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
