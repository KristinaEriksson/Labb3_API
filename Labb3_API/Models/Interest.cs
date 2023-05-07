using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestID { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [Required]
        [StringLength(150)]
        public string? Description { get; set; }

        [ForeignKey("Members")]
        public int FK_MemberID { get; set; }
        public virtual Member Members { get; set; }

        public virtual ICollection<Link> Links { get; set; }
    }
}
