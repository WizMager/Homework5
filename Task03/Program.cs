using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task03
{
    //    3. * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.Регистр можно не учитывать:
    //         а) с использованием методов C#;
    //         б) * разработав собственный алгоритм.
    //         Например: badc являются перестановкой abcd.
    class Program
    {
        static void Main(string[] args)
        {
            string str1, str2;
            Console.WriteLine("Введите по очереди 2 строки для проверки их схожести: ");
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
            IsChanged(str1, str2);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Введите по очереди 2 строки для проверки их схожести: ");
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
            MyIsChanged(str1, str2);
            Console.ReadKey();

        }

        #region Task 3.1(а)
        static void IsChanged(string str1, string str2)
        {
            if (str1.Length == str2.Length) {
                var string1 = Sort(str1);
                var string2 = Sort(str2);

                if (string1 == string2)
                {
                    Console.WriteLine("Строки схожие.");
                }
                else
                {
                    Console.WriteLine("Строки не схожие.");
                }

            }
            else
            {
                Console.WriteLine("Строки не схожие.");
            }


        }

        static string Sort(string str)
        {
            string result = "";
            var strChar = str.ToCharArray();
            Array.Sort(strChar);
            for (int i = 0; i < strChar.Length; i++)
            {
                result += strChar[i];
            }
            return result;
        }
        #endregion

        #region Task 3.2(б)
        static void MyIsChanged(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                bool result = true;
                bool[] match;
                char[] str1Char = str1.ToCharArray();
                char[] str2Char = str2.ToCharArray();

                match = CheckAllMatches(str1Char, str2Char);

                for (int i = 0; i < match.Length; i++)
                {
                    if (!match[i])
                    {
                        result = false;
                    }
                }

                if (result)
                {
                    Console.WriteLine("Строки схожие.");
                }
                else
                {
                    Console.WriteLine("Строки не схожие.");
                }
            }
            else
            {
                Console.WriteLine("Строки не схожие.");
            }
        }

        static bool[] CheckAllMatches(char[] str1, char[] str2)
        {
            bool[,] tempMatch = new bool[str1.Length, str2.Length];
            bool[] match = new bool[str1.Length];

            for (int i = 0; i < match.Length; i++)
            {
                match[i] = false;
            }

            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    for (int j = 0; j < str2.Length; j++)
                    {
                        if (str1[i] == str2[j])
                        {
                            tempMatch[i, j] = true;
                        }
                        else
                        {
                            tempMatch[i, j] = false;
                        }
                    }
                }
            }

            for (int i = 0; i < tempMatch.GetLength(0); i++)
            {
                for (int j = 0; j < tempMatch.GetLength(1); j++)
                {
                    if (tempMatch[i, j])
                        match[i] = true;
                }
            }
            return match;
        }
        #endregion
    }
}
