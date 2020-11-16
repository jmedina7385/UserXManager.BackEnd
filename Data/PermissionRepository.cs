using System.Collections.Generic;
using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PermissionRepository : EntityRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationCoreContext context) : base(context)
        {
        }

        public ApplicationCoreContext ApplicationCoreContext => Context as ApplicationCoreContext;

        public IEnumerable<Permission> GetPermissionsWithType()
        {
            return ApplicationCoreContext.Permissions.Include(t => t.PermissionType).ToList();
        }
    }
}