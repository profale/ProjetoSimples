using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSimples.Presentation.API.Mappers
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<EntityToModelMap>();
                m.AddProfile<ModelToEntityMap>();
            });
        }
    }
}