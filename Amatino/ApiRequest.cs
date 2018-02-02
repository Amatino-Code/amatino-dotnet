//
// Amatino .NET
// ApiRequest.cs
//
// Author: hugh@blinkybeach.com
//
using System;

namespace Amatino
{
    internal class ApiRequest
    {
#if DEBUG
    private string apiEndpoint = "http://127.0.0.1:5000";
#else
    private string apiEndpoint = "https://api.amatino.io;
#endif
        internal ApiRequest(
            Action completionCallback
            ) { }

    }
}
