using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebApi.Models;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return new Evento[] { 
                new Evento(){
                    EventoId = 1, 
                    Tema = "Angular e .NET",
                    Local = "Bauru",
                    Lote = "1º LOTE",
                    QtdPessoas = 100,
                    DataEvento = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy")
                }, 
                new Evento(){
                    EventoId = 2, 
                    Tema = "Angular e novidades",
                    Local = "São Paulo",
                    Lote = "2º LOTE",
                    QtdPessoas = 300,
                    DataEvento = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy")
                },
             };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
