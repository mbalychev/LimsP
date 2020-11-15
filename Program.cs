using LimsP.Files;
using LimsP.Quiryng;
using LimsP.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;


namespace LimsP
{
    class Program
    {
        public static List<UnitSimple> UnitsSimple => unitsSimple;
        static List<UnitSimple> unitsSimple;

        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            DateTime stop = new DateTime(now.Year, now.Month, now.Day, 07, 18, 000);    //последнее время/дата получения результатов анализов
            List<IUnit> units = new List<IUnit>();

            using (limsprodEntities limsprod = new limsprodEntities())
            {
                //получим образцы - из файла/результаты анализов - зи БД 
                //простые показатели
                unitsSimple =  new List<UnitSimple>(ReadParametrs.ReadParametersFromFile(limsprod, stop));
                units.AddRange(unitsSimple.Where(r => r.Formatted_entry != null).ToList());
                //вычисляемые показатели
                List<UnitCalc> unitsCalc = new List<UnitCalc>(ReadParametrs.ReadFormulsFromFile(limsprod, stop));
                units.AddRange(unitsCalc);
            }
            //запись всех полученныъ результатов
            WriteToFile.WriteToFileResult(units.Where(r => r.Error == null && r.LimsCode < 1000).ToList());
            //запись ошибок в результате парсинга/получение результатов
            WriteToFile.WriteError(units.Where(r => r.Error != null).ToList());
        }
    }
}
