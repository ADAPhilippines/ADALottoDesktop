using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class SlotLeaderCreateModelValidator
        : AbstractValidator<SlotLeaderCreateModel>
    {
        public SlotLeaderCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Description).NotEmpty();
            #endregion
        }

    }
}
