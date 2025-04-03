using System.Windows;
using System.Windows.Controls;

namespace ТI1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static string FileReadPath = "D:\\Жигимонт\\Уник\\ТИ\\ТI1\\ТI1\\file1.txt";
    private static string FileWritePath = "D:\\Жигимонт\\Уник\\ТИ\\ТI1\\ТI1\\file2.txt";


    private char[] enAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private char[] ruAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();


    private static char[] numbers = "123456789".ToCharArray();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(TextBox1.Text != "" && KeyBox.Text != "")
        {
            EnsipherButton.IsEnabled = true;
            DesipherButton.IsEnabled = true;

        }
        else
        {
            EnsipherButton.IsEnabled = false;
            DesipherButton.IsEnabled = false;
        }
        TextBox2.Text = "";

    }

    private void EnsipherButton_Click(object sender, RoutedEventArgs e)
    {
        if (IsKeyCorrect(KeyBox.Text))
        {
            int key = int.Parse(KeyBox.Text);
            if (AreCoprime(key, enAlphabet.Length))
            {
                Sipherator sipherator = new Sipherator(key, enAlphabet);
                TextBox2.Text = sipherator.Ensipher(TextBox1.Text);
            }
            else
            {
                MessageBox.Show("Ключ и длина алфавита не взаимно простые", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                KeyBox.Text = "";
            }
        }
        else
        {
            MessageBox.Show("Некорректный ключ. Пожалуйста, введите правильный ключ.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            KeyBox.Text = "";
        }
    }

    private void DesipherButton_Click(object sender, RoutedEventArgs e)
    {
        if (IsKeyCorrect(KeyBox.Text))
        {
            int key = int.Parse(KeyBox.Text);
            if (AreCoprime(key, enAlphabet.Length))
            {
                Desipherator desipherator = new Desipherator(key, enAlphabet);
                desipherator.SetSecondRow(key);
                TextBox2.Text = desipherator.Desipher(TextBox1.Text);
                desipherator.ClearSecondRow();
            }
            else
            {
                MessageBox.Show("Ключ и длина алфавита не взаимно простые", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                KeyBox.Text = "";
            }
        }
        else
        {
            MessageBox.Show("Некорректный ключ. Пожалуйста, введите правильный ключ.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            KeyBox.Text = "";
        }
    }

    public Boolean IsKeyCorrect(string key)
    {
        
        foreach(char c in key)
        {
            if (!(numbers.Contains(c)))
            {
                return false;
            }
        }
        return true;
    }

    static bool AreCoprime(int a, int b)
    {
        return GCD(a, b) == 1;
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private void ReadFileButton_Click(object sender, RoutedEventArgs e)
    {
        FileReader reader = new FileReader(FileReadPath);
        reader.ReadFile(TextBox1);
    }
    private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
    {
        SaveToFileButton.IsEnabled = TextBox2.Text != "";
    }

    private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
    {
        FileWriter writer = new FileWriter(FileWritePath);  
        writer.WriteToFile(TextBox2.Text);
    }

    private void EnsipherVigButton_Click(object sender, RoutedEventArgs e)
    {
        bool canContinue = true;
        VigSipherator sipherator = new VigSipherator(KeyWordTextBox.Text, ruAlphabet);
        TextBox3.Text = sipherator.CleanTextBox(TextBox3.Text);
        KeyWordTextBox.Text = sipherator.CleanTextBox(KeyWordTextBox.Text);
        canContinue = TextBox3.Text != "" && KeyWordTextBox.Text != "";
        if (canContinue)
        {
            TextBox4.Text = sipherator.VigEnsipher(TextBox3.Text);
        }
    }

    private void Vigener_TextChanged(object sender, TextChangedEventArgs e)
    {
        EnsipherVigButton.IsEnabled = TextBox3.Text != "" && KeyWordTextBox.Text != "";
        DesipherVigButton.IsEnabled = TextBox3.Text != "" && KeyWordTextBox.Text != "";
        TextBox4.Text = "";
    }

    private void DesipherVigButton_Click(object sender, RoutedEventArgs e)
    {
        bool canContinue = true;
        VigDesipherator sipherator = new VigDesipherator(KeyWordTextBox.Text, ruAlphabet);
        TextBox3.Text = sipherator.CleanTextBox(TextBox3.Text);
        KeyWordTextBox.Text = sipherator.CleanTextBox(KeyWordTextBox.Text);
        canContinue = TextBox3.Text != "" && KeyWordTextBox.Text != "";
        if (canContinue)
        {
            TextBox4.Text = sipherator.VigDensipher(TextBox3.Text);
        }
    }

    private void ReadVigFromFileButton_Click(object sender, RoutedEventArgs e)
    {
        FileReader reader = new FileReader(FileReadPath);
        reader.ReadFile(TextBox3);
    }

    private void TextBox4_TextChanged(object sender, TextChangedEventArgs e)
    {
        SaveVigToFileButton.IsEnabled = TextBox4.Text != "";
    }

    private void SaveVigToFileButton_Click(object sender, RoutedEventArgs e)
    {
        FileWriter writer = new FileWriter(FileWritePath);
        writer.WriteToFile(TextBox4.Text);
    }
}