using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class TxOutUpdateModelValidator
        : AbstractValidator<TxOutUpdateModel>
    {
        public TxOutUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Address).NotEmpty();
            #endregion
        }

    }
}
