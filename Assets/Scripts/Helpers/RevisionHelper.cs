using Assets.Scripts.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class RevisionHelper
    {
        public static IEnumerator GetLatestRevision(string bearer, Action<RevisionModel> success)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Bearer " + bearer);
            

            var url = string.Format("{0}{1}", Contstants.ApiUrl, Contstants.RevisionUrl);
            var request = new WWW(url, null, headers);
            //request.SetRequestHeader("Authorization", bearer);
            //var x = request.GetRequestHeader("Authorization");

            yield return request;

            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.Log(request.error);
            }
            else
            {
                var revisions = SerializationHelper.Deserialize<RevisionModel>(request.text);
                success(revisions);
            }
        }
    }
}
