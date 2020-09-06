using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class PoolRelayExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.PoolRelay GetByKey(this IQueryable<Cardano.Data.Entities.PoolRelay> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolRelay> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.PoolRelay> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.PoolRelay> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolRelay> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.PoolRelay>(task);
        }

        public static IQueryable<Cardano.Data.Entities.PoolRelay> ByUpdateId(this IQueryable<Cardano.Data.Entities.PoolRelay> queryable, long updateId)
        {
            return queryable.Where(q => q.UpdateId == updateId);
        }

        #endregion

    }
}
