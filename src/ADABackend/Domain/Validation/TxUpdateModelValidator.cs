using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class TxUpdateModelValidator
        : AbstractValidator<TxUpdateModel>
    {
        public TxUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
