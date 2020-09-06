using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class MetaExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.Meta GetByKey(this IQueryable<Cardano.Data.Entities.Meta> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Meta> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Meta> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Meta> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Meta> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Meta>(task);
        }

        #endregion

    }
}
