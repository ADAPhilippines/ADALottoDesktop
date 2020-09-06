using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class EpochUpdateModelValidator
        : AbstractValidator<EpochUpdateModel>
    {
        public EpochUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
