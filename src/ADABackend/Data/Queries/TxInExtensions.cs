using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class TxInExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.TxIn GetByKey(this IQueryable<Cardano.Data.Entities.TxIn> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.TxIn> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.TxIn> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.TxIn> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.TxIn> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.TxIn>(task);
        }

        public static IQueryable<Cardano.Data.Entities.TxIn> ByTxInId(this IQueryable<Cardano.Data.Entities.TxIn> queryable, long txInId)
        {
            return queryable.Where(q => q.TxInId == txInId);
        }

        public static IQueryable<Cardano.Data.Entities.TxIn> ByTxOutId(this IQueryable<Cardano.Data.Entities.TxIn> queryable, long txOutId)
        {
            return queryable.Where(q => q.TxOutId == txOutId);
        }

        #endregion

    }
}
