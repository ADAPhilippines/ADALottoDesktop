using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class PoolRelayProfile
        : AutoMapper.Profile
    {
        public PoolRelayProfile()
        {
            CreateMap<Cardano.Data.Entities.PoolRelay, Cardano.Domain.Models.PoolRelayReadModel>();

            CreateMap<Cardano.Domain.Models.PoolRelayCreateModel, Cardano.Data.Entities.PoolRelay>();

            CreateMap<Cardano.Data.Entities.PoolRelay, Cardano.Domain.Models.PoolRelayUpdateModel>();

            CreateMap<Cardano.Domain.Models.PoolRelayUpdateModel, Cardano.Data.Entities.PoolRelay>();

            CreateMap<Cardano.Domain.Models.PoolRelayReadModel, Cardano.Domain.Models.PoolRelayUpdateModel>();

        }

    }
}
