using Newtonsoft.Json;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Helpers
{
    public static class LoginHelper
    {

        public static IEnumerator Login(string email, string password)
        {
            var data = new Data
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(data);
            var bodyRaw = Encoding.UTF8.GetBytes(json);
            var url = string.Format("{0}{1}", Contstants.ApiUrl, Contstants.LoginUrl);

            var request = UnityWebRequest.Post(url, json);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.Send();

            Debug.Log("Status Code: " + request.responseCode);

            if(request.responseCode == 200)
            {

            }
            else if(request.responseCode == 500)
            {

            }
        }
    }

    public class Data
    {
        public string Email;
        public string Password;
    }
}
