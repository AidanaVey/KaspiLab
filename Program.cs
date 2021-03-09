using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[] nums = new int[11];
            Console.WriteLine("Введите десять чисел");
            for (int i = 1; i < nums.Length; i++)
            {
                {
                    Console.Write("{0}-е число: ", i);
                    nums[i] = Int32.Parse(Console.ReadLine());
                }
            }
                for (int i = 1; i < nums.Length; i++)
                {
                    if (IsPrime(nums[i]))
                    {
                        string s1 = " - Простое число";
                        Console.WriteLine(nums[i] + s1);
                    }
                    else
                    {
                        string s2 = " - Не простое число";
                        Console.WriteLine(nums[i] + s2);
                    }

                    if (nums[i] % 2 == 0)
                    {
                        Console.WriteLine("Четное число");
                    }
                    else
                    {
                        Console.WriteLine("Нечетное число");
                    }
                }
                int sum = nums.Sum();
                Console.WriteLine("Сумма элементов: " + sum);
            }
        }
    }
