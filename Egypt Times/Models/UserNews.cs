using Egypt_Times.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Egypt_Times.Models
{
    public class UserNews
    {
        [Key, Column(Order = 2)]
        public int User_ID { get; set; }
        //public virtual Person User { get; set; }
        [Key, Column(Order = 1)]
        public int News_ID { get; set; }
        //public virtual News News { get; set; }

    }
}