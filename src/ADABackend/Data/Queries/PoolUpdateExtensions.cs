using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class PoolUpdateExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.PoolUpdate> ByHashId(this IQueryable<Cardano.Data.Entities.PoolUpdate> queryable, long hashId)
        {
            return queryable.Where(q => q.HashId == hashId);
        }

        public static Cardano.Data.Entities.PoolUpdate GetByKey(this IQueryable<Cardano.Data.Entities.PoolUpdate> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolUpdate> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.PoolUpdate> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.PoolUpdate> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolUpdate> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.PoolUpdate>(task);
        }

        public static IQueryable<Cardano.Data.Entities.PoolUpdate> ByMeta(this IQueryable<Cardano.Data.Entities.PoolUpdate> queryable, long? meta)
        {
            return queryable.Where(q => (q.Meta == meta || (meta == null && q.Meta == null)));
        }

        public static IQueryable<Cardano.Data.Entities.PoolUpdate> ByRegisteredTxId(this IQueryable<Cardano.Data.Entities.PoolUpdate> queryable, long registeredTxId)
        {
            return queryable.Where(q => q.RegisteredTxId == registeredTxId);
        }

        public static IQueryable<Cardano.Data.Entities.PoolUpdate> ByRewardAddrId(this IQueryable<Cardano.Data.Entities.PoolUpdate> queryable, long rewardAddrId)
        {
            return queryable.Where(q => q.RewardAddrId == rewardAddrId);
        }

        #endregion

    }
}
