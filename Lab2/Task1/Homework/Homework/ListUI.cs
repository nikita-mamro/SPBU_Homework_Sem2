using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class ListUI
    {
        private static void PrintMenu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1 - Добавить элемент на выбранную позицию");
            Console.WriteLine("2 - Удалить элемент по выбранной позиции");
            Console.WriteLine("3 - Получить значение элемента по позиции");
            Console.WriteLine("4 - Установить новое значение элемента по позиции");
            Console.WriteLine("5 - Проверить, пуст ли список");
            Console.WriteLine("6 - Получить размер списка");
            Console.WriteLine("7 - Распечатать список");
            Console.WriteLine("8 - Выйти");
            Console.WriteLine("------------------------------------------");
        }

        private static void ProceedChoice(List list, int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите номер позиции:");

                    if (!int.TryParse(Console.ReadLine(), out int positionAdd))
                    {
                        Console.WriteLine("Номер позиции должен быть целым числом.");
                        break;
                    }

                    Console.WriteLine("Введите добавляемое значение:");

                    if (!int.TryParse(Console.ReadLine(), out int data))
                    {
                        Console.WriteLine("Значение должно быть целым числом.");
                        break;
                    }

                    if (list.Add(data, positionAdd))
                    {
                        Console.WriteLine("Элемент добавлен");
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите номер позиции:");

                    if (!int.TryParse(Console.ReadLine(), out int positionRemove))
                    {
                        Console.WriteLine("Номер позиции должен быть целым числом.");
                        break;
                    }

                    if (list.Remove(positionRemove))
                    {
                        Console.WriteLine("Элемент удалён из списка!");
                    }

                    break;
                case 3:
                    Console.WriteLine("Введите номер позиции:");

                    if (!int.TryParse(Console.ReadLine(), out int positionGet))
                    {
                        Console.WriteLine("Номер позиции должен быть целым числом.");
                        break;
                    }

                    Console.WriteLine($"Значение в данной позиции: {list.GetDataByPosition(positionGet)}");
                    break;
                case 4:
                    Console.WriteLine("Введите номер позиции:");

                    if (!int.TryParse(Console.ReadLine(), out int positionSet))
                    {
                        Console.WriteLine("Номер позиции должен быть целым числом.");
                        break;
                    }

                    Console.WriteLine("Введите новое значение:");

                    if (!int.TryParse(Console.ReadLine(), out int dataNew))
                    {
                        Console.WriteLine("Значение должно быть целым числом.");
                        break;
                    }

                    if (list.SetDataByPosition(dataNew, positionSet))
                    {
                        Console.WriteLine("Значение обновлено!");
                    }
                    break;
                case 5:
                    if (list.isEmpty())
                    {
                        Console.WriteLine("Список пуст");
                        break;
                    }

                    Console.WriteLine("Список не пуст");
                    break;
                case 6:
                    Console.WriteLine($"Размер списка: {list.Size()}");
                    break;
                case 7:
                    Console.WriteLine("Список:");
                    list.Print();
                    break;
                default:
                    Console.WriteLine("Выберите пункт от 1 до 7");
                    break;
            }
        }

        public static void ProceedTask()
        {
            PrintMenu();

            var list = new List();

            int choice = 0;
            string inputString = null;

            do
            {
                inputString = Console.ReadLine();

                if (!int.TryParse(inputString, out choice))
                {
                    Console.WriteLine("Введите число");
                    continue;
                }

                ProceedChoice(list, choice);
            } while (choice != 8);
        }
    }
}
