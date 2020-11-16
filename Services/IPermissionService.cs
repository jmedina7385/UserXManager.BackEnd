using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core;

namespace Services
{
    public interface IPermissionService
    {
        void AddPermission(IEnumerable<Permission> permissions);
        void AddPermission(Permission permission);
        void DeletePermission(IEnumerable<Permission> permissions);
        void DeletePermission(Permission permission);
        List<Permission> FilterPermissionsWhere(Expression<Func<Permission, bool>> predicate);
        List<Permission> GetAllPermissions();
        Permission GetPermission(int id);
        List<Permission> GetAllPermissionsWithTypes();
    }
}