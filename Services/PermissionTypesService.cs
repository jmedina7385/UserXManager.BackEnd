using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core;
using Data;

namespace Services
{
    public class PermissionTypesService : IPermissionTypesService
    {
        private readonly IUserXManager _dataManager;

        public PermissionTypesService(IUserXManager contextService)
        {
            _dataManager = contextService;
        }

        public void AddPermission(PermissionType permission)
        {
            var update = permission.Id > 0;

            _dataManager.PermissionTypes.Add(permission, update);
            _dataManager.JobDone();
        }

        public void AddPermission(IEnumerable<PermissionType> permissions)
        {
            _dataManager.PermissionTypes.AddRange(permissions);
            _dataManager.JobDone();
        }

        public PermissionType GetPermission(int id)
        {
            return _dataManager.PermissionTypes.GetById(id);
        }

        public List<PermissionType> GetAllPermissions()
        {
            return _dataManager.PermissionTypes.GetAll().ToList();
        }

        public List<PermissionType> FilterPermissionsWhere(Expression<Func<PermissionType, bool>> predicate)
        {
            return _dataManager.PermissionTypes.Find(predicate).ToList();
        }

        public void DeletePermission(PermissionType permission)
        {
            _dataManager.PermissionTypes.Delete(permission);
            _dataManager.JobDone();
        }

        public void DeletePermission(IEnumerable<PermissionType> permissions)
        {
            _dataManager.PermissionTypes.DeleteRange(permissions);
            _dataManager.JobDone();
        }
    }
}