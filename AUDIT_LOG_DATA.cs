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
    
    public partial class AUDIT_LOG_DATA
    {
        public int AUDIT_LOG_DATA_ID { get; set; }
        public int AUDIT_LOG_TRANSACTION_ID { get; set; }
        public string PRIMARY_KEY_DATA { get; set; }
        public string COL_NAME { get; set; }
        public string OLD_VALUE_LONG { get; set; }
        public string NEW_VALUE_LONG { get; set; }
        public byte[] NEW_VALUE_BLOB { get; set; }
        public string NEW_VALUE { get; set; }
        public string OLD_VALUE { get; set; }
        public string PRIMARY_KEY { get; set; }
    }
}