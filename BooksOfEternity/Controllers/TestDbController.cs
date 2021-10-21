using BooksOfEternity.DataAccess;
using BooksOfEternity.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksOfEternity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestDbController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromServices] BookDbContext dbContext)
        {
            var users = await dbContext.Users.Include(x => x.UsersInfos).AsNoTracking().ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromServices] BookDbContext dbContext)
        {
            var books = await dbContext.Books.Include(x => x.BookRecords).AsNoTracking().ToListAsync();
            return Ok(books);
        }
    }
}
