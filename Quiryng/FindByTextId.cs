using LimsP.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Quiryng
{
    class FindByTextId : Result
    {
        public FindByTextId(Unit _unit, limsprodEntities _limsprodEntities) : base(_unit, _limsprodEntities)
        {
            DateTime findDate =  unit.Stop.AddDays(-1);
            //string findDateStr = findDate.Day.ToString() + "." + findDate.Month.ToString() + "." + findDate.Year.ToString();
            string TextIdFormatted = unit.Text_Id.Replace("%", findDate.ToString("d"));

            while (!FindNext(TextIdFormatted))
            {
                findDate = findDate.AddDays(-1);
                TextIdFormatted = unit.Text_Id.Replace("%", findDate.ToString("d"));
            }

        }

        private bool FindNext(string textId)
        {
            var res = limsprod.SAMPLE.Where(s => s.TEXT_ID == textId)
               .Join(limsprod.RESULT.Where(s => s.NAME == unit.Name), s => s.SAMPLE_NUMBER, r => r.SAMPLE_NUMBER, (s, r)
                 => new { SAMPLE_NUMBER = r.SAMPLE_NUMBER, NAME = r.NAME, FORMATTED_ENTRY = r.FORMATTED_ENTRY, ENTERED_ON = r.ENTERED_ON }).
                 OrderByDescending(o => o.ENTERED_ON).FirstOrDefault();

            if (res != null)
            {
                Sample_Number = res.SAMPLE_NUMBER;
                Entered_on = res.ENTERED_ON;
                Formatted_entryStr = res.FORMATTED_ENTRY;

                GetFormattedEntry();
                ChkFormattedEntry();
                return true;
            }
            else
                return false;
        }
    }
}
