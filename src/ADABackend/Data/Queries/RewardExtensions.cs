using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class RewardExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Reward> ByAddrId(this IQueryable<Cardano.Data.Entities.Reward> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.Reward GetByKey(this IQueryable<Cardano.Data.Entities.Reward> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Reward> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Reward> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Reward> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Reward> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Reward>(task);
        }

        public static IQueryable<Cardano.Data.Entities.Reward> ByTxId(this IQueryable<Cardano.Data.Entities.Reward> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
