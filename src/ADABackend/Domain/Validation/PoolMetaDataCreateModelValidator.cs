using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class PoolMetaDataCreateModelValidator
        : AbstractValidator<PoolMetaDataCreateModel>
    {
        public PoolMetaDataCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Url).NotEmpty();
            #endregion
        }

    }
}
