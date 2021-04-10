using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public FacebookContext Contexto { get; set; }

        public UsuarioController(FacebookContext c)
        {
            Contexto = c;
        }

        [HttpPost]
        public string Login([FromForm] string email, [FromForm] string senha)
        {
            var usuario = Contexto.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return Gerar(usuario.Nome, usuario.Email, usuario.Id, 120);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Default, Google")]
        public object Teste()
        {
            var tokenIssuer = Request.Headers["x-custom-header"].ToString();
            Usuario usuario;

            if (tokenIssuer == "Google")
                usuario = Contexto.Usuarios.FirstOrDefault(u => u.Email == HttpContext.User.Claims.ElementAt(9).Value.ToString());
            else
                usuario = Contexto.Usuarios.Find(Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value));

            return new
            {
                Situacao = "Autorizado",
                Id = usuario.Id
            };
        }

        //Quando um usuário fizer login com email e senha, será retornado esse token, que será validado pela primeira AddJwtBearer do startup.
        public static string Gerar(string nome, string email, Guid id, int minutos)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Facebook-b71e507ae8f44b4396530166279942af"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("nome", nome),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, id.ToString())
            };

            var token = new JwtSecurityToken
                (
                    "Facebook",
                    "Facebook",
                    claims,
                    expires: DateTime.Now.AddMinutes(minutos),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
