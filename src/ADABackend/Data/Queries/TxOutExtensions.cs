using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardano.Data.Queries
{
    public static partial class TxOutExtensions
    {
        #region Generated Extensions
        public static IQueryable<Cardano.Data.Entities.TxOut> ByAddress(this IQueryable<Cardano.Data.Entities.TxOut> queryable, string address)
        {
            return queryable.Where(q => q.Address == address);
        }

        public static Cardano.Data.Entities.TxOut GetByKey(this IQueryable<Cardano.Data.Entities.TxOut> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.TxOut> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Cardano.Data.Entities.TxOut> GetByKeyAsync(this IQueryable<Cardano.Data.Entities.TxOut> queryable, long id)
        {
            if (queryable is DbSet<Cardano.Data.Entities.TxOut> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Cardano.Data.Entities.TxOut>(task);
        }

        public static IQueryable<Cardano.Data.Entities.TxOut> ByPaymentCred(this IQueryable<Cardano.Data.Entities.TxOut> queryable, Byte[] paymentCred)
        {
            return queryable.Where(q => (q.PaymentCred == paymentCred || (paymentCred == null && q.PaymentCred == null)));
        }

        public static IQueryable<Cardano.Data.Entities.TxOut> ByTxId(this IQueryable<Cardano.Data.Entities.TxOut> queryable, long txId)
        {
            return queryable.Where(q => q.TxId == txId);
        }

        #endregion

    }
}
