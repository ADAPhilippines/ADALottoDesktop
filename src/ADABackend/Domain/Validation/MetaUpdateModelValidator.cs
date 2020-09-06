using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class MetaUpdateModelValidator
        : AbstractValidator<MetaUpdateModel>
    {
        public MetaUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.NetworkName).NotEmpty();
            #endregion
        }

    }
}
