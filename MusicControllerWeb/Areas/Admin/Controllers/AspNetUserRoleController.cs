using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicController.Common.Constants;
using MusicController.DTO.ViewModel;
using MusicController.Identity.IdentityRolesManagement;
using MusicController.Identity.IdentityUserManagement;
using MusicController.Identity.IdentityUserRoleManagement;
using MusicController.Shared.Constant;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MusicControllerWeb.Areas.Admin.Controllers
{
    [Area(UserRolesConstant.Admin)]
    [Authorize(Roles = UserRolesConstant.Admin)]
    public class AspNetUserRoleController : Controller
    {
        private readonly IApplicationUserServices _applicationUserServices;
        private readonly IIdentityRoleServices _identityRoleServices;
        private readonly IMapper _mapper;

        public AspNetUserRoleController(IApplicationUserServices applicationUserServices, IMapper mapper , IIdentityRoleServices identityRoleServices)
        {
            _applicationUserServices = applicationUserServices;
            _identityRoleServices = identityRoleServices;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var applicationUsers = await _applicationUserServices.GetAll();
            var booksVM = new List<UserViewModel>();
            booksVM = _mapper.Map<List<UserViewModel>>(applicationUsers);
            return View(booksVM);
        }

        // GET: Books/Edit/1  
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicationUsers = await _applicationUserServices.GetById(id);
            ViewBag.Roles= new SelectList(await _identityRoleServices.GetAllRoles(), "Name", "Name");
            var booksVM = new UserViewModel();
            booksVM = _mapper.Map<UserViewModel>(applicationUsers);
            return View(booksVM);
        }

        // POST: Books/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserViewModel userViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != userViewModel.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _applicationUserServices.AuthorizedUser(id, userViewModel.IsAuthorized, userViewModel.Role);
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }
    }
}
