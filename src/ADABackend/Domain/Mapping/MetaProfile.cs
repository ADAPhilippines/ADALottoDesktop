using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class MetaProfile
        : AutoMapper.Profile
    {
        public MetaProfile()
        {
            CreateMap<Cardano.Data.Entities.Meta, Cardano.Domain.Models.MetaReadModel>();

            CreateMap<Cardano.Domain.Models.MetaCreateModel, Cardano.Data.Entities.Meta>();

            CreateMap<Cardano.Data.Entities.Meta, Cardano.Domain.Models.MetaUpdateModel>();

            CreateMap<Cardano.Domain.Models.MetaUpdateModel, Cardano.Data.Entities.Meta>();

            CreateMap<Cardano.Domain.Models.MetaReadModel, Cardano.Domain.Models.MetaUpdateModel>();

        }

    }
}
