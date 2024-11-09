using ExoApi.Domains;
using ExoApi.Repositores;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ExoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuariosRepository;

        public UsuariosController(UsuarioRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;

        }
        [Authorize]
        [HttpGet]

        public IActionResult ListarUsuarios()
        {
            return StatusCode(200, _usuariosRepository.Listar());
        }

        //[HttpPost]
        //public IActionResult CriarUsuario(Usuario usuario)
        //{
        //    _usuariosRepository.Criar(usuario);

        //    return StatusCode(201);
        //}

        [HttpPost]

        public IActionResult FazerLogin(Usuario usuario)
        {
            Usuario usuarioBuscado = _usuariosRepository.BuscarPorEmailESenha(usuario);

            if (usuarioBuscado == null)
            {
                return StatusCode(401);

            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("kshashkfkljfhaklfhajkfjalj"))

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "exoapi.webapi",
                audience: "exoapi.webapi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30)
                signingCredentials : creds  
                );

            return StatusCode(200, new {token = new JwtSecurityTokenHandler().WriteToken(token)});
        }       
            
               return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token) });

        [Authorize]
        [HttpPut("{id}")]

        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
        if (_usuarioRepository.BuscarPorId(id) == null)

            return StatusCode(404)
        }
         _usuarioRepository.Atualizar(id, usuario);

        return StatusCode(204);

    [Authorize]
    [HttpDelete("id")]

    public IActionResult Deletar(int id) 
    {
        if(_usuarioRepository.BuscarPorId(id) == null) 
        {
            return StatusCode(404);
        }

        _usuarioRepository.Deletar(id);

        return StatusCode(204);

    }

 }
