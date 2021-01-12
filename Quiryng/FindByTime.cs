using LimsP.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Quiryng
{
    class FindByTime : Result
    {
        public FindByTime(Unit _unit, limsprodEntities _limsprodEntities) : base(_unit, _limsprodEntities)
        {
            DateTime dt = Convert.ToDateTime(unit.Sampled_Date);
            string st = dt.ToString("HH:mm");
            string ss = unit.X_Process_Unit + "--" + dt.ToString("HH:mm") + "--" + unit.Product + "--" + unit.Sampling_Point + "--" + dt.ToString("dd.MM.yyyy");
            var res = limsprod.SAMPLE.Where(s => s.TEXT_ID == ss)
                .Join(limsprod.RESULT.Where(s => s.NAME == unit.Name), s => s.SAMPLE_NUMBER, r => r.SAMPLE_NUMBER, (s, r)
                  => new { SAMPLE_NUMBER = r.SAMPLE_NUMBER, NAME = r.NAME, FORMATTED_ENTRY = r.FORMATTED_ENTRY, ENTERED_ON = r.ENTERED_ON }).
                  OrderByDescending(o => o.ENTERED_ON).FirstOrDefault();
            
            if (res != null)
            {
                Sample_Number = res.SAMPLE_NUMBER;
                Entered_on = res.ENTERED_ON;
                Formatted_entryStr = res.FORMATTED_ENTRY;

                GetFormattedEntry();
            }
            ChkFormattedEntry();
        }
    }
}
