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
    
    public partial class X_INVENT_ANALYS_PULL
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<int> TEST_NUMBER { get; set; }
        public string ANALYSIS { get; set; }
        public string INVENTORY_TYPE { get; set; }
        public Nullable<int> INVENTORY_ITEM { get; set; }
        public Nullable<int> INVENTORY_ENTRY { get; set; }
        public string QUALITY { get; set; }
        public string T_TEST_METHOD { get; set; }
        public string T_TEST_METHOD_INV { get; set; }
        public Nullable<float> PLANNED_QUANTITY { get; set; }
        public Nullable<float> ACTUAL_QUANTITY { get; set; }
        public string LOCATION { get; set; }
        public string UNITS { get; set; }
        public string APPROVED { get; set; }
    }
}