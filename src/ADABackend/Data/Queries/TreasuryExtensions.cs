using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class TreasuryExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Treasury> ByAddrId(this IQueryable<Cardano.Data.Entities.Treasury> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.Treasury GetByKey(this IQueryable<Cardano.Data.Entities.Treasury> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Treasury> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Treasury> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Treasury> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Treasury> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Treasury>(task);
        }

        public static IQueryable<Cardano.Data.Entities.Treasury> ByTxId(this IQueryable<Cardano.Data.Entities.Treasury> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
