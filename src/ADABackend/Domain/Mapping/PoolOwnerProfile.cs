using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class PoolOwnerProfile
        : AutoMapper.Profile
    {
        public PoolOwnerProfile()
        {
            CreateMap<Cardano.Data.Entities.PoolOwner, Cardano.Domain.Models.PoolOwnerReadModel>();

            CreateMap<Cardano.Domain.Models.PoolOwnerCreateModel, Cardano.Data.Entities.PoolOwner>();

            CreateMap<Cardano.Data.Entities.PoolOwner, Cardano.Domain.Models.PoolOwnerUpdateModel>();

            CreateMap<Cardano.Domain.Models.PoolOwnerUpdateModel, Cardano.Data.Entities.PoolOwner>();

            CreateMap<Cardano.Domain.Models.PoolOwnerReadModel, Cardano.Domain.Models.PoolOwnerUpdateModel>();

        }

    }
}
