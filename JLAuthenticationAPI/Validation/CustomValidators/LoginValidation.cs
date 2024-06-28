using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLAuthenticationAPI.Validation.CustomValidators
{
    internal class LoginValidation : IValidator
    {
        public bool ValidateField(int fieldTypeIndex, string fieldValue, string[] fields, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
