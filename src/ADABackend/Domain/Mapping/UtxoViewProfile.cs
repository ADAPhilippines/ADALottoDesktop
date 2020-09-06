using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class UtxoViewProfile
        : AutoMapper.Profile
    {
        public UtxoViewProfile()
        {
            CreateMap<Cardano.Data.Entities.UtxoView, Cardano.Domain.Models.UtxoViewReadModel>();

            CreateMap<Cardano.Domain.Models.UtxoViewCreateModel, Cardano.Data.Entities.UtxoView>();

            CreateMap<Cardano.Data.Entities.UtxoView, Cardano.Domain.Models.UtxoViewUpdateModel>();

            CreateMap<Cardano.Domain.Models.UtxoViewUpdateModel, Cardano.Data.Entities.UtxoView>();

            CreateMap<Cardano.Domain.Models.UtxoViewReadModel, Cardano.Domain.Models.UtxoViewUpdateModel>();

        }

    }
}
