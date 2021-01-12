using LimsP.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Quiryng
{
    class FindLast : Result
    {
        public FindLast(Unit _unit, limsprodEntities _limsprodEntities) : base(_unit, _limsprodEntities)
        {
            var res = limsprod.SAMPLE.Where(s => s.X_PROCESS_UNIT == unit.X_Process_Unit && s.Product == unit.Product && s.SAMPLING_POINT == unit.Sampling_Point)
                .Join(limsprod.RESULT.Where(s => s.ENTERED_ON < unit.Stop && s.NAME == unit.Name && s.FORMATTED_ENTRY != null), s => s.SAMPLE_NUMBER, r => r.SAMPLE_NUMBER, (s, r)
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
