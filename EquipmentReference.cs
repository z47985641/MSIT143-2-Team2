//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSIT143_2_Team2
{
    using System;
    using System.Collections.Generic;
    
    public partial class EquipmentReference
    {
        public int EquipmentID { get; set; }
        public int RoomID { get; set; }
        public int EquipmentReferenceID { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual Room Room { get; set; }
    }
}