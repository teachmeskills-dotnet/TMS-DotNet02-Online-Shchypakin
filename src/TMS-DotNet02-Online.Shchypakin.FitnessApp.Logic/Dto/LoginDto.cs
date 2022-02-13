using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
