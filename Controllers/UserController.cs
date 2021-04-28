using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.models;
using Shop.Services;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromServices] Datacontext context, [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar o usuário" });
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] Datacontext context, [FromBody] User model)
        {
            var user = await context.Users
            .AsNoTracking()
            .Where(x => x.Username == model.Username && x.Password == model.Password)
            .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuario ou senha invalida" });

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user,
                token = token
            };
        }
    }
}