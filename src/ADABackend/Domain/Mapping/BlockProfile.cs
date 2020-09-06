using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class BlockProfile
        : AutoMapper.Profile
    {
        public BlockProfile()
        {
            CreateMap<Cardano.Data.Entities.Block, Cardano.Domain.Models.BlockReadModel>();

            CreateMap<Cardano.Domain.Models.BlockCreateModel, Cardano.Data.Entities.Block>();

            CreateMap<Cardano.Data.Entities.Block, Cardano.Domain.Models.BlockUpdateModel>();

            CreateMap<Cardano.Domain.Models.BlockUpdateModel, Cardano.Data.Entities.Block>();

            CreateMap<Cardano.Domain.Models.BlockReadModel, Cardano.Domain.Models.BlockUpdateModel>();

        }

    }
}
