using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicController.Common.Constants;
using MusicController.DTO.ViewModel;
using MusicController.Identity.IdentityRolesManagement;
using MusicController.Identity.IdentityUserManagement;
using System.Collections.Generic;
using System.Linq;
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

        public AspNetUserRoleController(IApplicationUserServices applicationUserServices, IMapper mapper, IIdentityRoleServices identityRoleServices)
        {
            _applicationUserServices = applicationUserServices;
            _identityRoleServices = identityRoleServices;
            _mapper = mapper;
        }
        // GET: Admin/AspNetUserRole 
        public async Task<IActionResult> Index()
        {
            var applicationUsers = await _applicationUserServices.GetAll();
            var userViewModel = _mapper.Map<List<UserViewModel>>(applicationUsers);
            return View(userViewModel);
        }
        // GET: Admin/AspNetUserRole/Edit/1  
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicationUsers = await _applicationUserServices.GetById(id);
            ViewBag.Roles = new SelectList(await _identityRoleServices.GetAllRoles(), "Name", "Name");
            var userViewModel = _mapper.Map<UserViewModel>(applicationUsers);
            var userRoles = await _applicationUserServices.GetUserRoles(applicationUsers);
            userViewModel.Role = userRoles.FirstOrDefault();
            return View(userViewModel);
        }

        //Post: Admin/AspNetUserRole/Edit/1
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
