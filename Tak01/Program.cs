using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        }

        static string LoginNotReg(string inpText)
        {
            var flag = false;
            string inputText = inpText.ToLower();
            string result = "";
            char[] inputString = inputText.ToCharArray();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (Char.IsDigit(inputString[0]))
                {
                    Console.WriteLine("Во введённом пароле первый символ - число.");
                    flag = false;
                }
                if (CharCheck(inputString[i]))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }    
            }

            if (flag)
            {
                result = "Вы ввели подходящий пароль.";
            }
            else
            {
                result = "Вы ввели пароль, не подходящий по критериям.";
            }

            return result;
        }

        static bool CharCheck(char inpChar)
        {
            string template = "qwertyuiopasdfghjklzxcvbnm1234567890";
            foreach (var temp in template)
            {
                if (temp != inpChar)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
