//
// Amatino .NET
// AmatinoRequest.cs
//
// Author: hugh@blinkybeach.com
//
using System;
using System.Net;

namespace Amatino
{

    public class AmatinoRequestException: Exception
    {
        public AmatinoRequestException() { }

        public AmatinoRequestException(string message) : base(message) { }
    }

    internal class AmatinoRequest
    {
        private const string signatureHeaderName = "X-Signature";
        private const string sessionIdHeaderName = "X-Session-ID";
        private const string userAgent = "Amatino .NET [Unknown Version]";
        private const string noSessionPath = "/authorisation/session";
        private const string noSessionMethod = "POST";
        private const string requiredSessionMessage = @"
        A Session is required for all requests other than
        /authorisation/session + POST";

#if DEBUG
        private string apiEndpoint = "http://127.0.0.1:5000";
#else
        private string apiEndpoint = "https://api.amatino.io;
#endif
        private readonly Action callback;

        internal AmatinoRequest(
            string path,
            RequestData requestData,
            Session session,
            UrlParameters urlParameters,
            string httpMethod,
            Action completionCallback
            )
        {
            callback = completionCallback;

            if (session == null && (path != noSessionPath || httpMethod != noSessionMethod)) {
                throw new AmatinoRequestException(requiredSessionMessage);
            }

            string fullUrl;

            if (urlParameters != null)
            {
                fullUrl = apiEndpoint + path + urlParameters.ToString();
            } else
            {
                fullUrl = apiEndpoint + path;
            }

            HttpWebRequest request = HttpWebRequest.CreateHttp(fullUrl);
            request.UserAgent = "blarg";
            request.Method = httpMethod;
            if (session != null)
            {
                string signature = session.Signature(path, requestData);
                request.Headers.Add(sessionIdHeaderName, session.IdString());
                request.Headers.Add(signatureHeaderName, signature);
            }

            
        }

    }
}
