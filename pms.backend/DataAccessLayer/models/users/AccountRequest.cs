using System.ComponentModel.DataAnnotations;

namespace DataLayer.models.users
{
    public class AccountRequest : BaseAuthRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
