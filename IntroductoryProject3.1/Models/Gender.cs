using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace IntroductoryProject3._1.Models
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        public int gender_id { get; set; }

        public string description { get; set; }


    }


}
