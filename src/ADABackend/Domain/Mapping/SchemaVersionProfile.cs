using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class SchemaVersionProfile
        : AutoMapper.Profile
    {
        public SchemaVersionProfile()
        {
            CreateMap<Cardano.Data.Entities.SchemaVersion, Cardano.Domain.Models.SchemaVersionReadModel>();

            CreateMap<Cardano.Domain.Models.SchemaVersionCreateModel, Cardano.Data.Entities.SchemaVersion>();

            CreateMap<Cardano.Data.Entities.SchemaVersion, Cardano.Domain.Models.SchemaVersionUpdateModel>();

            CreateMap<Cardano.Domain.Models.SchemaVersionUpdateModel, Cardano.Data.Entities.SchemaVersion>();

            CreateMap<Cardano.Domain.Models.SchemaVersionReadModel, Cardano.Domain.Models.SchemaVersionUpdateModel>();

        }

    }
}
