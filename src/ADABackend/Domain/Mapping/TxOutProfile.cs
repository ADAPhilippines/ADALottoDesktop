using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class TxOutProfile
        : AutoMapper.Profile
    {
        public TxOutProfile()
        {
            CreateMap<Cardano.Data.Entities.TxOut, Cardano.Domain.Models.TxOutReadModel>();

            CreateMap<Cardano.Domain.Models.TxOutCreateModel, Cardano.Data.Entities.TxOut>();

            CreateMap<Cardano.Data.Entities.TxOut, Cardano.Domain.Models.TxOutUpdateModel>();

            CreateMap<Cardano.Domain.Models.TxOutUpdateModel, Cardano.Data.Entities.TxOut>();

            CreateMap<Cardano.Domain.Models.TxOutReadModel, Cardano.Domain.Models.TxOutUpdateModel>();

        }

    }
}
