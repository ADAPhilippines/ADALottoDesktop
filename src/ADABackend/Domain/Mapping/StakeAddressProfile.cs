using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class StakeAddressProfile
        : AutoMapper.Profile
    {
        public StakeAddressProfile()
        {
            CreateMap<Cardano.Data.Entities.StakeAddress, Cardano.Domain.Models.StakeAddressReadModel>();

            CreateMap<Cardano.Domain.Models.StakeAddressCreateModel, Cardano.Data.Entities.StakeAddress>();

            CreateMap<Cardano.Data.Entities.StakeAddress, Cardano.Domain.Models.StakeAddressUpdateModel>();

            CreateMap<Cardano.Domain.Models.StakeAddressUpdateModel, Cardano.Data.Entities.StakeAddress>();

            CreateMap<Cardano.Domain.Models.StakeAddressReadModel, Cardano.Domain.Models.StakeAddressUpdateModel>();

        }

    }
}
