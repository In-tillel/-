using System;
using System.Collections.Generic;
using System.IO;

namespace тортики
{
    class Program
    {
        static List<Df> Catalogs = new List<Df>();
        static int CatallogId = 0;
        static int PageId = 0;
        static int PageId2 = 0;
        static bool CatalogOpen = false;
        static int Price = 0;
        static List<string> ListCase = new List<string>();

        static void Main(string[] args)
        {
            Load();
            Open();
        }
        static void Load()
        {
            Catalogs.Add(new Df(
                new List<Gh>() {
                    new Gh(
                        "Форма торта","",new List<Fg>
                        {
                            new Fg("Круг",500),
                            new Fg("Квадрат",500),
                            new Fg("Прямогульник",500),
                            new Fg("Сердечко",500)
                        }
                    ),
                    new Gh(
                        "Размер торта","",new List<Fg>
                        {
                            new Fg("Маленький (Диаметр - 16 см, 8 порций)",1000),
                            new Fg("Маленький (Диаметр - 18 см, 10 порций)",1200),
                            new Fg("Маленький (Диаметр - 28 см, 24 порций)",2000)
                        }
                    ),
                    new Gh(
                        "Вкус коржей","",new List<Fg>
                        {
                            new Fg("Ванильный",100),
                            new Fg("Шоколадный",150),
                            new Fg("Карамельный",160),
                            new Fg("Ягодный",200),
                            new Fg("Кокосовый",250)
                        }
                    ),
                    new Gh(
                        "Количество коржей","",new List<Fg>
                        {
                            new Fg("1 корж",200),
                            new Fg("2 коржа",400),
                            new Fg("3 коржа",600),
                            new Fg("4 коржа",800),
                        }
                    ),
                    new Gh(
                        "Глазурь","",new List<Fg>
                        {
                            new Fg("Шоколад",100),
                            new Fg("Крем",150),
                            new Fg("Бизе",200),
                            new Fg("Драже",250),
                            new Fg("Ягоды",300),
                        }
                    ),
                    new Gh(
                        "Декор","",new List<Fg>
                        {
                            new Fg("Шоколадная",100),
                            new Fg("Ягодная",100),
                            new Fg("Кремовая",100),
                        }
                    ),
                    new Gh( "Конец заказа","save",new List<Fg>() )
                }
            ));
        }
        static void Open()
        {
            Console.Clear();
            Df list = Catalogs[CatallogId];
            if (!CatalogOpen)
            {
                Console.WriteLine($"Заказ тортов!");
                Console.WriteLine($"Выберите параметр торта");
                Console.WriteLine($"------------------------------");

                for (int i = 0; i < list.Pages.Count; i++) Console.WriteLine($"  {list.Pages[i].Name}");
                Console.WriteLine("");
                Console.WriteLine($"Цена: {Price}р");
               

                int next = setCursor(list.Pages.Count, PageId, 3);
                if (next != -1)
                {
                    PageId = next;
                    Open();
                }
            }
            else
            {
                Console.WriteLine($"Для выхода нажмите ESC");
                Console.WriteLine($"Выбирите пункт из меню:");
                Console.WriteLine($"------------------------------");

                for (int i = 0; i < list.Pages[PageId].Buttons.Count; i++) Console.WriteLine($"  {list.Pages[PageId].Buttons[i].Name} - {list.Pages[PageId].Buttons[i].Price}р");

                int next = setCursor(list.Pages[PageId].Buttons.Count, PageId2, 3);
                if (next != -1)
                {
                    PageId2 = next;
                    Open();
                }
            }
        }

        static int setCursor(int count, int type, int start)
        {
            Console.SetCursorPosition(0, type + start);
            Console.WriteLine("->");

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (type + start != start) type -= 1;
                else type = count - 1;
                Console.SetCursorPosition(0, type + start);
                Console.WriteLine("->");
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (type != count - 1) type += 1;
                else type = 0;
                Console.SetCursorPosition(0, type + start);
                Console.WriteLine("->");
            }
            
            else if (key.Key == ConsoleKey.Escape)
            {
                if (CatalogOpen)
                {
                    CatalogOpen = false;
                    type = 0;
                }
            }
            return type;
        }  
    }
}