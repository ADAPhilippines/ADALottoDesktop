using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class StakeRegistrationExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.StakeRegistration> ByAddrId(this IQueryable<Cardano.Data.Entities.StakeRegistration> queryable, long addrId)
        {
            return queryable.Where(q => q.AddrId == addrId);
        }

        public static Cardano.Data.Entities.StakeRegistration GetByKey(this IQueryable<Cardano.Data.Entities.StakeRegistration> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.StakeRegistration> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.StakeRegistration> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.StakeRegistration> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.StakeRegistration> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.StakeRegistration>(task);
        }

        public static IQueryable<Cardano.Data.Entities.StakeRegistration> ByTxId(this IQueryable<Cardano.Data.Entities.StakeRegistration> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
