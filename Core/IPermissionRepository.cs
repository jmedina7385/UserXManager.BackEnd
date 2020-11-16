using System.Collections.Generic;

namespace Core
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        IEnumerable<Permission> GetPermissionsWithType();
    }
}