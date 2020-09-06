using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class EpochExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.Epoch GetByKey(this IQueryable<Cardano.Data.Entities.Epoch> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Epoch> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Epoch> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Epoch> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Epoch> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Epoch>(task);
        }

        #endregion

    }
}
