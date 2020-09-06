using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class DelegationProfile
        : AutoMapper.Profile
    {
        public DelegationProfile()
        {
            CreateMap<Cardano.Data.Entities.Delegation, Cardano.Domain.Models.DelegationReadModel>();

            CreateMap<Cardano.Domain.Models.DelegationCreateModel, Cardano.Data.Entities.Delegation>();

            CreateMap<Cardano.Data.Entities.Delegation, Cardano.Domain.Models.DelegationUpdateModel>();

            CreateMap<Cardano.Domain.Models.DelegationUpdateModel, Cardano.Data.Entities.Delegation>();

            CreateMap<Cardano.Domain.Models.DelegationReadModel, Cardano.Domain.Models.DelegationUpdateModel>();

        }

    }
}
