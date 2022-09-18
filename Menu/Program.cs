using System;

namespace Menu
{
    class Program
    {
        static void Method1()
        {
            Console.WriteLine("Выбрано действие 1");
        }
        static void Method2()
        {
            Console.WriteLine("Выбрано действие 2");
        }
        static void Method3()
        {
            Console.WriteLine("Выбрано действие 3");
        }
        static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");
            Environment.Exit(0);
        }
        static void methods(int counter)
        {
            if (counter == 0)
                Method1();
            else if (counter == 1)
                Method2();
            else if (counter == 2)
                Method3();
            else Exit();

        }
        static void Main(string[] args)
        {
            while (true)
            {
                int counter;
                string[] items = { "Действие 1", "Действие 2", "Действие 3", "Выход" };

                PrintMenu(items, out counter);
                methods(counter);
                Console.ReadKey();
            }

        }
        static int PrintMenu(string[] menuitems, out int counter)
        {
            counter = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuitems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine(menuitems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(menuitems[i]);
                    }
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuitems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuitems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}
