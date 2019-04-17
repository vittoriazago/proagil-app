using AutoMapper;
using System.Linq;
using ProAgil.Domain;
using ProAgil.WebApi.Models;
using System.Collections.Generic;

namespace ProAgil.WebApi.Mappings
{
    public class MappingProfile: Profile {

        public MappingProfile()
        {
            CreateMap<LoteCreateDto, Lote>();
            CreateMap<EventoCreateDto, Evento>();
            CreateMap<RedeSocialCreateDto, RedeSocial>();
            CreateMap<PalestranteCreateDto, Palestrante>();

            CreateMap<Lote, LoteViewDto>();
            CreateMap<Evento, EventoViewDto>()
              .ForMember(dest => dest.Palestrantes, orig => {
                  orig.MapFrom(src => src.PalestrantesEventos
                                         .Select(p => p.Palestrante));
              });
            CreateMap<RedeSocial, RedeSocialViewDto>();
            CreateMap<Palestrante, PalestranteViewDto>()
              .ForMember(dest => dest.Eventos, orig => {
                  orig.MapFrom(src => src.PalestrantesEventos
                                         .Select(p => p.Evento));
              })
              ;
        }

    }
}