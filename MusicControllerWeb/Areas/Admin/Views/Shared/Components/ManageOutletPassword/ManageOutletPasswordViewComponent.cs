﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicController.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicControllerWeb.Components.OutletPassword
{
    public class ManageOutletPasswordViewComponent : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync(long OutletId)
        {
            OutletPasswordsViewModel outletPasswords = new OutletPasswordsViewModel()
            {
                Id = OutletId
            };
            return await Task.FromResult((IViewComponentResult)View("ManageOutletPassword" , outletPasswords));
        }
    }
}
