using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class PoolRetireProfile
        : AutoMapper.Profile
    {
        public PoolRetireProfile()
        {
            CreateMap<Cardano.Data.Entities.PoolRetire, Cardano.Domain.Models.PoolRetireReadModel>();

            CreateMap<Cardano.Domain.Models.PoolRetireCreateModel, Cardano.Data.Entities.PoolRetire>();

            CreateMap<Cardano.Data.Entities.PoolRetire, Cardano.Domain.Models.PoolRetireUpdateModel>();

            CreateMap<Cardano.Domain.Models.PoolRetireUpdateModel, Cardano.Data.Entities.PoolRetire>();

            CreateMap<Cardano.Domain.Models.PoolRetireReadModel, Cardano.Domain.Models.PoolRetireUpdateModel>();

        }

    }
}
