using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class TxProfile
        : AutoMapper.Profile
    {
        public TxProfile()
        {
            CreateMap<Cardano.Data.Entities.Tx, Cardano.Domain.Models.TxReadModel>();

            CreateMap<Cardano.Domain.Models.TxCreateModel, Cardano.Data.Entities.Tx>();

            CreateMap<Cardano.Data.Entities.Tx, Cardano.Domain.Models.TxUpdateModel>();

            CreateMap<Cardano.Domain.Models.TxUpdateModel, Cardano.Data.Entities.Tx>();

            CreateMap<Cardano.Domain.Models.TxReadModel, Cardano.Domain.Models.TxUpdateModel>();

        }

    }
}
