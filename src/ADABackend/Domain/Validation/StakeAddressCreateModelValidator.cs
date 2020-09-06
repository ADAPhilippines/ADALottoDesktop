using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class StakeAddressCreateModelValidator
        : AbstractValidator<StakeAddressCreateModel>
    {
        public StakeAddressCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.View).NotEmpty();
            #endregion
        }

    }
}
