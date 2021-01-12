using LimsP.Files;
using LimsP.Quiryng;
using LimsP.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LimsP
{
    class Program
    {
        public static List<Unit> Units => units;
        public static DateTime DateSearch => dateSearch;
        static List<Unit> units;
        static string pathFile;
        static DateTime dateSearch;
        static void Main(string[] args)
        {
            ParsingArgs(args);
            units = new List<Unit>();

            using (limsprodEntities limsprod = new limsprodEntities())
            {
                //получим образцы - из файла/результаты анализов - зи БД 
                //простые показатели
                units =  new List<Unit>(ReadParametrs.ReadParametersFromFile(limsprod, dateSearch));
                //units.AddRange(units.Where(r => r.Formatted_entry != null).ToList());
                //вычисляемые показатели
                List<Unit> unitsCalc = new List<Unit>(ReadParametrs.ReadFormulsFromFile(limsprod, dateSearch));
                units.AddRange(unitsCalc);
            }
            Console.WriteLine("Запись в файл...");

            //запись всех полученныъ результатов и ошибок
            new WriteToFile(units, pathFile, dateSearch);

            Console.WriteLine("All done!");
            Thread.Sleep(5000);
        }

        static void ParsingArgs(string[] args)
        {
            switch (args.Length)
            {
                case 3:
                    pathFile = args[0];
                    if (!Directory.Exists(args[0]))
                    {
                        Console.WriteLine("Не верно указан путь для отчета! (или нет доступа, если указана сетевая папка)");
                        return;
                    }
                    string strDT = args[1] + " " + args[2];
                    if (!DateTime.TryParse(strDT, out dateSearch))
                    {
                        Console.WriteLine("Не верно указана дата формирования отчета!");
                        return;
                    }
                    break;
                case 1:
                    pathFile = args[0];
                    dateSearch = new DateTime( DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 07, 18, 000); //дата и время по умолчанию
                    if (!Directory.Exists(args[0]))
                    {
                        Console.WriteLine("Не верно указан путь для отчета! (или нет доступа, если указана сетевая папка)");
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("1й параметр путь отчета, 2й параметр дата/время составления отчет (LimsP.exe FilePath DateTime)");
                    Console.WriteLine("1й параметр путь отчета (LimsP.exe FilePath)");
                    Console.WriteLine("пример: LimsP.exe e:\\ 21.12.2020 08:10");
                    return;
                    break;
            }
        }
    }
}
