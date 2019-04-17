using System;

namespace ProAgil.WebApi.Models
{
    public class LoteViewDto
    {        
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
    }
}