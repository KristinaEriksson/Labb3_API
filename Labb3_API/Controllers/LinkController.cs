using AutoMapper;
using Labb3_API.Data;
using Labb3_API.Models;
using Labb3_API.Models.DTO.InterestDTO;
using Labb3_API.Models.DTO.ListDTO;
using Labb3_API.Models.DTO.MemberDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LinkController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LinkDTO>>> GetList()
        {
            IEnumerable<Link> membersList = await _context.Links.ToListAsync();
            return Ok(membersList);
        }

        // Get all links that is connected to one member
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LinkDTO>> GetList(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var list = await (from l in _context.Links
                              join i in _context.Interests on l.FK_InterestID equals i.InterestID
                              where i.FK_MemberID == id
                              select l.URL).ToListAsync();

            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // Add new links to one member and interest
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LinkDTO>> CreateList([FromBody] LinkCreateDTO linkCreateDTO)
        {
            if (await _context.Links.FirstOrDefaultAsync(l => l.URL.ToLower() == linkCreateDTO.URL.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "This url already exist");
                return BadRequest(ModelState);
            }
            if (linkCreateDTO == null)
            {
                return BadRequest(linkCreateDTO);
            }

            Link model = _mapper.Map<Link>(linkCreateDTO);
            await _context.Links.AddAsync(model);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetList", new { id = linkCreateDTO.URL }, model);
        }


        [HttpPut("{id:int}", Name = "UpdateList")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateList(int id, [FromBody] LinkUpdateDTO linkUpdateDTO)
        {
            if (linkUpdateDTO == null || id != linkUpdateDTO.LinkID)
            {
                return BadRequest();
            }
            Link model = _mapper.Map<Link>(linkUpdateDTO);
            _context.Links.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
      
        [HttpDelete("{id:int}", Name = "DeleteList")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteList(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var link = await _context.Links.FirstOrDefaultAsync(l => l.LinkID == id);
            if (link == null)
            {
                return NotFound();
            }
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
