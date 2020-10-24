using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
      _context = context;
    }

    // api/users/
    [HttpGet]
    // <> "defines the format" of what is returned. Ie an enumberable list of users.
    // ActionResult is a return type of a controller method. Action methods return models to ..
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {

      // var users = _context.Users.ToList();
      return await _context.Users.ToListAsync();
      // Call: https://localhost:5001/api/users
      // Output: [{"id":1,"userName":"Bob"},{"id":2,"userName":"Tom"},{"id":3,"userName":"Jan"}]
    }

    // api/users/2
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
      // var user = _context.Users.Find(id);

      return await _context.Users.FindAsync(id);
      // Call: https://localhost:5001/api/users/1
      // Output: {"id":1,"userName":"Bob"}
    }


  }
}

// Console.WriteLine("This is C#");