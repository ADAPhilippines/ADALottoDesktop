using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class BlockExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.Block> ByBlockNo(this IQueryable<Cardano.Data.Entities.Block> queryable, int? blockNo)
        {
            return queryable.Where(q => (q.BlockNo == blockNo || (blockNo == null && q.BlockNo == null)));
        }

        public static IQueryable<Cardano.Data.Entities.Block> ByEpochNo(this IQueryable<Cardano.Data.Entities.Block> queryable, int? epochNo)
        {
            return queryable.Where(q => (q.EpochNo == epochNo || (epochNo == null && q.EpochNo == null)));
        }

        public static IQueryable<Cardano.Data.Entities.Block> ByHash(this IQueryable<Cardano.Data.Entities.Block> queryable, Byte[] hash)
        {
            return queryable.Where(q => q.Hash == hash);
        }

        public static Cardano.Data.Entities.Block GetByKey(this IQueryable<Cardano.Data.Entities.Block> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Block> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.Block> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.Block> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.Block> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.Block>(task);
        }

        public static IQueryable<Cardano.Data.Entities.Block> ByPrevious(this IQueryable<Cardano.Data.Entities.Block> queryable, long? previous)
        {
            return queryable.Where(q => (q.Previous == previous || (previous == null && q.Previous == null)));
        }

        public static IQueryable<Cardano.Data.Entities.Block> BySlotLeader(this IQueryable<Cardano.Data.Entities.Block> queryable, long slotLeader)
        {
            return queryable.Where(q => q.SlotLeader == slotLeader);
        }

        public static IQueryable<Cardano.Data.Entities.Block> BySlotNo(this IQueryable<Cardano.Data.Entities.Block> queryable, int? slotNo)
        {
            return queryable.Where(q => (q.SlotNo == slotNo || (slotNo == null && q.SlotNo == null)));
        }

        public static IQueryable<Cardano.Data.Entities.Block> ByTime(this IQueryable<Cardano.Data.Entities.Block> queryable, DateTime time)
        {
            return queryable.Where(q => q.Time == time);
        }

        #endregion

    }
}
