using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.DTOs
{
    public class GebruikerDTO
    {
        public string Voornaam { get; set; }

       public string Familienaam { get; set; }

        public string Mailadres { get; set; }
       
        public GebruikerDTO() {  }
        
        public GebruikerDTO(Gebruiker gebruiker) : this()
        {
            Voornaam = gebruiker.Voornaam;
            Familienaam = gebruiker.Familienaam;
            Mailadres = gebruiker.Mailadres;
        
            
        }
    }
}
