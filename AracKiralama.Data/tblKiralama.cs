//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AracKiralama.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblKiralama
    {
        public int kiralamaID { get; set; }
        public Nullable<int> aracID { get; set; }
        public Nullable<int> müsteriID { get; set; }
        public Nullable<System.DateTime> alistarihi { get; set; }
        public Nullable<System.DateTime> verisTarihi { get; set; }
        public Nullable<int> verilisKmsi { get; set; }
        public Nullable<int> toplamUcret { get; set; }
        public Nullable<int> aracGeldiMi { get; set; }
        public Nullable<int> sirketId { get; set; }
    
        public virtual tblArac tblArac { get; set; }
        public virtual tblMüsteri tblMüsteri { get; set; }
        public virtual tblSirket tblSirket { get; set; }
    }
}
