//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LimsP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ANALYSIS_LIMITS
    {
        public int LIMIT_NUMBER { get; set; }
        public string ANALYSIS { get; set; }
        public Nullable<int> VERSION { get; set; }
        public string COMPONENT { get; set; }
        public string SAMPLE_TYPE { get; set; }
        public Nullable<int> ORDER_NUMBER { get; set; }
        public string MIN_LIMIT { get; set; }
        public string MAX_LIMIT { get; set; }
    }
}