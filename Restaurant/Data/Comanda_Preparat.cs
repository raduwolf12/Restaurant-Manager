//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comanda_Preparat
    {
        public int id_comanda { get; set; }
        public int id_preparat { get; set; }
        public Nullable<int> cantitate { get; set; }
        public Nullable<double> pret_CP { get; set; }
    
        public virtual Comenzi Comenzi { get; set; }
        public virtual Preparate Preparate { get; set; }
    }
}
