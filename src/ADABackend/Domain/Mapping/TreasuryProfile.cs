using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class TreasuryProfile
        : AutoMapper.Profile
    {
        public TreasuryProfile()
        {
            CreateMap<Cardano.Data.Entities.Treasury, Cardano.Domain.Models.TreasuryReadModel>();

            CreateMap<Cardano.Domain.Models.TreasuryCreateModel, Cardano.Data.Entities.Treasury>();

            CreateMap<Cardano.Data.Entities.Treasury, Cardano.Domain.Models.TreasuryUpdateModel>();

            CreateMap<Cardano.Domain.Models.TreasuryUpdateModel, Cardano.Data.Entities.Treasury>();

            CreateMap<Cardano.Domain.Models.TreasuryReadModel, Cardano.Domain.Models.TreasuryUpdateModel>();

        }

    }
}
