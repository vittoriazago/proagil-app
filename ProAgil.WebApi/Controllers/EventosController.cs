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
using ProAgil.WebApi.Models;
using AutoMapper;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProAgilRepositorio<Evento> _repository;
        
        public EventosController(IMapper mapper,
            IProAgilRepositorio<Evento> repositorio)
        {
            _mapper = mapper;
            _repository = repositorio;
        }

        // GET api/eventos
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
                var results = await _repository.GetListAsync(
                                        x => x.PalestrantesEventos);
                                     //.ThenInclude(x => x.Palestrante);
                var eventos = _mapper.Map<IEnumerable<EventoViewDto>>(results);
                return Ok(eventos);
            
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
        public async Task<IActionResult> Post([FromBody] Evento eventoNovo)
        {     
          
                //var evento = _mapper.Map<Evento>(eventoNovo);
                
                _repository.Add(eventoNovo);
                await _repository.SaveChangesAsync();            
                return Created($"/api/evento/{eventoNovo.Id}", eventoNovo);
            
        }

        // PUT api/eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Evento eventoEdit)
        {             
            try
            {
                var evento = (await _repository.GetListFilterAsync(e => e.Id == id)).FirstOrDefault();
                if(evento == null)
                    return NotFound("Evento não localizado");

                evento.Telefone = eventoEdit.Telefone;
                evento.Email = eventoEdit.Email;
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
