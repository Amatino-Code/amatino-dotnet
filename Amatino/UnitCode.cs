//
// Amatino .NET
// UnitCode.cs
//
// Author: hugh@amatino.io
//
using System;
using System.Text.RegularExpressions;

namespace Amatino
{
    struct UnitCode
    {
        private const string invalidLength = "Code must be between 1 and 3 characters long";
        private const string invalidChar = "Code must only include Unicode Ll characters";
        private const string validExpression = @"\p{Ll}";
        private readonly String unitCode;

        public UnitCode(String code)
        {
            if (code.Length < 1 || code.Length > 3) {
                throw new ArgumentException(invalidLength);
            }

            if (!Regex.IsMatch(code, validExpression))
            {
                throw new ArgumentException(invalidChar);
            }

            unitCode = code;
            return;
        }

        public override string ToString()
        {
            return unitCode;
        }
    }
}
