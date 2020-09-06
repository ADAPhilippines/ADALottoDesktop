using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class StakeRegistrationProfile
        : AutoMapper.Profile
    {
        public StakeRegistrationProfile()
        {
            CreateMap<Cardano.Data.Entities.StakeRegistration, Cardano.Domain.Models.StakeRegistrationReadModel>();

            CreateMap<Cardano.Domain.Models.StakeRegistrationCreateModel, Cardano.Data.Entities.StakeRegistration>();

            CreateMap<Cardano.Data.Entities.StakeRegistration, Cardano.Domain.Models.StakeRegistrationUpdateModel>();

            CreateMap<Cardano.Domain.Models.StakeRegistrationUpdateModel, Cardano.Data.Entities.StakeRegistration>();

            CreateMap<Cardano.Domain.Models.StakeRegistrationReadModel, Cardano.Domain.Models.StakeRegistrationUpdateModel>();

        }

    }
}
