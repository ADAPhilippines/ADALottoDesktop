using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class SchemaVersionExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.SchemaVersion GetByKey(this IQueryable<Cardano.Data.Entities.SchemaVersion> queryable, int id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.SchemaVersion> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.SchemaVersion> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.SchemaVersion> queryable, int id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.SchemaVersion> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.SchemaVersion>(task);
        }

        #endregion

    }
}
