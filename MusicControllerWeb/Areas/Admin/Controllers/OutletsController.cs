using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicController.BL.FileServices;
using MusicController.BL.OutletServices;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Context;
using MusicController.Entites.Models;
using MusicController.Shared.Constant;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.Admin)]
    public class OutletsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOutletService _outletService;
        private readonly IFileServices _fileServices;
        public OutletsController( IFileServices fileServices, IMapper mapper ,IOutletService outletService)
        {
            _outletService = outletService;
            _fileServices = fileServices;
            _mapper = mapper;
        }

        // GET: Admin/Outlets
        public async Task<IActionResult> Index()
        {
            var outletsViewModel = await _outletService.GetAllOutletsWithDevicesAndPlaylist();
            return View(outletsViewModel);
        }

        // GET: Admin/Outlets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlet = await _outletService.GetOutlet(id.Value);
            if (outlet == null)
            {
                return NotFound();
            }
            var outletiewModel = _mapper.Map<List<OutletCreateViewModel>>(outlet);
            return View(outletiewModel);
        }

        // GET: Admin/Outlets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Outlets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ImageUrl,Description ,File")] OutletCreateViewModel outletViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    outletViewModel.ImageUrl = await _fileServices.SaveFile(outletViewModel.File);
                    var outlet = _mapper.Map<Outlet>(outletViewModel);
                    await _outletService.AddOutlet(outlet);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View(outletViewModel);
            }
           
            return View(outletViewModel);
        }

        // GET: Admin/Outlets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlet = await _outletService.GetOutlet(id.Value);
            if (outlet == null)
            {
                return NotFound();
            }
            var outletiewModel = _mapper.Map<OutletCreateViewModel>(outlet);
            return View(outletiewModel);
        }

        // POST: Admin/Outlets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,ImageUrl,Description ,File")] OutletCreateViewModel outletViewModel)
        {
            if (id != outletViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (outletViewModel.File.Length>0)
                {
                    outletViewModel.ImageUrl = await _fileServices.SaveFile(outletViewModel.File);
                }
                
                var outlet = _mapper.Map<Outlet>(outletViewModel);
                await _outletService.UpdateOutlet(id, outlet);
                return RedirectToAction(nameof(Index));
            }
            return View(outletViewModel);
        }

        // GET: Admin/Outlets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlet = await _outletService.GetOutlet(id.Value);
            if (outlet == null)
            {
                return NotFound();
            }
            var outletiewModel = _mapper.Map<List<OutletCreateViewModel>>(outlet);
            return View(outletiewModel);
        }

        // POST: Admin/Outlets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _outletService.DeleteOutlet(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
