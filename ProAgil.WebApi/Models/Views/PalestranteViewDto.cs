using System.Collections.Generic;

namespace ProAgil.WebApi.Models
{
    public class PalestranteViewDto
    {        
        public string Nome { get; set; } 
        public string MiniCurriculo { get; set; } 
        public string ImagemURL { get; set; } 
        public string Email { get; set; }
        public string Telefone { get; set; }
        
        public List<EventoViewDto> Eventos { get; set; } 
    }
}