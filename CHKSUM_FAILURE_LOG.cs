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
    
    public partial class CHKSUM_FAILURE_LOG
    {
        public int LOG_NUMBER { get; set; }
        public string USER_NAME { get; set; }
        public string WORKSTATION { get; set; }
        public Nullable<System.DateTime> FAILURE_TIME { get; set; }
        public string TABLE_NAME { get; set; }
        public string TABLE_KEYS { get; set; }
        public string PROCESS_NAME { get; set; }
    }
}
