using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DTOlibrary
{
    [Table("lawyerDTO")]
    public class LawyerDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }


        public int Gender_id { get; set; }

        public int Title_id { get; set; }
        public string Email { get; set; }

        public GenderDTO Genderdto { get; set; }
        public TitleDTO Titledto { get; set; }

        public IEnumerable<SelectListItem> Genders { get; set; }
    }

}
