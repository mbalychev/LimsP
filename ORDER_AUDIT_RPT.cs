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
    
    public partial class ORDER_AUDIT_RPT
    {
        public int COUNTER { get; set; }
        public string ORDER_NUM { get; set; }
        public string TABLE_NAME { get; set; }
        public string TABLE_KEY { get; set; }
        public string ACTION { get; set; }
        public string AUDIT_TYPE { get; set; }
        public string REASON { get; set; }
        public string USER_NAME { get; set; }
        public Nullable<System.DateTime> AUDIT_TIMESTAMP { get; set; }
        public string REPORTED_BY { get; set; }
        public Nullable<System.DateTime> REPORTED_ON { get; set; }
        public string PARTIAL_FLAG { get; set; }
        public string TABLE_FIELD { get; set; }
        public string FIELD_NAME { get; set; }
        public Nullable<int> SAMPLE_NUMBER { get; set; }
        public Nullable<int> RESULT_NUMBER { get; set; }
    }
}
