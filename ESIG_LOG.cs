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
    
    public partial class ESIG_LOG
    {
        public int COUNTER { get; set; }
        public string TABLE_NAME { get; set; }
        public string RECORD_NAME { get; set; }
        public Nullable<int> RECORD_ID { get; set; }
        public Nullable<int> RECORD_VERSION { get; set; }
        public string SIGNED_BY { get; set; }
        public string FULL_SIGNED_BY { get; set; }
        public string USER_ROLE { get; set; }
        public Nullable<System.DateTime> SIGNED_ON { get; set; }
        public string SIGNING_REASON { get; set; }
        public Nullable<System.DateTime> SIGNED_ON_GMT { get; set; }
        public string AUDIT_REASON { get; set; }
        public string PARENT_TABLE_NAME { get; set; }
        public string PARENT_RECORD_NAME { get; set; }
        public Nullable<int> PARENT_RECORD_ID { get; set; }
        public string LWCHECKSUM { get; set; }
    }
}
