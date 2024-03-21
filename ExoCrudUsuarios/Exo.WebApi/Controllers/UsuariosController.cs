using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

        //Sequencia do CRUD
        [HttpPost]
        public IActionResult Cadastrar (Usuario usuario){
            
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(201);

        }

        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id){

            Usuario usuario = _usuarioRepository.BuscaPorId(id);
            if(usuario == null){
                return NotFound();
            }
            return Ok(usuario);

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario){

            _usuarioRepository.Atualizar(id, usuario);
            return StatusCode(204);
            
        }

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