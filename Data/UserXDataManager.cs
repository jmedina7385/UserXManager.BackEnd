using System.Threading.Tasks;
using Core;

namespace Data
{
    public class UserXDataManager : IUserXManager
    {
        private readonly ApplicationCoreContext _context;

        public UserXDataManager(ApplicationCoreContext context)
        {
            _context = context;
            Permissions = new PermissionRepository(_context);
            PermissionTypes = new PermissionTypeRepository(_context);
        }

        public IPermissionRepository Permissions { get; }

        public IPermissionTypeRepository PermissionTypes { get; }

        public int JobDone()
        {
            return _context.SaveChanges();
        }

        public async Task<int> JobDoneAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}