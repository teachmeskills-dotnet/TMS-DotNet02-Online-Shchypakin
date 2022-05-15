using System.ComponentModel.DataAnnotations;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class LoginDto
    {
        [Required]
        public string ClientName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
