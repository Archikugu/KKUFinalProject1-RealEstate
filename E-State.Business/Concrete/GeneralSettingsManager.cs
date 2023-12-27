using E_State.Business.Abstract;
using E_State.DataAccess.Abstract;
using E_State.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Business.Concrete
{
    public class GeneralSettingsManager : IGeneralSettingsService
    {
        IGeneralSettingsRepository _generalSettingsRepository;

        public GeneralSettingsManager(IGeneralSettingsRepository generalSettingsRepository)
        {
            _generalSettingsRepository = generalSettingsRepository;
        }

        public void Add(GeneralSettings item)
        {
            _generalSettingsRepository.Add(item);
        }

        public void Delete(GeneralSettings item)
        {
            _generalSettingsRepository?.Delete(item);
        }

        public GeneralSettings GetById(int id)
        {
            return _generalSettingsRepository.GetById(id);
        }

        public List<GeneralSettings> List()
        {
            return _generalSettingsRepository.List();
        }

        public List<GeneralSettings> List(Expression<Func<GeneralSettings, bool>> filter)
        {
            return _generalSettingsRepository.List(filter);
        }

        public void Update(GeneralSettings item)
        {
            _generalSettingsRepository.Update(item);
        }
    }
}
