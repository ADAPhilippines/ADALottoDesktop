using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class EpochCreateModelValidator
        : AbstractValidator<EpochCreateModel>
    {
        public EpochCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
