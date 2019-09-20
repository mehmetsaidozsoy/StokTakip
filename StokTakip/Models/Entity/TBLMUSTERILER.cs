namespace StokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLMUSTERILER")]
    public partial class TBLMUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERILER()
        {
            TBLTESLIMAT = new HashSet<TBLTESLIMAT>();
        }

        [Key]
        public int MUSTERIID { get; set; }

        [StringLength(50)]
        public string MUSTERIAD { get; set; }

        [StringLength(50)]
        public string MUSTERISOYAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLTESLIMAT> TBLTESLIMAT { get; set; }
    }
}
