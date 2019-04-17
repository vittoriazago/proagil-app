using System;
using System.Collections.Generic;

namespace ProAgil.WebApi.Models
{
    public class EventoViewDto
    {        
        public int Id { get; set; }

        public string Local { get; set; }
        public string Tema { get; set; }
        public DateTime DataEvento { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImagemURL { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        
        public List<LoteViewDto> Lotes { get; set; } 
        public List<RedeSocialViewDto> RedesSociais { get; set; }
        public List<PalestranteViewDto> Palestrantes { get; set; }
    }
}