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
        public Nullable<int> Sample_Number { get; set; }
        public Nullable<System.DateTime> Entered_on { get; set; }
        public double Formatted_entry { get; set; }
        public string Formatted_entryStr { get; set; }
        public string Error { get; set; }
        protected Unit unit;
        //protected DateTime stop;
        protected limsprodEntities limsprod;

        public Result(Unit _unit, limsprodEntities _limsprodEntities)
        {
            unit = _unit;
            limsprod = _limsprodEntities;

        }

        public bool GetFormattedEntry()
        {
            try
            {
                Formatted_entry = Math.Round(Convert.ToDouble(Formatted_entryStr), 3);
                return true;
            }
            catch (Exception ex)
            {
                Error = Formatted_entry + "ошибка при получении результата, преобразования в число Formatted_entry - " + Formatted_entryStr;
                return false;
            }
        }

        public bool ChkFormattedEntry()
        {
            if (Formatted_entryStr != null)
            {
                Console.WriteLine("Lims_" + unit.LimsCode + ", " + Sample_Number + " = " + Formatted_entry.ToString() + "  " + this.Error);
                return true;
            }
            else
            {
                //если в файле данных есть знак @ значит, и нет результата за конкретное время значит получить результат из последнего образца (более раннего)
                if (unit.ContinueSearch == true)
                    return false;
                else
                {
                    Formatted_entry = 0.0001; //число для слею обработке в Галатике как знак прочерка
                    Console.WriteLine("Lims_" + unit.LimsCode + ", " + Sample_Number + " = " + Formatted_entry.ToString() + "  " + this.Error);

                    return true;
                }

            }
        }

    }

}
