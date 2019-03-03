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

        private static void ProceedChoice(IHashTable table, int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите добавляемое значение:");

                    table.Add(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Введите удаляемое значение:");
                    try
                    {
                        table.Remove(Console.ReadLine());
                    }
                    catch (ArgumentException argError)
                    {
                        Console.WriteLine(argError.Message);
                    }
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

        private static IHashTable GetHashFunctionImplementation()
        {
            Console.WriteLine("Выберите используемую хэш-функцию:");
            Console.WriteLine("1 - Функция Адлера");
            Console.WriteLine("2 - Функция Дженкинса");
            Console.WriteLine("3 - Функция Murmur2");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Выбранная реализация хэш-функции: функция Адлера");
                            return new HashTable(new AdlerHash());
                        case 2:
                            Console.WriteLine("Выбранная реализация хэш-функции: функция Murmur2");
                            return new HashTable(new JenkinsHash());
                        case 3:
                            Console.WriteLine("Выбранная реализация хэш-функции: функция Дженкинса");
                            return new HashTable(new Murmur2Hash());
                        default:
                            Console.WriteLine("Выберете один из двух типов стека.");
                            continue;
                    }
                }
                Console.WriteLine("Выберете один из двух типов стека.");
            }
        }

        public static void ProceedTask()
        {
            Console.WriteLine("Данная программа представляет собой реализацию хэш-таблицы с возможностью выбора хэш-функции");

            var table = GetHashFunctionImplementation();

            PrintMenu();

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
