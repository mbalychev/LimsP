using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimsP.Units;

namespace LimsP.Quiryng
{
    /// <summary>
    /// получение результата из БД для юнита
    /// </summary>
    class Result
    {
        public Nullable<int> Sample_number { get; set; }
        public Nullable<System.DateTime> Entered_on { get; set; }
        public double Formatted_entry { get; set; }
        public string Formatted_entryNoFormat { get; set; }
        public string Error { get; set; }

        /// <param name="unit">юнит</param>
        /// <param name="stop">дата последнего результата</param>
        /// <param name="limsprod">ссылка на подключение к БД</param>
        public Result(Unit unit, DateTime stop, limsprodEntities limsprod)
        {
            try
            {
                var res = limsprod.SAMPLE.Where(s => s.X_PROCESS_UNIT == unit.X_PROCESS_UNIT && s.Product == unit.PRODUCT && s.SAMPLING_POINT == unit.SAMPLING_POINT)
                    .Join(limsprod.RESULT.Where(s => s.ENTERED_ON < stop && s.NAME == unit.NAME), s => s.SAMPLE_NUMBER, r => r.SAMPLE_NUMBER, (s, r)
                      => new { SAMPLE_NUMBER = r.SAMPLE_NUMBER, NAME = r.NAME, FORMATTED_ENTRY = r.FORMATTED_ENTRY, ENTERED_ON = r.ENTERED_ON }).
                      OrderByDescending(o => o.ENTERED_ON).FirstOrDefault();

                if (res != null)
                {
                    Sample_number = res.SAMPLE_NUMBER;
                    Entered_on = res.ENTERED_ON;
                    Formatted_entryNoFormat = res.FORMATTED_ENTRY;

                    try
                    {
                        Formatted_entry = Convert.ToDouble(res.FORMATTED_ENTRY);
                    }
                    catch (Exception ex)
                    {
                        Error = Formatted_entry + "ошибка при получении результата, преобразования в число Formatted_entry - " + res.FORMATTED_ENTRY;
                    }
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
    }
}
