using AutoMapper;
using ServicioMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioMecanico.Mappers
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureMapping();
        }

        private static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ServicesCar, ServiceCarViewModel>();

                cfg.CreateMap<ServiceCarViewModel, ServicesCar>()
                 .ForMember(d => d.IdServicesCar,
                     opt => opt.MapFrom(src => src.IdServicesCar)
                  )
                  .ForMember(d => d.IdCar,
                     opt => opt.MapFrom(src => src.IdCar)
                 )
                 .ForMember(d => d.IdService,
                     opt => opt.MapFrom(src => src.IdService)
                 )
                 .ForMember(d => d.ServiceDate,
                     opt => opt.MapFrom(src => src.ServiceDate)
                 )
                  .ForMember(d => d.Price,
                     opt => opt.MapFrom(src => src.Price)
                 )
                  .ForMember(d => d.Observations,
                     opt => opt.MapFrom(src => src.Observations)
                 );
            });
        }
        
    }
}