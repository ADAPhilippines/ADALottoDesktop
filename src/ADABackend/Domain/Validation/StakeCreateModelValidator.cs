using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class StakeCreateModelValidator
        : AbstractValidator<StakeCreateModel>
    {
        public StakeCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
