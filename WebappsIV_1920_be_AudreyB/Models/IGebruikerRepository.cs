using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public interface IGebruikerRepository
    {
       void ToevoegenGebruiker(Gebruiker gerbuiker);
        void VoegDuimToe(Film film);
        void VerwijderDuim(Film film);
        //  void AddFilmToOwnList(string titel);

        void SaveChanges();
    }
}
