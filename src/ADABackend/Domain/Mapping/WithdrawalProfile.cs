using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class WithdrawalProfile
        : AutoMapper.Profile
    {
        public WithdrawalProfile()
        {
            CreateMap<Cardano.Data.Entities.Withdrawal, Cardano.Domain.Models.WithdrawalReadModel>();

            CreateMap<Cardano.Domain.Models.WithdrawalCreateModel, Cardano.Data.Entities.Withdrawal>();

            CreateMap<Cardano.Data.Entities.Withdrawal, Cardano.Domain.Models.WithdrawalUpdateModel>();

            CreateMap<Cardano.Domain.Models.WithdrawalUpdateModel, Cardano.Data.Entities.Withdrawal>();

            CreateMap<Cardano.Domain.Models.WithdrawalReadModel, Cardano.Domain.Models.WithdrawalUpdateModel>();

        }

    }
}
