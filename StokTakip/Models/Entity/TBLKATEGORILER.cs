namespace StokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLKATEGORILER")]
    public partial class TBLKATEGORILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKATEGORILER()
        {
            TBLURUNLER = new HashSet<TBLURUNLER>();
        }

        [Key]
        public short KATEGORIID { get; set; }

        [StringLength(50)]
        public string KATEGORIAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNLER> TBLURUNLER { get; set; }
    }
}
