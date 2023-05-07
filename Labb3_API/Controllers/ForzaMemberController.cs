using AutoMapper;
using Azure;
using Labb3_API.Data;
using Labb3_API.Models;
using Labb3_API.Models.DTO.InterestDTO;
using Labb3_API.Models.DTO.MemberDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ForzaMemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ForzaMemberController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all 
        [HttpGet("Get All members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetMember()
        {
            IEnumerable<Member> members = await _context.Members.ToListAsync();
            return Ok(members);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MemberDTO>> GetMember(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MemberDTO>> CreateMember([FromBody] MemberCreateDTO memberCreateDTO)
        {
            Member model = _mapper.Map<Member>(memberCreateDTO);
            await _context.Members.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(memberCreateDTO);
        }
        

        [HttpPut("{id:int}", Name = "UpdateMember")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Member>> UpdateMember(int id, [FromBody] MemberUpdateDTO memberUpdateDTO)
        {
            if (memberUpdateDTO == null || id != memberUpdateDTO.MemberID)
            {
                return BadRequest();
            }
            Member model = _mapper.Map<Member>(memberUpdateDTO);
            _context.Members.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}", Name = "DeleteMember")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMember(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound();
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
