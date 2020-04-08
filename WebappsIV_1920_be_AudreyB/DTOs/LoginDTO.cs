using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="{0} is verplicht")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Mailadres { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }
    }
}
