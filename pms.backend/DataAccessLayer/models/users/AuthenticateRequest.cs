using System.ComponentModel.DataAnnotations;

namespace DataLayer.models.users
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
