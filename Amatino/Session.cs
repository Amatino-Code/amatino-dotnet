//
// Amatino .NET
// Session.cs
//
// Author: hugh@blinkybeach.com
//
using System;

namespace Amatino

{
    public class Session
    {
        private Action<Session> ready;
        internal long sessionId;

        public Session(
            string secret,
            string email,
            Action<Session> readyCallback
        )
        {
            ready = readyCallback;
            return;
        }

        public Session(
            long sessionId,
            string apiKey
            )
        {
            ready = null;
            this.sessionId = sessionId;
            return;
        }

        public void Delete() { }

        internal void loadResponse()
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
