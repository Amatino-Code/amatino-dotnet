//
// Amatino .NET
// AmatinoAlpha.cs
//
// Author: hugh@blinkybeach.com
//


using System;
namespace Amatino
{
    public class AmatinoAlpha
    {
        private Session session;

        public AmatinoAlpha(
            string email,
            string secret
        ) {
            session = new Session(secret, email);
        }

        public object Request(
            string path,
            string method,
            string queryString,
            object body
        ) {
            RequestData requestData = new RequestData(body);
            UrlParameters urlParameters = new UrlParameters(queryString);
            ApiRequest request = new ApiRequest(
                path,
                requestData,
                session,
                urlParameters,
                method
            );
            return request.responseData;
        }
    }
}
