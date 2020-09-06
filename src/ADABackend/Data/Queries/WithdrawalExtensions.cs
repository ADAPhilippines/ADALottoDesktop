using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class WithdrawalExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Withdrawal> ByAddrId(this IQueryable<Cardano.Data.Entities.Withdrawal> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.Withdrawal GetByKey(this IQueryable<Cardano.Data.Entities.Withdrawal> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Withdrawal> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Withdrawal> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Withdrawal> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Withdrawal> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Withdrawal>(task);
        }

        public static IQueryable<Cardano.Data.Entities.Withdrawal> ByTxId(this IQueryable<Cardano.Data.Entities.Withdrawal> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
