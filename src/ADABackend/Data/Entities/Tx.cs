using System;
using System.Collections.Generic;

namespace Cardano.Data.Entities
{
    public partial class Tx
    {
        public Tx()
        {
            #region Generated Constructor
            AnnouncedPoolRetires = new HashSet<PoolRetire>();
            Delegations = new HashSet<Delegation>();
            InTxIns = new HashSet<TxIn>();
            OutTxIns = new HashSet<TxIn>();
            RegisteredParamUpdates = new HashSet<ParamUpdate>();
            RegisteredPoolMetaData = new HashSet<PoolMetaData>();
            RegisteredPoolUpdates = new HashSet<PoolUpdate>();
            RegisteredStakeAddresses = new HashSet<StakeAddress>();
            Reserves = new HashSet<Reserve>();
            Rewards = new HashSet<Reward>();
            StakeDeregistrations = new HashSet<StakeDeregistration>();
            StakeRegistrations = new HashSet<StakeRegistration>();
            Stakes = new HashSet<Stake>();
            Treasuries = new HashSet<Treasury>();
            TxMetadata = new HashSet<TxMetadata>();
            TxOuts = new HashSet<TxOut>();
            Withdrawals = new HashSet<Withdrawal>();
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public Byte[] Hash { get; set; }

        public long Block { get; set; }

        public int BlockIndex { get; set; }

        public long OutSum { get; set; }

        public long Fee { get; set; }

        public int Size { get; set; }

        public long Deposit { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<PoolRetire> AnnouncedPoolRetires { get; set; }

        public virtual Block Block1 { get; set; }

        public virtual ICollection<Delegation> Delegations { get; set; }

        public virtual ICollection<TxIn> InTxIns { get; set; }

        public virtual ICollection<TxIn> OutTxIns { get; set; }

        public virtual ICollection<ParamUpdate> RegisteredParamUpdates { get; set; }

        public virtual ICollection<PoolMetaData> RegisteredPoolMetaData { get; set; }

        public virtual ICollection<PoolUpdate> RegisteredPoolUpdates { get; set; }

        public virtual ICollection<StakeAddress> RegisteredStakeAddresses { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }

        public virtual ICollection<Reward> Rewards { get; set; }

        public virtual ICollection<StakeDeregistration> StakeDeregistrations { get; set; }

        public virtual ICollection<StakeRegistration> StakeRegistrations { get; set; }

        public virtual ICollection<Stake> Stakes { get; set; }

        public virtual ICollection<Treasury> Treasuries { get; set; }

        public virtual ICollection<TxMetadata> TxMetadata { get; set; }

        public virtual ICollection<TxOut> TxOuts { get; set; }

        public virtual ICollection<Withdrawal> Withdrawals { get; set; }

        #endregion

    }
}
