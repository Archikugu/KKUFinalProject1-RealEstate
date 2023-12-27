using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfGeneralSettingsRepository : GenericRepository<GeneralSettings, DataContext>, IGeneralSettingsRepository
    {
        private DataContext context;
        public EfGeneralSettingsRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
