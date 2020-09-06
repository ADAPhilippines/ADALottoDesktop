using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class ParamUpdateExtensions
    {
        #region Generated Extensions
        public static Cardano.Data.Entities.ParamUpdate GetByKey(this IQueryable<Cardano.Data.Entities.ParamUpdate> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.ParamUpdate> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.ParamUpdate> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.ParamUpdate> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.ParamUpdate> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.ParamUpdate>(task);
        }

        public static IQueryable<Cardano.Data.Entities.ParamUpdate> ByRegisteredTxId(this IQueryable<Cardano.Data.Entities.ParamUpdate> queryable, long registeredTxId)
        {
            return queryable.Where(q => q.RegisteredTxId == registeredTxId);
        }

        #endregion

    }
}
