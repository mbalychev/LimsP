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
    
    public partial class BATCH_AUDIT_LOG
    {
        public int COUNTER { get; set; }
        public string BATCH_NAME { get; set; }
        public string TABLE_NAME { get; set; }
        public string TABLE_KEY { get; set; }
        public string AUDIT_TYPE { get; set; }
        public string ACTION { get; set; }
        public string REASON { get; set; }
        public string TRANS_STRING { get; set; }
        public Nullable<int> TRANS_ORDER { get; set; }
        public string USER_NAME { get; set; }
        public Nullable<System.DateTime> AUDIT_TIMESTAMP { get; set; }
        public string RECORD_SIGNED { get; set; }
    }
}
