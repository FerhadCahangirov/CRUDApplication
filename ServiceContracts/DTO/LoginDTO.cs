using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email can not be blank")]
        [EmailAddress(ErrorMessage="Email should be in a proper email address format")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Email can not be blank")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
