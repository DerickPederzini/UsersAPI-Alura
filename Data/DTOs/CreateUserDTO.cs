using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.DTOs
{
    public class CreateUserDTO
    {

        //even though the identityUser class has other values, they are nullabe, we are only using the ones below
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
