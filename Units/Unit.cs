using LimsP.Quiryng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsP.Units
{

    /// <summary>
    /// абстрактный класс всех юнитов (описание общих св-в классов)
    /// </summary>
    abstract class Unit
    {
        public string X_PROCESS_UNIT { get; set; }
        public int LimsCode { get; set; }
        public string PRODUCT { get; set; }
        public string SAMPLING_POINT { get; set; }
        public string NAME { get; set; }
        public string Error { get; set; }
        public int? SAMPLE_NUMBER { get; set; }
        public System.DateTime? Entered_on { get; set; }
        public double? Formatted_entry { get; set; }
        protected limsprodEntities limsprodEntities { get; set; }
        protected DateTime stop { get; set; }
    }
}
