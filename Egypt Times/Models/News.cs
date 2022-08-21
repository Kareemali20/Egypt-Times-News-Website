namespace Egypt_Times.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class News
    {

        public int ID { get; set; }
        public string TypeName { get; set; }
        public string newsDescription { get; set; }
        public virtual ICollection<Person> People { get; set; }

    }
}
