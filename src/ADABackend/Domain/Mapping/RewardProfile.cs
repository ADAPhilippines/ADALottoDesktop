using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class RewardProfile
        : AutoMapper.Profile
    {
        public RewardProfile()
        {
            CreateMap<Cardano.Data.Entities.Reward, Cardano.Domain.Models.RewardReadModel>();

            CreateMap<Cardano.Domain.Models.RewardCreateModel, Cardano.Data.Entities.Reward>();

            CreateMap<Cardano.Data.Entities.Reward, Cardano.Domain.Models.RewardUpdateModel>();

            CreateMap<Cardano.Domain.Models.RewardUpdateModel, Cardano.Data.Entities.Reward>();

            CreateMap<Cardano.Domain.Models.RewardReadModel, Cardano.Domain.Models.RewardUpdateModel>();

        }

    }
}
