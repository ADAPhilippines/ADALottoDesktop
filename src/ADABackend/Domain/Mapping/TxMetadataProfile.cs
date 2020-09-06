using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class TxMetadataProfile
        : AutoMapper.Profile
    {
        public TxMetadataProfile()
        {
            CreateMap<Cardano.Data.Entities.TxMetadata, Cardano.Domain.Models.TxMetadataReadModel>();

            CreateMap<Cardano.Domain.Models.TxMetadataCreateModel, Cardano.Data.Entities.TxMetadata>();

            CreateMap<Cardano.Data.Entities.TxMetadata, Cardano.Domain.Models.TxMetadataUpdateModel>();

            CreateMap<Cardano.Domain.Models.TxMetadataUpdateModel, Cardano.Data.Entities.TxMetadata>();

            CreateMap<Cardano.Domain.Models.TxMetadataReadModel, Cardano.Domain.Models.TxMetadataUpdateModel>();

        }

    }
}
