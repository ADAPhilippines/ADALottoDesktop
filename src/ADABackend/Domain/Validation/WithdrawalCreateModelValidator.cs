using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class WithdrawalCreateModelValidator
        : AbstractValidator<WithdrawalCreateModel>
    {
        public WithdrawalCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
