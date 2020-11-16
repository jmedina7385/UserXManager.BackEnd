using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace UserXManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService service)
        {
            _permissionService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return await Task.FromResult(_permissionService.GetAllPermissionsWithTypes());
        }

        [Route("/api/PermissionWithTypes")]
        [HttpGet]
        public async Task<IEnumerable<Permission>> GetAllPermissionsWithTypes()
        {
            return await Task.FromResult(_permissionService.GetAllPermissionsWithTypes());
        }

        [HttpPost]
        public async Task<Permission> PostPermission([FromBody] Permission permission)
        {
            _permissionService.AddPermission(permission);
            return await Task.FromResult(permission);
        }

        [HttpGet("{id}")]
        public async Task<Permission> GetPermission(int? id)
        {
            var foundPermission = _permissionService.GetPermission(id.Value);
            return await Task.FromResult(foundPermission);
        }

        [HttpDelete]
        public async Task<string> DeletePermission([FromBody] Permission permission)
        {
            _permissionService.DeletePermission(permission);
            var ok = $"{permission.Id} Deleted";
            return await Task.FromResult(ok);
        }
    }
}