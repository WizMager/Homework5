using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tak01
{
    //    1. Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, 
    //       содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    //       а) без использования регулярных выражений;
    //       б) с использованием регулярных выражений.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пароль длиной 2-10 символов, содержащий только буквы латинского алфавита или цифры(цифра не может быть первой): ");
            var input = Console.ReadLine();
            Console.WriteLine(LoginNotReg(input));
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Введите пароль длиной 2-10 символов, содержащий только буквы латинского алфавита или цифры(цифра не может быть первой): ");
            input = Console.ReadLine();
            Console.WriteLine(LoginReg(input));
            Console.ReadKey();
        }

        #region Task 1.1(a)
        static string LoginNotReg(string inpText)
        {
            if (inpText.Length >= 2 && inpText.Length <= 10)
            {
                string inputText = inpText.ToLower();
                char[] inputString = inputText.ToCharArray();

                for (int i = 0; i < inputString.Length; i++)
                {
                    if (Char.IsDigit(inputString[0]))
                    {
                        return "Во введённом пароле первый символ - число.";
                    }
                    if (!CharCheck(inputString[i]))
                        return "Вы ввели пароль, не подходящий по критериям.";
                }
                return "Вы ввели подходящий пароль.";
            }
            else
            {
                return "Ваш пароль либо меньше 2 сиволов, либо больше 10.";
            }
        }

        static bool CharCheck(char inpChar)
        {
            bool flag = false;
            string template = "qwertyuiopasdfghjklzxcvbnm1234567890";
            foreach (var temp in template)
            {
                if (temp == inpChar)
                {
                    flag = true;
                }
            }
            return flag;
        }

        #endregion

        #region Task 1.2(b)
        static string LoginReg(string inpText)
        {
            var result = "Вы ввели не подходящий по критериям пароль.";
            if (inpText.Length >= 2 && inpText.Length <= 10)
            {
                Regex template = new Regex(@"^\D[A-Za-z0-9]");
                if (template.IsMatch(inpText))
                    result = "Вы ввели подходящий по критериям пароль.";
            }
            return result;
        }
        #endregion
    }
}
