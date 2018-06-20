//
// Amatino .NET
// RequestData.cs
//
// Author: hugh@blinkybeach.com
//
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Amatino
{
    internal class RequestData
    {
        private object objectData;

        internal RequestData(object objectData) {
            this.objectData = objectData;
            return;
        }

        internal RequestData(ApiEncodable encodableObject) {
            List<object> objectList = new List<object>();
            objectList.Add(encodableObject.AsSerialisableObject());
            objectData = objectList;
            return;
        }

        internal RequestData(List<ApiEncodable> encodableList) {
            List<object> objectList = new List<object>();
            foreach (ApiEncodable item in encodableList) {
                objectList.Add(item.AsSerialisableObject());
            }
            objectData = objectList;
        }

        internal object ObjectData() {
            return objectData;
        }

        internal string JsonData() {
            return JsonConvert.SerializeObject(objectData);
        }

    }
}
