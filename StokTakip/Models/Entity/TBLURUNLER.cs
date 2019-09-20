namespace StokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLURUNLER")]
    public partial class TBLURUNLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLURUNLER()
        {
            TBLTESLIMAT = new HashSet<TBLTESLIMAT>();
        }

        [Key]
        public int URUNID { get; set; }

        [StringLength(50)]
        public string URUNAD { get; set; }

        [StringLength(50)]
        public string MARKA { get; set; }

        public short? URUNKATEGORI { get; set; }

        public decimal? FİYAT { get; set; }

        public int? STOK { get; set; }

        public virtual TBLKATEGORILER TBLKATEGORILER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLTESLIMAT> TBLTESLIMAT { get; set; }
    }
}
