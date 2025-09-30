using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Шифр Цезаря з випадковим ключем");
        Console.Write("Введіть текст для шифрування: ");
        string input = Console.ReadLine() ?? "";

        int key = GetRandomKey();

        string encrypted = Encrypt(input, key);
        Console.WriteLine($"\nКлюч: {key}");
        Console.WriteLine($"\nЗашифрований текст:\n{encrypted}");

        Console.WriteLine("\nНатисніть Enter для виходу...");
        Console.ReadLine();
    }
    static int GetRandomKey()
    {
        var rnd = new Random();
        return rnd.Next(1, 26);
    }
    static string Encrypt(string input, int key)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        var sb = new StringBuilder();
        input = input.ToLowerInvariant();
        foreach (char ch in input)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                int shifted = ((ch - 'a') + key) % 26;
                sb.Append((char)('a' + shifted));
            }
        
        }
        return sb.ToString();
    }
}
