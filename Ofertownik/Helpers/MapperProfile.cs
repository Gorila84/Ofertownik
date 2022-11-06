using AutoMapper;
using Models;
using Ofertownik.Data.Model;

namespace Ofertownik.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MaterialDTO, Material>().ReverseMap();
            CreateMap<MachineDTO, Machine>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<CalcullationSettingDTO, CalcullationSetting>().ReverseMap(); 
        }
    }
}
