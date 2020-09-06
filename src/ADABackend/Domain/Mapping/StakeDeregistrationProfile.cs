using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class StakeDeregistrationProfile
        : AutoMapper.Profile
    {
        public StakeDeregistrationProfile()
        {
            CreateMap<Cardano.Data.Entities.StakeDeregistration, Cardano.Domain.Models.StakeDeregistrationReadModel>();

            CreateMap<Cardano.Domain.Models.StakeDeregistrationCreateModel, Cardano.Data.Entities.StakeDeregistration>();

            CreateMap<Cardano.Data.Entities.StakeDeregistration, Cardano.Domain.Models.StakeDeregistrationUpdateModel>();

            CreateMap<Cardano.Domain.Models.StakeDeregistrationUpdateModel, Cardano.Data.Entities.StakeDeregistration>();

            CreateMap<Cardano.Domain.Models.StakeDeregistrationReadModel, Cardano.Domain.Models.StakeDeregistrationUpdateModel>();

        }

    }
}
