using E_State.DataAccess.Abstract;
using E_State.DataAccess.Context;
using E_State.Entities.Entities;

namespace E_State.DataAccess.Concrete
{
    public class EfSituationRepository : GenericRepository<Situation, DataContext>, ISituaitonRepository
    {
        private DataContext context;
        public EfSituationRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public void FullDelete(Situation item)
        {
            var situation = context.Situations.Find(item.SituationId);
            context.Situations.Remove(situation);
            context.SaveChanges();
        }

        public void GetActive(Situation item)
        {
            var situation = context.Situations.Find(item.SituationId);

            if (situation.Status == false)
            {
                situation.Status = true;
                context.Situations.Update(situation);
                context.SaveChanges();
            }
        }
    }
}
