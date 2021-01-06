﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MusicController.DTOs.AutoMapper;

namespace MusicController.Shared.DIContainer
{
    public static class MapperDIContainer
    {
        public static void MapperContainer(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
