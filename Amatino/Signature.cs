//
// Amatino .NET
// Signature.cs
//
// Author: hugh@blinkybeach.com
//
using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Amatino

{
    internal class Signature {

        private string signatureString;

        internal Signature(
            string apiKey,
            string path,
            RequestData requestData
        ) {
            string dataString = requestData.JsonData();
            string message = TimeStampString() + path + dataString;
            signatureString = HashString(message, apiKey);
            return;
        }

        internal Signature(
            string apiKey,
            string path
        ) {
            string message = TimeStampString() + path;
            signatureString = HashString(message, apiKey);
            return;
        }

        private string HashString(string text, string key) {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] textBytes = utf8.GetBytes(text);
            byte[] keyBytes = utf8.GetBytes(key);
            byte[] hashBytes;

            using (HMACSHA512 hash = new HMACSHA512(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return System.Convert.ToBase64String(hashBytes);
        }

        private string TimeStampString() {
            DateTime now = DateTime.UtcNow;
            long time = ((DateTimeOffset)now).ToUnixTimeSeconds();
            return time.ToString();
        }

        override public string ToString() {
            return signatureString;
        }

    }
}