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
        public int User_ID { get; set; }
        public int News_ID { get; set; }

    }
}