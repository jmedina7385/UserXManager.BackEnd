using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;
using Services;
using UserXManager.Validators;

namespace UserXManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Guid("2A595E5D-A318-413F-AFA4-BB5790AAFA16")]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IPermissionTypesService _permissionService;

        public PermissionTypesController(IPermissionTypesService permiService)
        {
            _permissionService = permiService;
        }

        [HttpGet]
        public async Task<IEnumerable<PermissionType>> GetAllPermissions()
        {
            return await Task.FromResult(_permissionService.GetAllPermissions());
        }

        [HttpPost]
        public async Task<PermissionType> PostPermission([FromBody] PermissionType permission)
        {
            if (!PermissionValidator.ValidateIsNotEmpty(null, permission.Description)
                .WithRequiredCharacters(permission.Description, 5)
                .IsValid)
                return await Task.FromResult(new PermissionType());

            _permissionService.AddPermission(permission);
            return await Task.FromResult(permission);
        }

        [HttpGet("{id}")]
        public async Task<PermissionType> GetPermission(int? id)
        {
            var foundPermission = _permissionService.GetPermission(id.Value);
            return await Task.FromResult(foundPermission);
        }

        [HttpDelete]
        public async Task<string> DeletePermission([FromBody] PermissionType permission)
        {
            if (permission == null)
            {
                var failed = "invalid operation";
                return await Task.FromResult(failed);
            }

            _permissionService.DeletePermission(permission);
            var ok = $"{permission.Id} Deleted";
            return await Task.FromResult(ok);
        }
    }
}