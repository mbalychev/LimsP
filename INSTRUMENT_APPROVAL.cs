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
    
    public partial class INSTRUMENT_APPROVAL
    {
        public string USER_NAME { get; set; }
        public string INSTRUMENT { get; set; }
        public Nullable<System.DateTime> APPROVAL_DATE { get; set; }
        public Nullable<int> APPROVAL_INTV { get; set; }
        public string APPROVER { get; set; }
        public Nullable<System.DateTime> EXPIRATION_DATE { get; set; }
        public string EXPIRED { get; set; }
    }
}
