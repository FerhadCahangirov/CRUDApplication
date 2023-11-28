using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Name can not be blank")]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Email can not be blank")]
        [EmailAddress]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email is already in use")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone can not be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain numbers only")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Password can not be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword can not be blank")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public UserTypeOptions UserType { get; set; } = UserTypeOptions.User;
    }
}
