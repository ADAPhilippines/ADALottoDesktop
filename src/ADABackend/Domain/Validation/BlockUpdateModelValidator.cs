using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class BlockUpdateModelValidator
        : AbstractValidator<BlockUpdateModel>
    {
        public BlockUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
