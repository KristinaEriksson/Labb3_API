using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb3_API.Models.DTO.MemberDTO
{
    public class MemberCreateDTO
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = default!;
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
    }
}
