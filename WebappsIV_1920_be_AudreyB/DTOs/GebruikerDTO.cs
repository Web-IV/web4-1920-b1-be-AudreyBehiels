using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.DTOs
{
    public class GebruikerDTO
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
        public string Mailadres { get; set; }

        public GebruikerDTO(GebruikerDTO gebruiker)
        {
            Voornaam = gebruiker.Voornaam;
            Familienaam = gebruiker.Familienaam;
            Mailadres = gebruiker.Mailadres;
        }
    }
}
