using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models.DTO.InterestDTO
{
    public class InterestCreateDTO
    {
        public string? Title { get; set; }
        
        public string? Description { get; set; }
        
        public int? FK_MemberID { get; set; } 
    }
}
