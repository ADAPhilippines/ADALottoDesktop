using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class ReserveProfile
        : AutoMapper.Profile
    {
        public ReserveProfile()
        {
            CreateMap<Cardano.Data.Entities.Reserve, Cardano.Domain.Models.ReserveReadModel>();

            CreateMap<Cardano.Domain.Models.ReserveCreateModel, Cardano.Data.Entities.Reserve>();

            CreateMap<Cardano.Data.Entities.Reserve, Cardano.Domain.Models.ReserveUpdateModel>();

            CreateMap<Cardano.Domain.Models.ReserveUpdateModel, Cardano.Data.Entities.Reserve>();

            CreateMap<Cardano.Domain.Models.ReserveReadModel, Cardano.Domain.Models.ReserveUpdateModel>();

        }

    }
}
