namespace NewsAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(30)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
