using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class StakeProfile
        : AutoMapper.Profile
    {
        public StakeProfile()
        {
            CreateMap<Cardano.Data.Entities.Stake, Cardano.Domain.Models.StakeReadModel>();

            CreateMap<Cardano.Domain.Models.StakeCreateModel, Cardano.Data.Entities.Stake>();

            CreateMap<Cardano.Data.Entities.Stake, Cardano.Domain.Models.StakeUpdateModel>();

            CreateMap<Cardano.Domain.Models.StakeUpdateModel, Cardano.Data.Entities.Stake>();

            CreateMap<Cardano.Domain.Models.StakeReadModel, Cardano.Domain.Models.StakeUpdateModel>();

        }

    }
}
