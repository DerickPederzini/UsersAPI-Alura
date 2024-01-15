using Microsoft.AspNetCore.Identity;

namespace UserAPI.Models
{
    //when utilizing identity, the model class will already have some variables that come built in like email, paswword, username and etc
    //To use them just extend IdentityUser
    //You can change them later
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }

        public User() : base ()
        {
            
        }
    }
}
