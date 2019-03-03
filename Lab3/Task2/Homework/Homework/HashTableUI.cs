using System;

namespace Homework
{
    class HashTableUI
    {
        private static void PrintMenu()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Интерфейс работы с хеш-таблицей (тип хранимых данных - строка)");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("1 - Добавить элемент");
            Console.WriteLine("2 - Удалить элемент");
            Console.WriteLine("3 - Проверить элемент на наличие");
            Console.WriteLine("4 - Вывести количество элементов в таблице");
            Console.WriteLine("--------------------------------------------------------------");
        }

        private static void ProceedChoice(HashTable table, int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите добавляемое значение:");

                    table.Add(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Введите удаляемое значение:");

                    table.Remove(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Введите проверяемое значение:");

                    var inputString = Console.ReadLine();

                    if (table.IsContained(inputString))
                    {
                        Console.WriteLine($"Строка {inputString} содержится в наборе");
                        break;
                    }

                    Console.WriteLine($"Строка {inputString} не содержится в наборе");
                    break;
                case 4:
                    Console.WriteLine($"Элементов в таблице : {table.Count}");
                    break;
                default:
                    Console.WriteLine("Выберите пункт от 1 до 4");
                    break;
            }
        }

        public static void ProceedTask()
        {
            PrintMenu();

            var table = new HashTable();

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

                ProceedChoice(table, choice);
            } while (choice != 8);

            table.Clear();
        }
    }
}
