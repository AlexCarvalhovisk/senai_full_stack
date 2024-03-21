using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Exo.WebApi.Controllers{

    [Produces("application/jason")]
    [Route("/api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuariosRepository){
            _usuarioRepository = usuariosRepository;
        }

        [HttpGet]
        public IActionResult Listar(){

            return Ok(_usuarioRepository.Listar());

        }

        // Fim do método {POST} que auxilia no LOGIN

        //Sequencia do CRUD
        // [HttpPost]
        // public IActionResult Cadastrar (Usuario usuario){
            
        //     _usuarioRepository.Cadastrar(usuario);
        //     return StatusCode(201);

        // }

        public IActionResult Post(Usuario usuario){
            Usuario usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(

                issuer: "exoapi.webapi", //cria o token
                audience: "exoapi.webapi", //Destinatário do token
                claims: claims, //Dados pré-definidos acima
                expires: DateTime.Now.AddMinutes(30), //Tempo do token
                signingCredentials: creds //Credenciais do token

            );

            return Ok(new{token = new JwtSecurityTokenHandler().WriteToken(token)});

        }
        

        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id){

            Usuario usuario = _usuarioRepository.BuscaPorId(id);
            if(usuario == null){
                return NotFound();
            }
            return Ok(usuario);

        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario){

            _usuarioRepository.Atualizar(id, usuario);
            return StatusCode(204);
            
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){

            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                
                return BadRequest();
            }

        }
        
    }

}