using Core;

namespace Data
{
    public class PermissionTypeRepository : EntityRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(ApplicationCoreContext context) : base(context)
        {
        }

        public ApplicationCoreContext ApplicationCoreContext => Context as ApplicationCoreContext;
    }
}