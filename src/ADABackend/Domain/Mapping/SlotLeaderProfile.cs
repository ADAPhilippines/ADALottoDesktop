using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class SlotLeaderProfile
        : AutoMapper.Profile
    {
        public SlotLeaderProfile()
        {
            CreateMap<Cardano.Data.Entities.SlotLeader, Cardano.Domain.Models.SlotLeaderReadModel>();

            CreateMap<Cardano.Domain.Models.SlotLeaderCreateModel, Cardano.Data.Entities.SlotLeader>();

            CreateMap<Cardano.Data.Entities.SlotLeader, Cardano.Domain.Models.SlotLeaderUpdateModel>();

            CreateMap<Cardano.Domain.Models.SlotLeaderUpdateModel, Cardano.Data.Entities.SlotLeader>();

            CreateMap<Cardano.Domain.Models.SlotLeaderReadModel, Cardano.Domain.Models.SlotLeaderUpdateModel>();

        }

    }
}
