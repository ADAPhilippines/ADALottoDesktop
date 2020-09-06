using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class StakeAddressUpdateModelValidator
        : AbstractValidator<StakeAddressUpdateModel>
    {
        public StakeAddressUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.View).NotEmpty();
            #endregion
        }

    }
}
