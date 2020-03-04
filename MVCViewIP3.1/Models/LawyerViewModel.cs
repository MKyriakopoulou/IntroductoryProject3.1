using IntroductoryProject3._1.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace MVCViewIP3._1.Models
{
    public class LawyerViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public short gender_id { get; set; }
        [Display(Name = "Title")]
        public short title_id { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DateOfBirth { get; set; }




    }




}
