using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models.DTO.ListDTO
{
    public class LinkUpdateDTO
    {
        public int LinkID { get; set; }

        public string URL { get; set; }
    }
}
