using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class PoolUpdateProfile
        : AutoMapper.Profile
    {
        public PoolUpdateProfile()
        {
            CreateMap<Cardano.Data.Entities.PoolUpdate, Cardano.Domain.Models.PoolUpdateReadModel>();

            CreateMap<Cardano.Domain.Models.PoolUpdateCreateModel, Cardano.Data.Entities.PoolUpdate>();

            CreateMap<Cardano.Data.Entities.PoolUpdate, Cardano.Domain.Models.PoolUpdateUpdateModel>();

            CreateMap<Cardano.Domain.Models.PoolUpdateUpdateModel, Cardano.Data.Entities.PoolUpdate>();

            CreateMap<Cardano.Domain.Models.PoolUpdateReadModel, Cardano.Domain.Models.PoolUpdateUpdateModel>();

        }

    }
}
