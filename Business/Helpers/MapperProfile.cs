using AutoMapper;
using Models;
using Ofertownik.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class MapperProfile : Profile
    {
        protected MapperProfile()
        {
            CreateMap<MaterialDTO, Material>().ReverseMap();
        }
    }
}
