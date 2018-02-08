//
// Amatino .NET
// UrlTarget.cs
//
// Author: hugh@blinkybeach.com
//
using System;

namespace Amatino
{
    internal struct UrlTarget
    {
        readonly String key;
        readonly String value;

        UrlTarget(String key, String value)
        {
            this.key = key;
            this.value = value;
            return;
        }

        UrlTarget(String key, int value)
        {
            this.key = key;
            this.value = value.ToString();
        }

        public override string ToString()
        {
            return key + "=" + value;
        }
    }
}
