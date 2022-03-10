using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Service.Dtos
{
    public class AuthenticateDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AuthenticateOutputDto
    {
        public string AccessToken { get; set; }

        public DateTime? Expire { get; set; }
    }
}
