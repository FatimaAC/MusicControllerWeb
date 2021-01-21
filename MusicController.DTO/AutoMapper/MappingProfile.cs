using AutoMapper;
using MusicController.Common.HelperClasses;
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
            CreateMap<Track, TrackViewModel>()
                .ForMember(dest => dest.FormatedStartTime, opt => opt.MapFrom(src => DateTimeHelper.ShortTimeTo12HourFormat(src.StartTime))).
                ForMember(dest => dest.FormatedEndTime, opt => opt.MapFrom(src => DateTimeHelper.ShortTimeTo12HourFormat(src.EndTime)));

            CreateMap<TrackViewModel, Track>()
               .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => DateTimeHelper.ShortTimeTo24HourFormat(src.FormatedStartTime))).
               ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTimeHelper.ShortTimeTo24HourFormat(src.FormatedEndTime)));
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
