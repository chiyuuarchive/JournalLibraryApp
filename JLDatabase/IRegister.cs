using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase
{
    internal interface IRegister
    {
        bool Register(string[] fields, out string errorMessage);
    }
}
