using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class PoolMetaDataUpdateModelValidator
        : AbstractValidator<PoolMetaDataUpdateModel>
    {
        public PoolMetaDataUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Url).NotEmpty();
            #endregion
        }

    }
}
