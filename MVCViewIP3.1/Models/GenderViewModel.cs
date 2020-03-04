using IntroductoryProject3._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MVCViewIP3._1.Models
{

    public class GenderViewModel
    {
        [Key]
        public int Gender_id { get; set; }

        public string description { get; set; }

    }


}
