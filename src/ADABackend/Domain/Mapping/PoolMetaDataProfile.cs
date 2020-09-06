using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class PoolMetaDataProfile
        : AutoMapper.Profile
    {
        public PoolMetaDataProfile()
        {
            CreateMap<Cardano.Data.Entities.PoolMetaData, Cardano.Domain.Models.PoolMetaDataReadModel>();

            CreateMap<Cardano.Domain.Models.PoolMetaDataCreateModel, Cardano.Data.Entities.PoolMetaData>();

            CreateMap<Cardano.Data.Entities.PoolMetaData, Cardano.Domain.Models.PoolMetaDataUpdateModel>();

            CreateMap<Cardano.Domain.Models.PoolMetaDataUpdateModel, Cardano.Data.Entities.PoolMetaData>();

            CreateMap<Cardano.Domain.Models.PoolMetaDataReadModel, Cardano.Domain.Models.PoolMetaDataUpdateModel>();

        }

    }
}
