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
        private string apiPath = "/sessions";
        private Action<Session> ready;
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
            RequestData requestData = new RequestData(arguments);
            ApiRequest request = new ApiRequest(
                apiPath,
                requestData,
                null,
                null,
                "POST"
            );
            Dictionary<string, object> data = request.responseData[0];
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
            ready = null;
            this.sessionId = sessionId;
            this.apiKey = apiKey;
            this.userId = userId;
            return;
        }

        public void Delete() { }

        internal void loadResponse(dynamic data)
        {

            ready(this);
            return;
        }
           
        internal string Signature(string path, RequestData requestData)
        {
            return "placeholder";
        }

        internal string IdString()
        {
            return sessionId.ToString();
        }
    }
}
