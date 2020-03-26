using AutoMapper;
using ProjetoSimples.Domain.DomainEntities;
using ProjetoSimples.Presentation.API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSimples.Presentation.API.Mappers
{
    public class ModelToEntityMap : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ContatoRequestModel, Contato>()
                .ForMember(dest => dest.IdOperadora, src => src.MapFrom(c => c.IdOperadora));
            Mapper.CreateMap<OperadoraRequestModel, Operadora>();
        }
    }
}