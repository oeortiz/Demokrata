using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemokrataPerson.Context;
using WebApiDemokrataPerson.DTO;
using WebApiDemokrataPerson.Models;
using WebApiDemokrataPerson.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiDemokrataPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User        
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //---------------------------
        [HttpGet("search")]
        public async Task<List<User>> Get([FromQuery] PaginacionUserDTO paginacionDTO, [FromQuery] string NombreApellido)//datos que se le pedirá al usuario
        {
            //Aplicando paginación
            var queryable = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(NombreApellido)) {
                queryable = queryable.Where(u => u.Nombre.Contains(NombreApellido) || u.Apellido.Contains(NombreApellido));
            }
            
            await HttpContext.InsertPaginationHeader(queryable);

            var usuarios = await queryable.OrderBy(x => x.UserId).Paginate(paginacionDTO).ToListAsync();
            return usuarios;
        }
        //---------------------------

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
