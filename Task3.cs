using System;
using System.Text;

static class Task3
{
    public static void Run()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Завдання 3 — Оптимізований перебір для дешифрування");
        Console.Write("Введіть текст для шифрування: ");
        string input = Console.ReadLine() ?? string.Empty;
        string normalized = Normalize(input);
        if (string.IsNullOrEmpty(normalized))
        {
            Console.WriteLine("Після нормалізації вхід порожній. Повертаюсь у меню.");
            Console.WriteLine("Натисніть Enter...");
            Console.ReadLine();
            return;
        }
        int key = GetRandomKey();
        string encrypted = Encrypt(input, key);
        Console.WriteLine($"\nЗгенеровано ключ: {key}");
        Console.WriteLine($"Зашифрований текст:\n{encrypted}");
        int iterations = OptimizedBruteForce(encrypted, normalized, out int foundKey, out string foundPlain);
        if (iterations >= 0)
        {
            Console.WriteLine($"\nКількість ітерацій (оптимізовано): {iterations}");
            Console.WriteLine($"Знайдений ключ: {foundKey}");
            Console.WriteLine($"Розшифрований текст: {foundPlain}");
        }
        else
        {
            Console.WriteLine("Не вдалося знайти відповідність під час перебору.");
        }

        Console.WriteLine("\nНатисніть Enter, щоб повернутись у меню...");
        Console.ReadLine();
    }

    static string Normalize(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        var sb = new StringBuilder();
        input = input.ToLowerInvariant();
        foreach (char ch in input)
        {
            if (ch >= 'a' && ch <= 'z') sb.Append(ch);
        }
        return sb.ToString();
    }

    static int GetRandomKey()
    {
        var rnd = new Random();
        return rnd.Next(1, 26);
    }

    static string Encrypt(string input, int key)
    {
        var sb = new StringBuilder();
        string normalized = Normalize(input);
        foreach (char ch in normalized)
        {
            int shifted = ((ch - 'a') + key) % 26;
            sb.Append((char)('a' + shifted));
        }
        return sb.ToString();
    }

    static string DecryptWithKey(string encrypted, int key)
    {
        var sb = new StringBuilder();
        foreach (char ch in encrypted)
        {
            int shifted = ((ch - 'a') - key) % 26;
            if (shifted < 0) shifted += 26;
            sb.Append((char)('a' + shifted));
        }
        return sb.ToString();
    }
    static int OptimizedBruteForce(string encrypted, string target, out int foundKey, out string foundPlain)
    {
        foundKey = -1;
        foundPlain = string.Empty;
        if (string.IsNullOrEmpty(encrypted) || string.IsNullOrEmpty(target)) return -1;

        int candidate = ((encrypted[0] - target[0]) % 26 + 26) % 26; 
        if (candidate == 0) candidate = 26;
        int iterations = 0;
        if (candidate >= 1 && candidate <= 25)
        {
            iterations++;
            string plain = DecryptWithKey(encrypted, candidate);
            if (plain == target)
            {
                foundKey = candidate;
                foundPlain = plain;
                return iterations;
            }
        }

        for (int k = 1; k <= 25; k++)
        {
            if (k == candidate) continue;
            iterations++;
            string plain = DecryptWithKey(encrypted, k);
            if (plain == target)
            {
                foundKey = k;
                foundPlain = plain;
                return iterations;
            }
        }

        return -1;
    }
}

