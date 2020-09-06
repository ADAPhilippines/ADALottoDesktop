using System;
using AutoMapper;
using Cardano.Data.Entities;
using Cardano.Domain.Models;

namespace Cardano.Domain.Mapping
{
    public partial class ParamUpdateProfile
        : AutoMapper.Profile
    {
        public ParamUpdateProfile()
        {
            CreateMap<Cardano.Data.Entities.ParamUpdate, Cardano.Domain.Models.ParamUpdateReadModel>();

            CreateMap<Cardano.Domain.Models.ParamUpdateCreateModel, Cardano.Data.Entities.ParamUpdate>();

            CreateMap<Cardano.Data.Entities.ParamUpdate, Cardano.Domain.Models.ParamUpdateUpdateModel>();

            CreateMap<Cardano.Domain.Models.ParamUpdateUpdateModel, Cardano.Data.Entities.ParamUpdate>();

            CreateMap<Cardano.Domain.Models.ParamUpdateReadModel, Cardano.Domain.Models.ParamUpdateUpdateModel>();

        }

    }
}
