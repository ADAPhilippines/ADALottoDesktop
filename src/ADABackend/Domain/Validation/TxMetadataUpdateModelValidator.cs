using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class TxMetadataUpdateModelValidator
        : AbstractValidator<TxMetadataUpdateModel>
    {
        public TxMetadataUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Json).NotEmpty();
            #endregion
        }

    }
}
