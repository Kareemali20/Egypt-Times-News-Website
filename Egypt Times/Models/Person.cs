namespace Egypt_Times.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class Person
    {
     

        public int ID { get; set; }
        [DisplayName("First Name")]

        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<News> News { get; set; }
    }
}
