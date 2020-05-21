using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public interface IGebruikerRepository
    {
       void ToevoegenGebruiker(Gebruiker gebruiker);
        void VoegDuimToe(Film film, Gebruiker gebruiker);
        void VerwijderDuim(Film film, Gebruiker gebruiker);
        Gebruiker GetGebruikerByEmail(string mailadres);
        //  void AddFilmToOwnList(string titel);

        void SaveChanges();
    }
}
