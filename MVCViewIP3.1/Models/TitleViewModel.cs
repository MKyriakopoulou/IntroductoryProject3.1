using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCViewIP3._1.Models
{
    public class TitleViewModel
    {
        [Key]
        public int Title_id { get; set; }
        public string description { get; set; }
    }
}
