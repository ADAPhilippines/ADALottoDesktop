using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class TxCreateModelValidator
        : AbstractValidator<TxCreateModel>
    {
        public TxCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
