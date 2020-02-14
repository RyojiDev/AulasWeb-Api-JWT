using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_JWT.Models;
using WebApi_JWT.ProviderJWT;

namespace WebApi_JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] Usuario user)
        {
            if (user.Name != "valdir" && user.Password != "1234")
                return Unauthorized();
            var token = new TokenJWTBuilder()
                .AddSecurityKey(ProviderJWT.JWTSecurityKey.Create("Secret_key-12345678"))
                .AddSubject("Valdir Ferreira")
                .AddIssuer("Teste.Security.Bearer")
                .AddAudience("Teste.Security.Bearer")
                .AddClaim("UsuarioAPINumero", "1")
                .AddExpiry(5)
                .Builder();

            return Ok(token.value);
        }
    }
}