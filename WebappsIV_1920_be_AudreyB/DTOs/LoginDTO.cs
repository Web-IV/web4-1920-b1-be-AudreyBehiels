using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.DTOs
{
    public class LoginDTO
    {
        [Required]
       [EmailAddress]
        public string Mailadres { get; set; }

        [Required]
        public string Wachtwoord { get; set; }
    }
}
