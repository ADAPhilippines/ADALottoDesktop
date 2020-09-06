using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class SlotLeaderExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.SlotLeader GetByKey(this IQueryable<Cardano.Data.Entities.SlotLeader> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.SlotLeader> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.SlotLeader> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.SlotLeader> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.SlotLeader> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.SlotLeader>(task);
        }

        #endregion

    }
}
