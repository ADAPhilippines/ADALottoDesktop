using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class PoolOwnerExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.PoolOwner GetByKey(this IQueryable<Cardano.Data.Entities.PoolOwner> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolOwner> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.PoolOwner> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.PoolOwner> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolOwner> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.PoolOwner>(task);
        }

        public static IQueryable<Cardano.Data.Entities.PoolOwner> ByPoolHashId(this IQueryable<Cardano.Data.Entities.PoolOwner> queryable, long poolHashId)
        {
            return queryable.Where(q => q.PoolHashId == poolHashId);
        }

        #endregion

    }
}
