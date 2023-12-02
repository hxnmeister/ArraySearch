using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySearch
{
    internal static class SearchInArray<T> where T : IComparable<T>
    {
        private static Task task;

        public static T MinValue(List<T> values)
        {
            if (values.Count == 0)
            {
                Console.WriteLine($" The given array of {(typeof(T) == typeof(Int32) ? "Integer" : "Double")} is empty!");
                return default;
            }

            T min = values[0];

            task = new Task(() =>
            {
                for (int i = 1; i < values.Count; i++)
                {
                    if (values[i].CompareTo(min) < 0)
                    {
                        min = values[i];
                    }
                }
            });

            task.Start();
            task.Wait();

            return min;
        }

        public static T MaxValue(List<T> values)
        {
            if (values.Count == 0)
            {
                Console.WriteLine($" The given array of {(typeof(T) == typeof(Int32) ? "Integer" : "Double")} is empty!");
                return default;
            }

            T max = values[0];

            task = new Task(() =>
            {
                for (int i = 1; i < values.Count; i++)
                {
                    if (values[i].CompareTo(max) > 0)
                    {
                        max = values[i];
                    }
                }
            });

            task.Start();
            task.Wait();

            return max;
        }

        public static T Average(List<T> values)
        {
            if (values.Count == 0)
            {
                Console.WriteLine($" The given array of {(typeof(T) == typeof(Int32) ? "Integer" : "Double")} is empty!");
                return default;
            }

            dynamic average = 0;

            task = new Task(() =>
            {
                for (int i = 0; i < values.Count; i++)
                {
                    average += values[i];
                }
            });

            task.Start();
            task.Wait();

            return average / values.Count;
        }

        public static T Sum(List<T> values)
        {
            if (values.Count == 0)
            {
                Console.WriteLine($" The given array of {(typeof(T) == typeof(Int32) ? "Integer" : "Double")} is empty!");
                return default;
            }

            dynamic sum = 0;

            task = new Task(() =>
            {
                for (int i = 0; i < values.Count; i++)
                {
                    sum += values[i];
                }
            });

            task.Start();
            task.Wait();

            return sum;
        }

    }
}
