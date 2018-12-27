using AutoMapper;

namespace APISmartCity.Infra
{
   public class MappingProfile : Profile
    {   
        public MappingProfile()
        {
            CreateMap<Model.LoginModel, DTO.LoginModelDTO>();
            CreateMap<DTO.LoginModelDTO, Model.LoginModel>();
            CreateMap<DTO.OpeningPeriodDTO, Model.OpeningPeriod>();
            CreateMap<Model.OpeningPeriod, DTO.OpeningPeriodDTO>();
            CreateMap<Model.Commerce, DTO.CommerceDTO>();
            CreateMap<DTO.CommerceDTO, Model.Commerce>();
            CreateMap<DTO.UserDTO, Model.User>();
            CreateMap<Model.User, DTO.UserDTO>();
            CreateMap<DTO.ActualiteDTO, Model.Actualite>();
            CreateMap<Model.Actualite, DTO.ActualiteDTO>();
        }
    }
}

