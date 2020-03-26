using AutoMapper;
using ProjetoSimples.Domain.DomainEntities;
using ProjetoSimples.Presentation.API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSimples.Presentation.API.Mappers
{
    public class EntityToModelMap : Profile
    {
        protected override void Configure()
        {

            Mapper.CreateMap<Contato, ContatoRequestModel>();
            Mapper.CreateMap<Operadora, OperadoraRequestModel>();
        }
    }
}