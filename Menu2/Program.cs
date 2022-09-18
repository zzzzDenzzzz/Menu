using System;

namespace Menu2
{
    internal class Program
    {
        internal class MyClass
        {
            public static void Method1()
            {
                Console.WriteLine("Выбрано действие 1");
            }
            public static void Method2()
            {
                Console.WriteLine("Выбрано действие 2");
            }
            public static void Method3()
            {
                Console.WriteLine("Выбрано действие 3");
            }
            public static void Exit()
            {
                Console.WriteLine("Приложение заканчивает работу!");
                Environment.Exit(0);
            }
        }

        internal class MenuItem
        {
            public string Name { get; }
            public Action[] action;

            public MenuItem(string name, params Action[] action)
            {
                Name = name;
                this.action = action;
            }
        }

        internal class Menu
        {
            public string Name { get; }
            public MenuItem[] menuItems;

            public Menu(string name, params MenuItem[] menuItems)
            {
                Name = name;
                this.menuItems = menuItems;
            }

            public void OutputToConsole()
            {
                Console.WriteLine(Name);
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine("  " + menuItems[i].Name);
                    for (int j = 0; j < menuItems[i].action.Length; j++)
                    {
                        Console.Write("    ");
                        menuItems[i].action[j].Invoke();
                    }
                }
            }
        }

        internal class MyTestClass
        {
            public static void Print()
            {
                Console.WriteLine("MyTestClass");
            }
        }

        static void Main(string[] args)
        {
            var menu = new Menu("Меню",
                                   new MenuItem("Выбрать фигуру",
                                                    MyClass.Method1,
                                                    MyClass.Method2,
                                                    MyClass.Method3),
                                   new MenuItem("Показать выбранные фигуры",
                                                    MyTestClass.Print),
                                   new MenuItem("Все фигуры"),
                                   new MenuItem("Выход",
                                                    MyClass.Exit));

            menu.OutputToConsole();
        }
    }
}
