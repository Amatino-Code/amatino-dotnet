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
            long session_id,
            string api_key
            )
        {
            ready = null;
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
    }
}
