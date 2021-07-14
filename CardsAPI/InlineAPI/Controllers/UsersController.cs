using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InlineAPI.Models;
using InlineAPI.Models.Request;

namespace InlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CustomContext _context;

        public UsersController(CustomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Card>>> GetUser([FromQuery] string email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _context.Users
                    .Where(user => user.Email == email)
                    .Select(user => new
                    {
                        User = user,
                        Cards = user.Cards.OrderBy(c => c.Created).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound();
                }

                return user.Cards;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostUser([FromBody] UserRequest body)
        {
            if (body.Email == null)
            {
                return BadRequest("Email é obrigatório");
            }

            User user = _context.Users.Where(user => user.Email == body.Email).FirstOrDefault();

            if (user == null)
            {
                user = new User();
                user.Email = body.Email;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            try
            {
                Card card = new Card();
                card.GenerateCard();


                card.UserId = user.Id;

                _context.Cards.Add(card);
                await _context.SaveChangesAsync();

                return card.Number;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
