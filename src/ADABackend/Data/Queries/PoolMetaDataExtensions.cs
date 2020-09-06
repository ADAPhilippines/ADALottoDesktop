using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class PoolMetaDataExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.PoolMetaData GetByKey(this IQueryable<Cardano.Data.Entities.PoolMetaData> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolMetaData> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.PoolMetaData> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.PoolMetaData> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolMetaData> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.PoolMetaData>(task);
        }

        public static IQueryable<Cardano.Data.Entities.PoolMetaData> ByRegisteredTxId(this IQueryable<Cardano.Data.Entities.PoolMetaData> queryable, long registeredTxId)
        {
            return queryable.Where(q => q.RegisteredTxId == registeredTxId);
        }

        #endregion

    }
}
