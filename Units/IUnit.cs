using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{
    //описание общих св-в юнитов (вычисляемы и простых)
    interface IUnit
    {
         string X_PROCESS_UNIT { get; set; }
         int LimsCode { get; set; }
         string PRODUCT { get; set; }
         string SAMPLING_POINT { get; set; }
         string NAME { get; set; }
         string Error { get; set; }
         int? SAMPLE_NUMBER { get; set; }
         System.DateTime? Entered_on { get; set; }
         double? Formatted_entry { get; set; }
    }
}
