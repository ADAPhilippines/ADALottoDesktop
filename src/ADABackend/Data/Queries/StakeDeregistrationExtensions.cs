using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class StakeDeregistrationExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.StakeDeregistration> ByAddrId(this IQueryable<Cardano.Data.Entities.StakeDeregistration> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.StakeDeregistration GetByKey(this IQueryable<Cardano.Data.Entities.StakeDeregistration> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.StakeDeregistration> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.StakeDeregistration> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.StakeDeregistration> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.StakeDeregistration> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.StakeDeregistration>(task);
        }

        public static IQueryable<Cardano.Data.Entities.StakeDeregistration> ByTxId(this IQueryable<Cardano.Data.Entities.StakeDeregistration> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
