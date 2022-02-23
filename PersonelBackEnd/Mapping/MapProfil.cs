using AutoMapper;
using EntityLayer;
using PersonelBackEnd.Dto;

namespace PersonelBackEnd.Mapping
{
    public class MapProfil:Profile
    {
        public MapProfil()
        {
            CreateMap<Personel, PersonelDto>().ReverseMap();
        }
    }
}
