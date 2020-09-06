using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class PoolHashProfile
        : AutoMapper.Profile
    {
        public PoolHashProfile()
        {
            CreateMap<Cardano.Data.Entities.PoolHash, Cardano.Domain.Models.PoolHashReadModel>();

            CreateMap<Cardano.Domain.Models.PoolHashCreateModel, Cardano.Data.Entities.PoolHash>();

            CreateMap<Cardano.Data.Entities.PoolHash, Cardano.Domain.Models.PoolHashUpdateModel>();

            CreateMap<Cardano.Domain.Models.PoolHashUpdateModel, Cardano.Data.Entities.PoolHash>();

            CreateMap<Cardano.Domain.Models.PoolHashReadModel, Cardano.Domain.Models.PoolHashUpdateModel>();

        }

    }
}
