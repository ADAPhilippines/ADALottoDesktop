using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class StakeAddressExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.StakeAddress GetByKey(this IQueryable<Cardano.Data.Entities.StakeAddress> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.StakeAddress> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.StakeAddress> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.StakeAddress> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.StakeAddress> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.StakeAddress>(task);
        }

        public static IQueryable<Cardano.Data.Entities.StakeAddress> ByRegisteredTxId(this IQueryable<Cardano.Data.Entities.StakeAddress> queryable, long registeredTxId)
        {
            return queryable.Where(q => q.RegisteredTxId == registeredTxId);
        }

        #endregion

    }
}
