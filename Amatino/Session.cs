//
// Amatino .NET
// Session.cs
//
// Author: hugh@blinkybeach.com
//
using System;
using System.Collections.Generic;

namespace Amatino

{
    public class Session
    {
        private string apiPath = "/session";
        internal long sessionId;
        internal string apiKey;
        internal long userId;

        public Session(
            string secret,
            string email
        ) {
            NewSessionArguments arguments = new NewSessionArguments(
                secret: secret,
                email: email
            );
            RequestData requestData = new RequestData(arguments, true);
            ApiRequest request = new ApiRequest(
                apiPath,
                requestData,
                null,
                null,
                "POST"
            );
            Dictionary<string, object> data = request.responseData as Dictionary<string, object>;
            sessionId = (data["session_id"] as long?) ?? default(long);
            apiKey = data["api_key"] as string;
            userId = (data["user_id"] as long?) ?? default(long);
            return;
        }

        public Session(
            long sessionId,
            string apiKey,
            long userId
        ) {
            this.sessionId = sessionId;
            this.apiKey = apiKey;
            this.userId = userId;
            return;
        }

        internal string IdString()
        {
            return sessionId.ToString();
        }
    }
}
