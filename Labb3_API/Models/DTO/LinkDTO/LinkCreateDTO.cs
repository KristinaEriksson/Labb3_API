using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models.DTO.ListDTO
{
    public class LinkCreateDTO
    {
        [Required]
        public string URL { get; set; }

        public int FK_InterestID { get; set; }
        public int FK_MemberID { get; set; }
    }
}
