using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository.Data;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IProAgilRepositorio<Evento> _repository;
        public EventosController(IProAgilRepositorio<Evento> repositorio)
        {
            _repository = repositorio;
        }

        // GET api/eventos
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetListAsync
                                    (x => x.PalestrantesEventos);
                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
            }
        }

        // GET api/eventos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _repository.GetListFilterAsync(e => e.Id == id);
                            
                return Ok(result.FirstOrDefault());
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
            }
        }

        // POST api/eventos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Evento evento)
        { 
            try
            {
                _repository.Add(evento);
                await _repository.SaveChangesAsync();            
                return Created($"/api/evento/{evento.Id}", evento);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
            }
        }

        // PUT api/eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        { 
            try
            {
                var evento = (await _repository.GetListFilterAsync(e => e.Id == id)).FirstOrDefault();
                if(evento == null)
                    return NotFound("Evento não localizado");

                _repository.Update(evento);
                await _repository.SaveChangesAsync();            
                return Created($"/api/evento/{evento.Id}", evento);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
            }
        }

        // DELETE api/eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 var evento = (await _repository.GetListFilterAsync(e => e.Id == id)).FirstOrDefault();
                if(evento == null)
                    return NotFound("Evento não localizado");

                _repository.Delete(evento);
                await _repository.SaveChangesAsync();           
                return Ok();
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
            }
        }
    }
}
