using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class SerializationHelper
    {
        public static T Deserialize<T>(string json)
        {
            T obj;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                return default(T);
            }

            return obj;
        }

        public static List<T> DeserializeList<T>(string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<List<T>>(json);
                return obj;
            }
            catch (JsonReaderException ex)
            {
                Debug.Log(string.Format("Exception thrown deserializing {0}.  {1}", typeof(T), ex));
                return new List<T>();
            }
        }
    }
}
