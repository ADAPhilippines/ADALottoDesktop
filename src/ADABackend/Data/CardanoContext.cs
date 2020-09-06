using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cardano.Data
{
    public partial class CardanoContext : DbContext
    {
        public CardanoContext(DbContextOptions<CardanoContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<Cardano.Data.Entities.Block> Blocks { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Delegation> Delegations { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Epoch> Epoches { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Meta> Meta { get; set; }

        public virtual DbSet<Cardano.Data.Entities.ParamUpdate> ParamUpdates { get; set; }

        public virtual DbSet<Cardano.Data.Entities.PoolHash> PoolHashes { get; set; }

        public virtual DbSet<Cardano.Data.Entities.PoolMetaData> PoolMetaData { get; set; }

        public virtual DbSet<Cardano.Data.Entities.PoolOwner> PoolOwners { get; set; }

        public virtual DbSet<Cardano.Data.Entities.PoolRelay> PoolRelays { get; set; }

        public virtual DbSet<Cardano.Data.Entities.PoolRetire> PoolRetires { get; set; }

        public virtual DbSet<Cardano.Data.Entities.PoolUpdate> PoolUpdates { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Reserve> Reserves { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Reward> Rewards { get; set; }

        public virtual DbSet<Cardano.Data.Entities.SchemaVersion> SchemaVersions { get; set; }

        public virtual DbSet<Cardano.Data.Entities.SlotLeader> SlotLeaders { get; set; }

        public virtual DbSet<Cardano.Data.Entities.StakeAddress> StakeAddresses { get; set; }

        public virtual DbSet<Cardano.Data.Entities.StakeDeregistration> StakeDeregistrations { get; set; }

        public virtual DbSet<Cardano.Data.Entities.StakeRegistration> StakeRegistrations { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Stake> Stakes { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Treasury> Treasuries { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Tx> Txes { get; set; }

        public virtual DbSet<Cardano.Data.Entities.TxIn> TxIns { get; set; }

        public virtual DbSet<Cardano.Data.Entities.TxMetadata> TxMetadata { get; set; }

        public virtual DbSet<Cardano.Data.Entities.TxOut> TxOuts { get; set; }

        public virtual DbSet<Cardano.Data.Entities.UtxoView> UtxoViews { get; set; }

        public virtual DbSet<Cardano.Data.Entities.Withdrawal> Withdrawals { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.BlockMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.DelegationMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.EpochMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.MetaMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.ParamUpdateMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.PoolHashMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.PoolMetaDataMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.PoolOwnerMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.PoolRelayMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.PoolRetireMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.PoolUpdateMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.ReserveMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.RewardMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.SchemaVersionMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.SlotLeaderMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.StakeAddressMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.StakeDeregistrationMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.StakeMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.StakeRegistrationMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.TreasuryMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.TxInMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.TxMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.TxMetadataMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.TxOutMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.UtxoViewMap());
            modelBuilder.ApplyConfiguration(new Cardano.Data.Mapping.WithdrawalMap());
            #endregion
        }
    }
}
