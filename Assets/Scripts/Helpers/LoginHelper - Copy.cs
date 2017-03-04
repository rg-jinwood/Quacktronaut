//using CI.HttpClient;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Text;
//using UnityEngine;

//namespace Assets.Scripts.Helpers
//{
//    public static class LoginHelper
//    {

//        public static void Login(string email, string password)
//        {
//            //var client = new HttpClient();

//            var data = new Data
//            {
//                email = email,
//                password = password
//            };
            

//            var serialized = JsonConvert.SerializeObject(data);

//            try
//            {
//                using (var client = new WebClient())
//                {
//                    var url = string.Format("{0}/{1}", Contstants.ApiUrl, Contstants.LoginUrl);
//                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
//                    var result = client.UploadString(url, "POST", serialized);
//                }
//            }
//            catch (WebException ex)
//            {
//                Debug.Log("exception: " + ex);
//                var response = ex.Response as HttpWebResponse;
//                if (response != null)
//                {
//                    Debug.Log("HTTP Status Code: " + (int)response.StatusCode);
//                }

//                switch ((int)response.StatusCode)
//                {
//                    default:
//                        Debug.Log("OH SHIT");
//                        break;
//                }
//            }

//                //client.Post(new Uri(string.Format("{0}/{1}", Contstants.ApiUrl, Contstants.LoginUrl)),
//                //    new StringContent(serialized),
//                //    (r) =>
//                //    {
//                //        Console.WriteLine(r.Data);
//                //    });
//            }
//    }

//    //[Serializable]
//    //public class Data
//    //{
//    //    public string email { get; set; }
//    //    public string password { get; set; }
//    //}


//    public class Data
//    {
//        public string email;
//        public string password;
//    }
//}
