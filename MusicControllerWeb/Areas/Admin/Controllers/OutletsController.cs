using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicController.BL.FileServices;
using MusicController.BL.OutletServices;
using MusicController.Common.Constants;
using MusicController.DTO.ViewModel;
using MusicController.Entites.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    //todo: action level roles implementation remaining  Create and Manage = Admin , Schudle =Dj
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.AdminorDJ)]
    public class OutletsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOutletService _outletService;
        private readonly IFileServices _fileServices;
        public OutletsController(IFileServices fileServices, IMapper mapper, IOutletService outletService)
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
                if (outletViewModel.File == null || outletViewModel.File.Length <= 0)
                {
                    ModelState.AddModelError("", "Outlet logo requried");
                }
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
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
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
            var outletViewModel = _mapper.Map<OutletCreateViewModel>(outlet);
            return View(outletViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, OutletCreateViewModel outletViewModel)
        {
            if (id != outletViewModel.Id)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(outletViewModel.ImageUrl) && (outletViewModel.File == null || outletViewModel.File.Length <= 0))
            {
                ModelState.AddModelError("", "Outlet logo requried");
            }
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(outletViewModel.ImageUrl) && outletViewModel.File != null && outletViewModel.File.Length > 0)
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
        public async Task<IActionResult> Schedule(long? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePassword(long id, OutletPasswordsViewModel OutletPasswords)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _outletService.UpdatePasswordOutlet(id, OutletPasswords.Password);
                return RedirectToAction(nameof(Index));
            }
            var manageOutlet = await _outletService.ManageOutletsWithDevicesandPassword(id);
            return View("Edit", manageOutlet);
        }

    }
}
