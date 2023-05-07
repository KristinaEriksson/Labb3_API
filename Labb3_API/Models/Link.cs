using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkID { get; set; }
        public string URL { get; set; }

        [ForeignKey("Interests")]
        public int FK_InterestID { get; set; }
        public virtual Interest? Interests { get; set; }
        

    }
}
