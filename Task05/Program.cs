using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    //5. ** Написать игру «Верю.Не верю». В файле хранятся вопрос и ответ, правда это или нет.Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
    //Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
    //Список вопросов ищите во вложении или воспользуйтесь интернетом.
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Questions.txt";
            var questions = FillQuestsList(path);
            var chosenFiveQuestions = ChoiceQuestions(questions);
            Game(chosenFiveQuestions);
            Console.ReadKey();
        }

        static string[,] FillQuestsList(string path)
        {
            string[] question = new string[2];
            StreamReader streamReader = new StreamReader(path);
            int lines = int.Parse(streamReader.ReadLine());
            string[,] questions = new string[lines, 2];
            for (int i = 0; i < lines; i++)
            {
                question = streamReader.ReadLine().Split('|');
                for (int j = 0; j < question.Length; j++)
                {
                    questions[i, j] = question[j];
                }
            }
            streamReader.Close();
            return questions;
        }

        static string[,] ChoiceQuestions(string[,] allQuestions)
        {
            string[,] chosenQuests = new string[5, 2];
            Random random = new Random();
            int[] randNum = new int[5];
            int curIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                randNum[i] = random.Next(0, allQuestions.GetLength(0) - 1);
            }

            for (int i = 0; i < randNum.Length; i++)
            {
                curIndex = randNum[i];
                chosenQuests[i, 0] = allQuestions[curIndex, 0];
                chosenQuests[i, 1] = allQuestions[curIndex, 1];
            }

            return chosenQuests;
        }

        static void Game(string[,] questions)
        {
            int score = 0;
            string answer;
            Console.WriteLine(@"Сейчас вам будет задаваться 5 вопросов на которые ответ может быть 'Да' или 'Нет'.");
            Console.ReadKey();
            for (int i = 0; i < questions.GetLength(0); i++)
            {
                Console.Clear();
                Console.WriteLine(questions[i, 0]);
                answer = Console.ReadLine();
                if(answer.ToLower() == questions[i, 1].ToLower())
                {
                    Console.WriteLine("Вы ответили правильно.");
                    score++;
                }
                else
                {
                    Console.WriteLine("Вы ответили неправильно.");
                }
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine($"Вы ответили правильно на {score} вопрос(ов/а).");
        }
    }
}
