//
// Amatino .NET
// GlobalUnit.cs
//
// Author: hugh@blinkybeach.com
//
using System;

namespace Amatino
{
    public class GlobalUnit
    {
        public GlobalUnit(
            Session session,
            string code,
            Action<GlobalUnit> readyCallback
            )
        {
            return;
        }

        public GlobalUnit(
            Session session,
            string code,
            string name,
            string description,
            int exponent,
            Action<GlobalUnit> readyCallback
            )
        {
            return;
        }

        private void Create() { }

        private void Retrieve() { }

        public void Update() { }

        public void Delete() { }

    }
}
