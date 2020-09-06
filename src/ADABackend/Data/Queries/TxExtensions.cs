using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class TxExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Tx> ByBlock(this IQueryable<Cardano.Data.Entities.Tx> queryable, long block)
        {
            return queryable.Where(q => q.Block == block);
        }

        public static IQueryable<Cardano.Data.Entities.Tx> ByHash(this IQueryable<Cardano.Data.Entities.Tx> queryable, Byte[] hash)
        {
            return queryable.Where(q => q.Hash == hash);
        }

        public static Cardano.Data.Entities.Tx GetByKey(this IQueryable<Cardano.Data.Entities.Tx> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Tx> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Tx> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Tx> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Tx> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Tx>(task);
        }

        #endregion

    }
}
