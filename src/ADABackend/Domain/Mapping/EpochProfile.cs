using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class EpochProfile
        : AutoMapper.Profile
    {
        public EpochProfile()
        {
            CreateMap<Cardano.Data.Entities.Epoch, Cardano.Domain.Models.EpochReadModel>();

            CreateMap<Cardano.Domain.Models.EpochCreateModel, Cardano.Data.Entities.Epoch>();

            CreateMap<Cardano.Data.Entities.Epoch, Cardano.Domain.Models.EpochUpdateModel>();

            CreateMap<Cardano.Domain.Models.EpochUpdateModel, Cardano.Data.Entities.Epoch>();

            CreateMap<Cardano.Domain.Models.EpochReadModel, Cardano.Domain.Models.EpochUpdateModel>();

        }

    }
}
