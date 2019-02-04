using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inDb.Models;
namespace inDb.Controllers
{
  [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ApiContext _context;

        public UsersController(ApiContext context)
        {
            _context = context;
        }
	
	[HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _context.Users
                .Include(u => u.Posts)
                .ToArrayAsync();

            var response = users.Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                posts = u.Posts.Select(p => p.Content)
            });

            return Ok(response);
        }

  }
}