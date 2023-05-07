using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models.DTO.ListDTO
{
    public class LinkDTO
    {
        public int LinkID { get; set; }
        public string URL { get; set; }

        [ForeignKey("Members")]
        public int FK_MemberID { get; set; }
        public virtual Member? Members { get; set; }

        [ForeignKey("Interests")]
        public int FK_InterestID { get; set; }
        public virtual Interest? Interests { get; set; }
    }
}
