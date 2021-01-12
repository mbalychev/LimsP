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
        public static List<Unit> ReadParametersFromFile(limsprodEntities limsprodEntities, DateTime stop)
        {
            List<Unit> units = new List<Unit>();
            string strFromFile;
            fileUnitsName = Directory.GetCurrentDirectory() + "\\" + fileUnitsName;
            Console.WriteLine("Чтение параметров " + fileUnitsName);
            try
            {
                using (StreamReader file = new StreamReader(fileUnitsName))
                {
                    while ((strFromFile = file.ReadLine()) != null)
                    {
                        string[] str = strFromFile.Split(';');
                        switch (str.Length)
                        {
                            case 5:
                                units.Add(new UnitPrm5(limsprodEntities, strFromFile));
                                break;
                            case 6:
                                units.Add(new UnitPrm6(limsprodEntities, strFromFile));
                                break;
                            case 3:
                                units.Add(new UnitPrm3(limsprodEntities, strFromFile));
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            return units;
        }
        public static List<Unit> ReadFormulsFromFile(limsprodEntities limsprodEntities, DateTime stop)
        {
            List<Unit> units = new List<Unit>();
            string formula;
            fileFormulsName = Directory.GetCurrentDirectory() + "\\" + fileFormulsName;
            try
            {
                using (StreamReader line = new StreamReader(fileFormulsName))
                {
                    while ((formula = line.ReadLine()) != null)
                    {
                        units.Add(new UnitCalc(limsprodEntities, formula));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            return units;
        }
    }
}
