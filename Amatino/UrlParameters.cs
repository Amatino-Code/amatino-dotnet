//
// Amatino .NET
// UrlParameters.cs
//
// Author: hugh@blinkybeach.com
//
using System;

namespace Amatino
{
    internal class UrlParameters
    {
        private readonly String parameterString;
        
        internal UrlParameters(string rawQueryString) {
            parameterString = rawQueryString;
            return;
        }

        UrlParameters(Entity entity)
        {
            parameterString = "?entity_id=" + entity.id;
            return;
        }

        UrlParameters(Entity entity, UrlTarget[] targets)
        {
            var workingString = "?entity_id=" + entity.id;
            foreach (UrlTarget target in targets) {
                workingString += "&" + target.ToString();
            }
            parameterString = workingString;
            return;
        }

        public override string ToString()
        {
            return parameterString;
        }
    }
}
