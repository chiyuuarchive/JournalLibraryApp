using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLAuthenticationAPI
{

    public delegate bool FieldValidator(string[] fields, out string errorMessage);
    public interface IValidator
    {
        FieldValidator Validator { get; }
        bool Validate(string[] fields, out string errorMessage);
    }
}
