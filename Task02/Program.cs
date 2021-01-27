using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task02
{
    //    2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    //    а) Вывести только те слова сообщения, которые содержат не более n букв.
    //    б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    //    в) Найти самое длинное слово сообщения.
    //    г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    //   Продемонстрируйте работу программы на текстовом файле с вашей программой.
    class Program
    {
        static void Main(string[] args)
        {
            // Первую и вторую задачу сделал 2мя способа: в первой я закинул все слова в массив и уже отдельно с ними работал.
            // Во второй задаче просто удалил неподходящие слова из текста. Не слишком понятно какой вариант нужно было делать просто =)

            string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Text.txt");
            Message message = new Message(text);

            Console.WriteLine(text);
            Console.WriteLine();

            Console.WriteLine(@"\/Вывод слов, которые содержать не более n(4) букв...\/");
            Console.WriteLine(message.LimitedWords(4));
            Console.WriteLine();

            Console.WriteLine(@"\/Удаление всех слов, которые заканчиваются на заданный символ(а)...\/");
            Console.WriteLine(message.RemoveLastSymbWords('а'));
            Console.WriteLine();

            Console.WriteLine(@"\/Вывод самого длинного слова...\/");
            Console.WriteLine(message.LongestWord());
            Console.WriteLine();

            Console.WriteLine(@"\/Вывод самых длинных слов с помощью StringBulder'а...\/");
            StringBuilder stringBuilder = message.LongestWords();
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();
        }
    }

    public class Message
    {
        string Text;
        public Message(string text)
        {
            Text = text;
        }

        #region Task2.1(а)
        public string LimitedWords(int letters)
        {
            StringBuilder res = new StringBuilder();
            string[] result = SeparateInputText();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Length <= letters)
                    res.Append(result[i] + "|");
            }
            return res.ToString();
        }
        #endregion

        #region Task2.2(б)
        public string RemoveLastSymbWords(char ch)
        {
            string result = Text;
            string[] delWords = SeparateInputText();
            for (int i = 0; i < delWords.Length; i++)
            {
                if (delWords[i].LastIndexOf(ch) == delWords[i].Length - 1)
                    result = result.Replace(delWords[i], "");
            }
            return result;
        }
        #endregion

        #region Task 2.3(в)
        public string LongestWord()
        {
            int longestWordsCounter = 0;
            int longestWordIndex = 0;
            int wordLength = 0;
            string[] tempText = SeparateInputText();
            for (int i = 0; i < tempText.Length; i++)
            {
                if(tempText[i].Length > wordLength)
                {
                    longestWordIndex = i;
                    wordLength = tempText[i].Length;
                }
            }
            for (int i = 0; i < tempText.Length; i++)
            {
                if (tempText[i].Length == wordLength)
                    longestWordsCounter++;
            }

            return $"Первое самое длинное слово: \"{tempText[longestWordIndex]}\", всего самых длинных слов: {longestWordsCounter}.";
        }
        #endregion

        #region Task 2.4(г)
        public StringBuilder LongestWords()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] sepText = SeparateInputText();
            int longestWordLenght = 0;

            for (int i = 0; i < sepText.Length; i++)
            {
                if (sepText[i].Length > longestWordLenght)
                    longestWordLenght = sepText[i].Length;
            }
            for (int i = 0; i < sepText.Length; i++)
            {
                if (sepText[i].Length == longestWordLenght)
                    stringBuilder.Append(sepText[i] + "|");
            }
            
            return stringBuilder;
        }
        #endregion

        /// <summary>
        /// Separate input string text to string array with separators: ' ', ',', '.', '!', '?', '-', ':', ';' .
        /// </summary>
        /// <returns>string[]</returns>
        string[] SeparateInputText()
        {
            char[] separator = { ' ', ',', '.', '!', '?', '-', ':', ';' };
            string[] result = Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }
    }
}
