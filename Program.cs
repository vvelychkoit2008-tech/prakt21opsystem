using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Виберіть завдання (введіть номер):");
            Console.WriteLine("1) Завдання 1 — Шифр Цезаря");
            Console.WriteLine("2) Завдання 2 — Дешифрування");
            Console.WriteLine("3) Завдання 3 — оптимізація методу перебору");
            Console.WriteLine("0) Вихід");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice)) continue;

            switch (choice.Trim())
            {
                case "1":
                    Task1.Run();
                    break;
                case "2":
                    Task2.Run();
                    break;
                case "3":
                    Task3.Run();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Натисніть Enter, щоб спробувати ще раз...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
