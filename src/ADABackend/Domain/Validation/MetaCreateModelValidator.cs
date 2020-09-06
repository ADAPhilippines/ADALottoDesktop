using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class MetaCreateModelValidator
        : AbstractValidator<MetaCreateModel>
    {
        public MetaCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.NetworkName).NotEmpty();
            #endregion
        }

    }
}
