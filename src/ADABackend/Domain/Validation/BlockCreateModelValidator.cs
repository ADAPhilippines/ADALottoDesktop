using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class BlockCreateModelValidator
        : AbstractValidator<BlockCreateModel>
    {
        public BlockCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
