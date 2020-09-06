using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class TxInProfile
        : AutoMapper.Profile
    {
        public TxInProfile()
        {
            CreateMap<Cardano.Data.Entities.TxIn, Cardano.Domain.Models.TxInReadModel>();

            CreateMap<Cardano.Domain.Models.TxInCreateModel, Cardano.Data.Entities.TxIn>();

            CreateMap<Cardano.Data.Entities.TxIn, Cardano.Domain.Models.TxInUpdateModel>();

            CreateMap<Cardano.Domain.Models.TxInUpdateModel, Cardano.Data.Entities.TxIn>();

            CreateMap<Cardano.Domain.Models.TxInReadModel, Cardano.Domain.Models.TxInUpdateModel>();

        }

    }
}
