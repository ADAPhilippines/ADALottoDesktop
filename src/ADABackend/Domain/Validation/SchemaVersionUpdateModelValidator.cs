using System;
using FluentValidation;
using Cardano.Domain.Models;

namespace Cardano.Domain.Validation
{
    public partial class SchemaVersionUpdateModelValidator
        : AbstractValidator<SchemaVersionUpdateModel>
    {
        public SchemaVersionUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
