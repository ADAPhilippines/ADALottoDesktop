using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class TxOutCreateModelValidator
        : AbstractValidator<TxOutCreateModel>
    {
        public TxOutCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Address).NotEmpty();
            #endregion
        }

    }
}
