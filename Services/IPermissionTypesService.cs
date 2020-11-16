using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core;

namespace Services
{
    public interface IPermissionTypesService
    {
        void AddPermission(IEnumerable<PermissionType> permissions);
        void AddPermission(PermissionType permission);
        void DeletePermission(IEnumerable<PermissionType> permissions);
        void DeletePermission(PermissionType permission);
        List<PermissionType> FilterPermissionsWhere(Expression<Func<PermissionType, bool>> predicate);
        List<PermissionType> GetAllPermissions();
        PermissionType GetPermission(int id);
    }
}