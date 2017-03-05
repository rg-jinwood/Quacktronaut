using Assets.Scripts.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Helpers
{
    public static class LoginHelper
    {

        public static IEnumerator Login(string email, string password)
        {
            var data = new AuthenticationModel //new up a serializable object
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(data); //serialize to json
            var bodyRaw = Encoding.UTF8.GetBytes(json); //encode to bytesteram
            var url = string.Format("{0}{1}", Contstants.ApiUrl, Contstants.LoginUrl);

            var request = UnityWebRequest.Post(url, json);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json"); //we are sending json

            yield return request.Send();

            Debug.Log("Authentication Status Code: " + request.responseCode);

            if(request.responseCode == 200)
            {
                var token = JsonConvert.DeserializeObject<AuthenticationResponseModel>(request.downloadHandler.text); //deserielize the response
                PlayerPrefs.SetString("token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoxLCJpc19hZG1pbiI6dHJ1ZSwiZXhwIjoxNDkxMjI2NDU1LCJ1c2VybmFtZSI6IkpvbiJ9.3J7UdKeMYXRxtJRPRADC6t-i81TL1iBJY4E1yQtRHmE"); //store locally
                PlayerPrefs.Save();

                SceneManager.LoadScene(1); //load the level
            }
            else if(request.responseCode == 500) //handle errors here
            {

            }
        }
    }

    
}
