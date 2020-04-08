using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(50)]
        public String Voornaam { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(50)]
        public String Familienaam { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Compare("Mailadres")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+.?[a-zA-Z0-9]*.[a-zA-Z]{2,}$")]
        // [RegularExpression("^[a-zA-Z0-9._-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\'.[a-zA-Z0-9-]{0,61})*$")]
        public String Mailadres { get; set; }
     
        [Required(ErrorMessage = "{0} is verplicht")]
        [DataType(DataType.Password)]
        [Compare("Wachtwoord", ErrorMessage ="Het wachtwoord veld en wachtwoord bevestingings vest moeten exact hetzelfde zijn")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
            ErrorMessage = "Wachtwoord moet ten minste 8 karakters hebben en bevat 3 of 4 van het volgende: hoofdletter (A-Z), kleine letter (a-z), getal (0-9) en een speciaal karakter (bv. !@#$%^&*)")] 
        public String WachtwoordBevestiging { get; set; }
    }

}

