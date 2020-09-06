using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class DelegationExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Delegation> ByAddrId(this IQueryable<Cardano.Data.Entities.Delegation> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.Delegation GetByKey(this IQueryable<Cardano.Data.Entities.Delegation> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Delegation> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Delegation> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Delegation> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Delegation> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Delegation>(task);
        }

        public static IQueryable<Cardano.Data.Entities.Delegation> ByPoolHashId(this IQueryable<Cardano.Data.Entities.Delegation> queryable, long poolHashId)
        {
            return queryable.Where(q => q.PoolHashId == poolHashId);
        }

        public static IQueryable<Cardano.Data.Entities.Delegation> ByTxId(this IQueryable<Cardano.Data.Entities.Delegation> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
