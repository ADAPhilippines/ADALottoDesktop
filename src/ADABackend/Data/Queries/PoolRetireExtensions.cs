using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class PoolRetireExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.PoolRetire> ByAnnouncedTxId(this IQueryable<Cardano.Data.Entities.PoolRetire> queryable, long announcedTxId)
        {
            return queryable.Where(q => q.AnnouncedTxId == announcedTxId);
        }

        public static IQueryable<Cardano.Data.Entities.PoolRetire> ByHashId(this IQueryable<Cardano.Data.Entities.PoolRetire> queryable, long hashId)
        {
            return queryable.Where(q => q.HashId == hashId);
        }

        public static Cardano.Data.Entities.PoolRetire GetByKey(this IQueryable<Cardano.Data.Entities.PoolRetire> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolRetire> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.PoolRetire> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.PoolRetire> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.PoolRetire> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.PoolRetire>(task);
        }

        #endregion

    }
}
