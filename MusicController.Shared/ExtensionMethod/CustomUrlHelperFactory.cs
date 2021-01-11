using Microsoft.AspNetCore.Mvc;
using MusicController.Common.Constants;
using MusicController.Identity.UserService;
using MusicController.Shared.Constant;

namespace MusicController.Shared.ExtensionMethod
{
    public class CustomUrlHelper
    {
        private readonly IUrlHelper _originalUrlHelper;
        private readonly ICurrentUserService _currentUserService;
        public CustomUrlHelper(IUrlHelper originalUrlHelper, ICurrentUserService currentUserService)
        {
            _originalUrlHelper = originalUrlHelper;
            _currentUserService = currentUserService;
        }
        public string ReturnURL()
        {
            string url = _originalUrlHelper.Action("Index", "Outlets", new { Area = UserRolesConstant.Admin });
            switch (_currentUserService.UserRole)
            {
                case UserRolesConstant.Admin:
                case UserRolesConstant.Dj:
                    url = _originalUrlHelper.Action("Index", "Outlets", new { Area = UserRolesConstant.Admin });
                    break;
                default:
                    break;
            }
            return url;
        }

        public bool IsRoleAdmin()
        {
            bool hasrole = false;
            switch (_currentUserService.UserRole)
            {
                case UserRolesConstant.Admin:
                    hasrole = true;
                    break;
            }
            return hasrole;
        }
        public bool IsRoleDj()
        {
            bool hasrole = false;
            switch (_currentUserService.UserRole)
            {
                case UserRolesConstant.Dj:
                    hasrole = true;
                    break;
            }
            return hasrole;
        }
        public string RolebaseOutletUrl(long id)
        {
            string url = _originalUrlHelper.Action("Edit", "Outlets", new { id = id, Area = UserRolesConstant.Admin });
            switch (_currentUserService.UserRole)
            {
                case UserRolesConstant.Admin:
                    url = _originalUrlHelper.Action("Edit", "Outlets", new { id = id, Area = UserRolesConstant.Admin });
                    break;
                case UserRolesConstant.Dj:
                    url = _originalUrlHelper.Action("Schedule", "Outlets", new { id = id, Area = UserRolesConstant.Admin });
                    break;
                default:
                    break;
            }
            return url;
        }
    }
}
