using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char choice;

            do
            {
                Console.WriteLine(" Select the array of numbers you want to create:");
                Console.WriteLine("  1. Integer;");
                Console.WriteLine("  2. Double;");
                Console.WriteLine("  0. Exit;\n");

                Console.Write(" Enter here: ");
                choice = Console.ReadKey().KeyChar;

                Console.Clear();

                switch (choice)
                {
                    case '1':
                        ChooseAction(FillArray<int>());
                        break;

                    case '2':
                        ChooseAction(FillArray<double>());
                        break;

                    case '0':
                        Console.WriteLine(" Shutting down...");
                        return;

                    default:
                        Console.WriteLine($" Your input \"{choice}\" is invalid!\n Please, try again!\n\n");
                        break;
                }
            } while (choice != '0');
        }

        static List<T> FillArray<T>()
        {
            char subChoice;
            List<T> list = new List<T>();

            do
            {
                Console.Write($" Enter {typeof(T).Name}: ");

                if (typeof(T) == typeof(int))
                {
                    if (Int32.TryParse(Console.ReadLine(), out int tempInt))
                    {
                        list.Add((T)Convert.ChangeType(tempInt, typeof(T)));
                    }
                    else
                    {
                        Console.WriteLine($"\n Your input is invalid!");
                    }
                }
                else
                {
                    if (Double.TryParse(Console.ReadLine(), out double tempDouble))
                    {
                        list.Add((T)Convert.ChangeType(tempDouble, typeof(T)));
                    }
                    else
                    {
                        Console.WriteLine($"\n Your input is invalid!");
                    }
                }

                Console.WriteLine(" To stop input press \"E\", to continue press any key!\n");
                subChoice = Console.ReadKey(true).KeyChar;
                Console.Clear();

            } while (char.ToUpper(subChoice) != 'E');

            Console.Write("\n Your array: ");
            foreach(var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n\n");

            return list;
        }

        static void ChooseAction<T>(List<T> array) where T : IComparable<T>
        {
            char subChoice;

            do
            {
                Console.WriteLine("\n Choose an action:\n");
                Console.WriteLine("  1. Finding sum;");
                Console.WriteLine("  2. Finding average;");
                Console.WriteLine("  3. Finding minimum;");
                Console.WriteLine("  4. Finding maximum;");
                Console.WriteLine("  0. Return to main menu;\n");

                Console.Write("\n Enter here: ");
                subChoice = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (subChoice)
                {
                    case '1':
                        Console.WriteLine("\n Result: " + SearchInArray<T>.Sum(array));
                        break;

                    case '2':
                        Console.WriteLine("\n Result: " + SearchInArray<T>.Average(array));
                        break;

                    case '3':
                        Console.WriteLine("\n Result: " + SearchInArray<T>.MinValue(array));
                        break;

                    case '4':
                        Console.WriteLine("\n Result: " + SearchInArray<T>.MaxValue(array));
                        break;

                    case '0':
                        subChoice = '0';
                        break;

                    default:
                        Console.WriteLine($" Your input \"{subChoice}\" is invalid!\n Please, try again!\n\n");
                        break;
                }
            } while (subChoice != '0');
        }
    }
}
