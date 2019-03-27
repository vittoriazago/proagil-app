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
                var results = await _repository.GetListFilterAsync
                                    (d => d.Email =="",
                                     x => x.PalestrantesEventos);
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
                return Ok(_repository.GetListFilterAsync(e => e.Id == id));
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
            }
        }

        // POST api/eventos
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/eventos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/eventos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
