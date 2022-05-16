using System;
using System.ComponentModel.DataAnnotations;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }
    }
}
