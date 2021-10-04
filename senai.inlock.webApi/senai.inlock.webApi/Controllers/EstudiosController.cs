using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _EstudioRepository { get; set; }

        public EstudiosController()
        {
            _EstudioRepository = new EstudioRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudios = _EstudioRepository.Listar();

            return Ok(listaEstudios);
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idEstudio}")]
        public IActionResult GetById(int idEstudio)
        {
            EstudioDomain estudioProcurado = _EstudioRepository.BuscarPorId(idEstudio);

            if (estudioProcurado == null)
            {
                return NotFound("Nenhum estudio foi encontrado");
            }

            return Ok(estudioProcurado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _EstudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idEstudio}")]
        public IActionResult Put(int idEstudio, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioProcurado = _EstudioRepository.BuscarPorId(idEstudio);

            if (estudioProcurado == null)
            {
                return NotFound
                (new
                {
                    mensagem = "Nenhum estudio foi encontrado",
                    erro = true
                });
            }

            try
            {
                _EstudioRepository.AtualizarIdUrl(idEstudio, estudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idEstudio}")]
        public IActionResult Delete(int idEstudio)
        {
            _EstudioRepository.Deletar(idEstudio);

            return StatusCode(204);
        }
    }
}
