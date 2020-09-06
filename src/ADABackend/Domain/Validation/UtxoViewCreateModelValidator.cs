using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class UtxoViewCreateModelValidator
        : AbstractValidator<UtxoViewCreateModel>
    {
        public UtxoViewCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
