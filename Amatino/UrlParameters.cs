//
// Amatino .NET
// UrlParameters.cs
//
// Author: hugh@blinkybeach.com
//
using System;

namespace Amatino
{
    internal struct UrlParameters
    {
        private readonly String parameterString;
        
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
        }

        public override string ToString()
        {
            return parameterString;
        }
    }
}
