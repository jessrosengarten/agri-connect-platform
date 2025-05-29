using System.ComponentModel.DataAnnotations;

namespace AgriConnectPlatform.Models
{
    /// <summary>
    /// Class to represent the Login model
    /// </summary>
    public class Login
    {
        // Properties representing login credentials
        public string email { get; set; }
        public string password { get; set; }

        // Constructor to initialize a Login object
        public Login(string Email, string Password) 
        {
            email = Email;
            password = Password;                                                
        }
    }
}
