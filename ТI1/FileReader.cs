using System.IO;
using System.Windows.Controls;
using System.Windows;


public class FileReader
{
    private string FileName;

    public FileReader(string fileName)
    {
        FileName = fileName;
    }

    public void ReadFile(TextBox textBox)
    {
        try
        {
            if (File.Exists(FileName))
            {
                string content = File.ReadAllText(FileName);
                textBox.Text = content;
            }
            else
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}