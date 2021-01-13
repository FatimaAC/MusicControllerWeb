using AutoMapper;
using MusicController.DTO.DTOS;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using MusicController.Identity.Model;

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
        }
    }
}
