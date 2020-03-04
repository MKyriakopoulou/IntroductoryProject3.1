using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOlibrary
{
    [Table("genderDTO")]
    public class GenderDTO
    {
        [Key]
        public int gender_id { get; set; }

        public string Description { get; set; }
    }


}
