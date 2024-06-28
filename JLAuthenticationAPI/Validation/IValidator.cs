using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLAuthenticationAPI.Validation
{

    delegate bool FieldValidator(int fieldTypeIndex, string fieldValue, string[] fields, out string errorMessage);
    internal interface IValidator
    {
        bool ValidateField(int fieldTypeIndex, string fieldValue, string[] fields, out string errorMessage);
    }
}
