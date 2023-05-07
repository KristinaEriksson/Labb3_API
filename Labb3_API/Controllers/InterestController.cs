using AutoMapper;
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
    public class InterestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public InterestController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InterestDTO>>> GetInterest()
        {
            IEnumerable<Interest> interests = await _context.Interests.ToListAsync();
            var interest = _mapper.Map<List<Interest>>(interests);
            return Ok(interest);
        }

        // Get all interests connected to one member
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<InterestDTO>>> AllInterestMember(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var interest = await _context.Interests
                .Where(m => m.FK_MemberID == id)
                .ToListAsync();
            return Ok(interest);
        }
        // Connect a member to a interest
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InterestCreateDTO>> CreateInterest([FromBody] InterestCreateDTO interestCreateDTO)
        {
           
            Interest model = _mapper.Map<Interest>(interestCreateDTO);
            await _context.Interests.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id:int}", Name = "UpdateInterest")]
        public async Task<IActionResult> UpdateInterest(int id, [FromBody] InterestUpdateDTO interestUpdateDTO)
        {
            var interest = await _context.Interests.FirstOrDefaultAsync(i => i.InterestID == id);
            _mapper.Map(interestUpdateDTO, interest);
            _context.Update(interest);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpDelete("{id:int}", Name = "DeleteInterest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var interest = await _context.Interests.FirstOrDefaultAsync(i => i.InterestID == id);
            if (interest == null)
            {
                return NotFound();
            }
            _context.Interests.Remove(interest);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
