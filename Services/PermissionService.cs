using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core;
using Data;

namespace Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUserXManager _dataManager;

        public PermissionService(IUserXManager contextService)
        {
            _dataManager = contextService;
        }

        public void AddPermission(Permission permission)
        {
            var update = permission.Id > 0 ? true : false;

            _dataManager.Permissions.Add(permission, update);
            _dataManager.JobDone();
        }

        public void AddPermission(IEnumerable<Permission> permissions)
        {
            _dataManager.Permissions.AddRange(permissions);
            _dataManager.JobDone();
        }

        public Permission GetPermission(int id)
        {
            return _dataManager.Permissions.GetById(id);
        }

        public List<Permission> GetAllPermissions()
        {
            return _dataManager.Permissions.GetAll().ToList();
        }

        public List<Permission> FilterPermissionsWhere(Expression<Func<Permission, bool>> predicate)
        {
            return _dataManager.Permissions.Find(predicate).ToList();
        }

        public void DeletePermission(Permission permission)
        {
            _dataManager.Permissions.Delete(permission);
            _dataManager.JobDone();
        }

        public void DeletePermission(IEnumerable<Permission> permissions)
        {
            _dataManager.Permissions.DeleteRange(permissions);
            _dataManager.JobDone();
        }

        public List<Permission> GetAllPermissionsWithTypes()
        {
            return _dataManager.Permissions.GetPermissionsWithType().ToList();
        }
    }
}