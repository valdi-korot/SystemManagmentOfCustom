namespace SystemOfManagmentCustom.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlackList")]
    public partial class BlackList
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? PersonId { get; set; }

        public string PersonName
        {
            get
            {
                return Persons.LName + " " + Persons.FName;
            }
        }

        public virtual Persons Persons { get; set; }
    }
}
