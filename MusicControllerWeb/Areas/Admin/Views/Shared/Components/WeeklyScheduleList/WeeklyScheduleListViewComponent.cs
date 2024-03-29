﻿using Microsoft.AspNetCore.Mvc;
using MusicController.BL.PlaylistsServices;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Views.Shared.Components.ScheduleWeeklyList
{
    public class WeeklyScheduleListViewComponent : ViewComponent
    {
        private readonly IPlaylistServices _tracksServices;
        public WeeklyScheduleListViewComponent(IPlaylistServices tracksServices)
        {
            _tracksServices = tracksServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(long outletId)
        {
            var weeklyScheduleList = await _tracksServices.WeeklyScheduleList(outletId);
            return View("WeeklyScheduleList", weeklyScheduleList);
        }
    }
}
