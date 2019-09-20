namespace StokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLTESLIMAT")]
    public partial class TBLTESLIMAT
    {
        [Key]
        public int TESLIMID { get; set; }

        public int? URUN { get; set; }

        public int? MUSTERI { get; set; }

        public int? ADET { get; set; }

        public virtual TBLMUSTERILER TBLMUSTERILER { get; set; }

        public virtual TBLURUNLER TBLURUNLER { get; set; }
    }
}
