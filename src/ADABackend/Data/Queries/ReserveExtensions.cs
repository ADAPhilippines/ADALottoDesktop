using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class ReserveExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Reserve> ByAddrId(this IQueryable<Cardano.Data.Entities.Reserve> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.Reserve GetByKey(this IQueryable<Cardano.Data.Entities.Reserve> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Reserve> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Reserve> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Reserve> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Reserve> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Reserve>(task);
        }

        public static IQueryable<Cardano.Data.Entities.Reserve> ByTxId(this IQueryable<Cardano.Data.Entities.Reserve> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
