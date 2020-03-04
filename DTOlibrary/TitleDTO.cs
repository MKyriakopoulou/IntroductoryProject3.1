using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOlibrary
{
    [Table("titleDTO")]
    public class TitleDTO
    {
        [Key]
        public int title_id { get; set; }
        public string description { get; set; }
    }
}
