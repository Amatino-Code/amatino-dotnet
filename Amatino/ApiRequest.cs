//
// Amatino .NET
// ApiRequest.cs
//
// Author: hugh@blinkybeach.com
//
using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Amatino
{

    public class ApiRequestException: Exception
    {
        public ApiRequestException() { }

        public ApiRequestException(string message) : base(message) { }
    }

    internal class ApiRequest
    {
        private const string signatureHeaderName = "X-Signature";
        private const string sessionIdHeaderName = "X-Session-ID";
        private const string userAgent = "Amatino .NET";
        private const string noSessionPath = "/session";
        private const string noSessionMethod = "POST";
        private const string requiredSessionMessage = @"
        A Session is required for all requests other than
        /authorisation/session + POST";
        internal dynamic responseData; 

#if DEBUG
        private string apiEndpoint = "http://127.0.0.1:5000";
#else
        private string apiEndpoint = "https://api.amatino.io";
#endif

        internal ApiRequest(
            string path,
            RequestData requestData,
            Session session,
            UrlParameters urlParameters,
            string httpMethod
        ) {
            if (
                session == null 
                && (
                    path != noSessionPath 
                    || httpMethod != noSessionMethod
                )
            ) {
                Console.WriteLine(path);
                Console.WriteLine(httpMethod);
                throw new ApiRequestException(requiredSessionMessage);
            }

            string fullUrl;

            if (urlParameters != null)
            {
                fullUrl = apiEndpoint + path + urlParameters.ToString();
            } else
            {
                fullUrl = apiEndpoint + path;
            }

            HttpWebRequest request = WebRequest.CreateHttp(fullUrl);
            request.UserAgent = userAgent;
            request.Method = httpMethod;
            if (session != null)
            {
                Signature signature;
                string apiKey = session.apiKey;
                if (requestData != null) {
                    signature = new Signature(apiKey, path, requestData);
                } else {
                    signature = new Signature(apiKey, path);
                }
                request.Headers.Add(sessionIdHeaderName, session.IdString());
                request.Headers.Add(signatureHeaderName, signature.ToString());
            }
            if (requestData != null) {
                string jsonData = requestData.JsonData();
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = utf8.GetBytes(jsonData);
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            WebResponse response = request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(
                receiveStream,
                Encoding.UTF8
            );
            string responseJson = readStream.ReadToEnd();
            response.Close();
            readStream.Close();

            try {
                responseData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    responseJson
                );
            }
            catch (JsonSerializationException) {
                responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                    responseJson
                );
            }

            return;
        }

    }
}
