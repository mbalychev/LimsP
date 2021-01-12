using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{
    class UnitPrm6 : Unit, IUnit
    {
        public UnitPrm6(limsprodEntities _limsprodEntities, string parsingStr) : base(_limsprodEntities, parsingStr)
        {
            PasrsingUnitStr();
            GetResult();

        }

        public void PasrsingUnitStr()
        {
            string[] parameters;
            parameters = ParsingStr.Split(';');
            X_Process_Unit = parameters[0];
            LimsCode = ParsingLimsCode(parameters[3]);
            Product = parameters[1];
            Sampling_Point = parameters[2];
            Name = parameters[4];
            Sampled_Date = SampledDate(parameters[5]);
        }

        public void GetResult()
        {
            Result result = new FindByTime(this, limsprodEntities);
            if (result.Formatted_entryStr == null && ContinueSearch == true)
                result = new FindLast(this, limsprodEntities);
            this.Result = result;
        }

        DateTime? SampledDate(string timeStr)
        {
            if (timeStr == null)
                return null;
            string[] time = timeStr.Split(':');
            try
            {
                double[] timeDbl = new double[] { double.Parse(time[0]), double.Parse(time[1]) };
                DateTime sampledDate = Stop.Date;
                sampledDate = sampledDate.AddHours(timeDbl[0]);
                sampledDate = sampledDate.AddMinutes(timeDbl[1]);
                sampledDate = sampledDate.AddDays(-1); //результаты за прошлые сутки
                return sampledDate;
            }
            catch (Exception ex)
            {
                Error += "ошибка конверитирования времени отбора образца";
            }
            return null;
        }
    }
}
