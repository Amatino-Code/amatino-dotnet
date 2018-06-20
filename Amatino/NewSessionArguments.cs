//
// Amatino .NET
// NewSessionArguments.cs
//
// Author: hugh@blinkybeach.com
//
using System;
using System.Collections.Generic;

namespace Amatino {

    internal class NewSessionArguments: ApiEncodable {
        private string secret;
        private string email;
        private long? userId;

        internal NewSessionArguments(
            string secret,
            string email
        ) {
            this.secret = secret;
            this.email = email;
            userId = null;
        }

        internal NewSessionArguments(
            string secret,
            long userId
        ) {
            email = null;
            this.userId = userId;
            this.secret = secret;
        }

        public object AsSerialisableObject() {
            Dictionary<string, object> rvObject;
            rvObject = new Dictionary<string, object>() {
                {"secret", secret},
                {"account_email", email},
                {"user_id", userId}
            };
            return rvObject;
        }
    }
}