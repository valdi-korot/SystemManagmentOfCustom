namespace SystemOfManagmentCustom.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Persons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persons()
        {
            BlackList = new HashSet<BlackList>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string LName { get; set; }

        [StringLength(100)]
        public string FName { get; set; }

        [StringLength(100)]
        public string Passport { get; set; }

        public int? CustomId { get; set; }
        public DateTime? VisitDate { get; set; }
        public string CustomName
        {
            get
            {
                return Customs.Name;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlackList> BlackList { get; set; }

        public virtual Customs Customs { get; set; }
    }
}
