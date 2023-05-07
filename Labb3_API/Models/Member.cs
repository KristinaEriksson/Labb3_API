using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; } = 0;

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = default!;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = default!;
        
        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Interest> Interests { get; set;} // Navigation
    }
}
