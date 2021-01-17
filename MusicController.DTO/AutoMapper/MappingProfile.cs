using AutoMapper;
using MusicController.DTO.DTOModel;
using MusicController.DTO.RequestModel;
using MusicController.DTO.ViewModel;
using MusicController.DTOModel.DTOS;
using MusicController.Entites.Models;
using MusicController.Identity.Model;
using MusicController.Identity.Models;

namespace MusicController.DTOs.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<TrackViewModel, Track>().ReverseMap();
            CreateMap<Outlet, OutletCreateViewModel>().ReverseMap();

            CreateMap<Playlist, PlaylistViewModel>().ReverseMap();
            CreateMap<Playlist, PlaylistIndexModel>().ReverseMap();
            CreateMap<Device, DeviceViewModel>().ReverseMap();
            CreateMap<OutletPasswordsViewModel, Outlet>().ReverseMap()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)).
                ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.Password));
            //api dto 
            CreateMap<Outlet, OutletNameDTO>().ReverseMap();
            CreateMap<RefreshToken, RefreshTokenDTO>().ReverseMap();

            //api request
            CreateMap<Device, DevicesRequest>().ReverseMap();
        }
    }
}
