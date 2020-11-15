using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{

    /// <summary>
    /// описание простого юнита (результ анализов по данным методики МВИ и ее одного параметра)
    /// МВИ и пар-ры парсятся из файла  Units.txt
    /// </summary>
    class UnitSimple : Unit, IUnit
    {
        /// <param name="_stop">дата послед.результата</param>
        /// <param name="_limsprodEntities">ссылка на поделючение к БД</param>
        /// <param name="unitString">строка для парсинга с описанием юнита</param>
        public UnitSimple(DateTime _stop, limsprodEntities _limsprodEntities, string unitString)
        {
            stop = _stop;
            limsprodEntities = _limsprodEntities;
            PasrsingUnitStr(unitString);
            GetFormatted_entry();
        }
        void PasrsingUnitStr(string unitString)
        {
            string[] parameters;
            int code = 0;

            parameters = unitString.Split(';');
            try
            {
                code = Convert.ToInt32(parameters[3]);
            }
            catch (Exception)
            {
                Error += "ошибка инициализации (код лимс - не число) " + parameters[3];
            }

            if (parameters.Count() == 6)
            {
                X_PROCESS_UNIT = parameters[0];
                LimsCode = code;
                PRODUCT = parameters[1];
                SAMPLING_POINT = parameters[2];
                NAME = parameters[4];
            }
            else
            {
                Error += "ошибка инициализации (не верное количество параметров)" + unitString;
            }
        }
        void GetFormatted_entry()
        {
            Result result = new Result(this, stop, limsprodEntities);
            this.SAMPLE_NUMBER = result.Sample_number;
            this.Entered_on = result.Entered_on;
            this.Formatted_entry = result.Formatted_entry;
            this.Error = result.Error;
        }

    }
}
