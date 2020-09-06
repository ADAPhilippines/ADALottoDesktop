using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class SlotLeaderUpdateModelValidator
        : AbstractValidator<SlotLeaderUpdateModel>
    {
        public SlotLeaderUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Description).NotEmpty();
            #endregion
        }

    }
}
