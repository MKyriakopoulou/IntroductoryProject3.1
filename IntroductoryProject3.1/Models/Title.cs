using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroductoryProject3._1.Models
{
    [Table("Title")]
    public class Title
    {
        [Key]
        public int title_id { get; set; }
        public string description { get; set; }
    }
}
