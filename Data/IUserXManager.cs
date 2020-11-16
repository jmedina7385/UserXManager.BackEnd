using System;
using System.Threading.Tasks;
using Core;

namespace Data
{
    public interface IUserXManager : IDisposable
    {
        IPermissionRepository Permissions { get; }
        IPermissionTypeRepository PermissionTypes { get; }

        int JobDone();
        Task<int> JobDoneAsync();
    }
}