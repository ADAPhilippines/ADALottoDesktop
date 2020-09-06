using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class TxMetadataCreateModelValidator
        : AbstractValidator<TxMetadataCreateModel>
    {
        public TxMetadataCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Json).NotEmpty();
            #endregion
        }

    }
}
