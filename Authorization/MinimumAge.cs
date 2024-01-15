using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace UserAPI.Authorization
{
    public class MinimumAge : IAuthorizationRequirement
    {
        public MinimumAge(int Age)
        {
            this.Age = Age;
        }
        public int Age { get; set; }

    }
}
