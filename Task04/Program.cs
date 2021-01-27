﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    //    4. Задача ЕГЭ.
    //*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
    //школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не
    //превосходит 100, каждая из следующих N строк имеет следующий формат:
    //<Фамилия> <Имя> <оценки>,
    //где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
    //более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
    //пятибалльной системе. <Фамилия> и<Имя>, а также <Имя> и<оценки> разделены одним пробелом.
    //Пример входной строки:
    //Иванов Петр 4 5 3
    //Требуется написать как можно более эффективную программу, которая будет выводить на экран
    //фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
    //набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

    class Program
    {
        // Добавление до 3-х человек не сделал, уже позздно было =) Возможно успею сделать(хочется ещё 5-ую решить). Если этот комент не убрал - знач не сделал.
        //P.S. В целом всё работает, но людей может быть меньше 3-х(минимум 1 будет всегда)
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "GradesList.txt";

            var pupils = FillPupilsList(path);
            var indexLowestGrade = LowestGrade(pupils);
            Console.WriteLine("Список учеников с самым низким средним балом:");
            PrintNames(indexLowestGrade, pupils);
            Console.ReadKey();
        }

        static string[,] FillPupilsList(string path)
        {
            string[] pupil = new string[5];
            StreamReader streamReader = new StreamReader(path);
            int lines = int.Parse(streamReader.ReadLine());
            string[,] pupils = new string[lines, 5];
            for (int i = 0; i < lines; i++)
            {
                pupil = streamReader.ReadLine().Split(' ');
                for (int j = 0; j < pupil.Length; j++)
                {
                    pupils[i,j] = pupil[j];
                }
            }
            streamReader.Close();
            return pupils;
        }

        static int[] LowestGrade(string[,] pupils)
        {
            float lowestGrade = 5;
            int lowestGradePupils = 0;
            float[] averageGrade = new float[pupils.GetLength(0)];
            for (int i = 0; i < pupils.GetLength(0); i++)
            {
                averageGrade[i] = (float.Parse(pupils[i, 2]) + float.Parse(pupils[i, 3]) + float.Parse(pupils[i, 4])) / 3;
            }

            for (int i = 0; i < averageGrade.Length; i++)
            {
                if (lowestGrade > averageGrade[i])
                {
                    lowestGrade = averageGrade[i];
                }
                    
            }
            string indexString = "";
            for (int i = 0; i < averageGrade.Length; i++)
            {
                if (lowestGrade == averageGrade[i])
                {
                    indexString += i.ToString() + " ";
                    lowestGradePupils++;
                }   
            }
            //float lowerGrade = lowestGrade + 1f;
            //if(lowestGradePupils < 3)
            //{
            //    for (int i = 0; i < averageGrade.Length; i++)
            //    {
            //        if(lowerGrade < lowestGrade)
            //        {
            //            lowerGrade = averageGrade[i];
            //        }
            //    }
            //}
            //for (int i = 0; i < averageGrade.Length; i++)
            //{
            //    if (lowerGrade == averageGrade[i])
            //    {
            //        indexString += i.ToString() + " ";
            //        lowestGradePupils++;
            //    }
            //}
            char[] sep = { ' '};
            var strIndex = indexString.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            //Array.Sort(strIndex);
            int[] index = new int[strIndex.Length];
            for (int i = 0; i < strIndex.Length; i++)
            {
                index[i] = int.Parse(strIndex[i]);
            }
            return index;
        }

        static void PrintNames(int[] index, string[,] pupils)
        {
            for (int i = 0; i < index.Length; i++)
            {
                var ind = index[i];
                Console.WriteLine(pupils[ind, 0] + " " + pupils[ind, 1] + "(" + pupils[ind, 2] + " " + pupils[ind, 3] + " " + pupils[ind, 4] + ")");
            }
        }
    }
}
