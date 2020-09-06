using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class TxMetadataExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.TxMetadata GetByKey(this IQueryable<Cardano.Data.Entities.TxMetadata> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.TxMetadata> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.TxMetadata> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.TxMetadata> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.TxMetadata> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.TxMetadata>(task);
        }

        public static IQueryable<Cardano.Data.Entities.TxMetadata> ByTxId(this IQueryable<Cardano.Data.Entities.TxMetadata> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
