using LimsP.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Files
{
    /// чтение параметров юнитов
    /// парсинг и создание классов юнитов (простых и вычисляемых)
    class ReadParametrs
    {
        static string fileUnitsName = "Units.txt";
        static string fileFormulsName = "Formuls.txt";
        public static List<string> Formuls { get; set; }

        //перебор всех юинтов (параметров запроса), для запроса к БД
        public static List<UnitSimple> ReadParametersFromFile(limsprodEntities limsprodEntities, DateTime stop)
        {
            List<UnitSimple> units = new List<UnitSimple>();
            string str;
            try
            {
                    using (StreamReader file = new StreamReader(fileUnitsName))
                    {
                        while ((str = file.ReadLine()) != null)
                        {
                            units.Add(new UnitSimple(stop, limsprodEntities, str));
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            return units;
        }
        public static List<UnitCalc> ReadFormulsFromFile(limsprodEntities limsprodEntities, DateTime stop)
        {
            List<UnitCalc> units = new List<UnitCalc>();
            string formula;
            using (StreamReader line = new StreamReader(fileFormulsName))
            {
                while ((formula = line.ReadLine()) != null)
                {
                    units.Add(new UnitCalc (stop, limsprodEntities, formula));
                }
            }
            return units;
        }
    }
}
