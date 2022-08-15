namespace Egypt_Times.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class News
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeName { get; set; }

        [StringLength(255)]
        public string newsDescription { get; set; }

        public virtual ICollection<Person> People { get; set; }


       
    }
}
