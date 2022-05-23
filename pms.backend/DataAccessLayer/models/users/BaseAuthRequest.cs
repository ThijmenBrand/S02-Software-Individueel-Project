using System.ComponentModel.DataAnnotations;

namespace DataLayer.models.users
{
    public class BaseAuthRequest
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
