using System;
using System.Collections.Generic;

namespace ProAgil.WebApi.Models
{
    public class EventoCreateDto
    {        
        public string Local { get; set; }
        public string Tema { get; set; }
        public DateTime DataEvento { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImagemURL { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        
        public List<LoteCreateDto> Lotes { get; set; } 
        public List<RedeSocialCreateDto> RedesSociais { get; set; }
        public List<PalestranteCreateDto> Palestrantes { get; set; }
    }
}