namespace DSM.Core.Models.AuthServices
{
    public class SignedUser
    {
        public string UserName { get; set; }
        public string AuthKey { get; set; }
        public string Role { get; set; }
    }
}
