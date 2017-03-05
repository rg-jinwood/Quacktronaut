namespace Assets.Scripts.Models
{
    public class AuthenticationResponseModel
    {
        public ResponseData Data { get; set; }
        
    }
    public class ResponseData
    {
        public string Token { get; set; }
    }
}
