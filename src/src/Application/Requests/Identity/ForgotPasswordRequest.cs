using System.ComponentModel.DataAnnotations;

namespace GenocsBlazor.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}