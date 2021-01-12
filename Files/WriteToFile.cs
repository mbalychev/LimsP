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


        //string path = @"D:\temp\Lims_" + year + monthStr + dayStr + "_3.txt";
        //static string pathCopy = @"D:\temp\Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";
        //static string pathError = @"Lims_Error" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + "_3.txt";
        //static string path = @"\\kms-dfs01\s\MatBalans\Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";
        //static string fileName = @"Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";

        //static string pathCopy = "Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";
        //static string path = "Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";

        List<Unit> unitsToWrite;
        List<Unit> unitsWithError;
        string pathFile;
        DateTime dateSearch;
        string filePath;
        string errorFilePath;

        public WriteToFile(List<Unit> _units, string _pathFile, DateTime _dateSearch)
        {
            unitsToWrite = _units.OrderBy(x => x.LimsCode).ToList();
            unitsWithError = _units.Where(r => r.Error != null).OrderBy(x => x.LimsCode).ToList();
            pathFile = _pathFile;
            dateSearch = _dateSearch;

            FileName();
            WriteToFileResult();
            WriteError();
        }

        public void WriteError()
        {
            if (unitsWithError.Count != 0)
            {
                using (StreamWriter fileStream = new StreamWriter(errorFilePath, true, Encoding.Default))
                {
                    fileStream.WriteLine(DateTime.Now);
                    foreach (Unit unit in unitsWithError)
                    {
                        fileStream.WriteLine("Lims_" + unit.LimsCode + " error: " + unit.Error);
                    }
                }

            }
        }
        public void WriteToFileResult()
        {
            try
            {
                //FileStream fileCopy = File.Create(pathCopy);
                using (StreamWriter fileStream = new StreamWriter(filePath, false, Encoding.Default))
                {
                    foreach (Unit unit in unitsToWrite)
                    {
                        

                        string strForCopyFile = GetLimsCodeStr(unit.LimsCode) + "," + unit.Formatted_entry + "," + unit.Result?.Sample_Number + " " + unit.Name + " = " +unit.Result?.Formatted_entryStr;
                        fileStream.WriteLine(strForCopyFile);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter fileStream = new StreamWriter(errorFilePath, false, Encoding.Default))
                {
                    fileStream.WriteLine(DateTime.Now + " - Ошибка записи в файл " + filePath);
                    fileStream.WriteLine(ex.Message);
                }
            }
        }

        //по требованию в строке код лимс, менее 10, должен быть формата Lims_0
        string GetLimsCodeStr(int limsCode)
        {
            string codeStr;
            if (limsCode < 10)
                codeStr = "Lims_0" + limsCode.ToString();
            else
                codeStr = "Lims_" + limsCode.ToString();

            return codeStr;
        }


        void FileName()
        {
            DateTime now = dateSearch;
            DateTime yesterDay = dateSearch.AddDays(-1);

            string dayStr = yesterDay.Day < 10 ? "0" + yesterDay.Day.ToString() : yesterDay.Day.ToString();
            string monthStr = yesterDay.Month < 10 ? "0" + yesterDay.Month.ToString() : yesterDay.Month.ToString();
            string fileName = @"Lims_" + yesterDay.Year + monthStr + dayStr + "_3.txt";
            string fileErrorName = @"Lims_Error" + dateSearch.Year + monthStr + dayStr + "_3.txt";

            fileName = pathFile is null ? fileName : pathFile + "\\" + fileName;

            filePath = fileName;
            errorFilePath = fileErrorName;
        }

    }
}
