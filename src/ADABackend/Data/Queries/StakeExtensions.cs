using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class StakeExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Stake> ByAddrId(this IQueryable<Cardano.Data.Entities.Stake> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.Stake GetByKey(this IQueryable<Cardano.Data.Entities.Stake> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Stake> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Stake> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Stake> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Stake> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Stake>(task);
        }

        public static IQueryable<Cardano.Data.Entities.Stake> ByTxId(this IQueryable<Cardano.Data.Entities.Stake> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
