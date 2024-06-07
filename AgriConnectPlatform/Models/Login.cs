using System.ComponentModel.DataAnnotations;

namespace AgriConnectPlatform.Models
{
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }

        public Login(string Email, string Password) 
        {
            email = Email;
            password = Password;                                                
        }
    }
}
