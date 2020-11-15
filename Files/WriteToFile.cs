using LimsP.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Files
{
    /// <summary>
    /// запись в файл результатов вычислений и ошибок
    /// </summary>
    class WriteToFile
    {
        static DateTime now = DateTime.Now;
        static DateTime yesterDay = DateTime.Now.AddDays(-1);

        static string dayStr = yesterDay.Day < 10 ? "0" + yesterDay.Day.ToString() : yesterDay.Day.ToString();
        static string monthStr = yesterDay.Month < 10 ? "0" + yesterDay.Month.ToString() : yesterDay.Month.ToString();

        //string path = @"D:\temp\Lims_" + year + monthStr + dayStr + "_3.txt";
        //static string pathCopy = @"D:\temp\Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";
        static string pathError = @"Lims_Error" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + "_3.txt";
        static string path = @"\\kms-dfs01\s\MatBalans\Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";

        //static string pathCopy = "Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";
        //static string path = "Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";

        public static void WriteError(List<IUnit> units)
        {
            if (units.Count != 0)
            {
                using (StreamWriter fileStream = new StreamWriter(pathError, true, Encoding.Default))
                {
                    fileStream.WriteLine(DateTime.Now);
                    foreach (Unit unit in units)
                    {
                        fileStream.WriteLine("Lims_" + unit.LimsCode + " error: " + unit.Error);
                    }
                }

            }
        }
        public static void WriteToFileResult(List<IUnit> units)
        {
            units = units.OrderBy(x => x.LimsCode).ToList();
            try
            {
                //FileStream fileCopy = File.Create(pathCopy);
                using (StreamWriter fileStream = new StreamWriter(path, false, Encoding.Default))
                {
                    string codeStr;
                    foreach (Unit unit in units)
                    {
                        if (unit.LimsCode < 10)
                            codeStr = "Lims_0" + unit.LimsCode.ToString();
                        else
                            codeStr = "Lims_" + unit.LimsCode.ToString();

                        string strForCopyFile = codeStr + "," + unit.Formatted_entry + "," + unit.SAMPLE_NUMBER;
                        fileStream.WriteLine(strForCopyFile);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter fileStream = new StreamWriter(pathError, false, Encoding.Default))
                {
                    fileStream.WriteLine(DateTime.Now + " - Ошибка записи в файл " + path);
                    fileStream.WriteLine(ex.Message);
                }
            }
        }

    }
}
