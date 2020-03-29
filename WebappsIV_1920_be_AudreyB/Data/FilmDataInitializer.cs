using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data
{
    public class FilmDataInitializer
    {
        private readonly FilmContext _dbFilmContext;

        public FilmDataInitializer(FilmContext dbFilmContext)
        {
            _dbFilmContext = dbFilmContext;

        }
        public void InitializeData()
        {
            _dbFilmContext.Database.EnsureDeleted();
            if (_dbFilmContext.Database.EnsureCreated())
            {
                #region Acteurs
                Acteur LeonardoDC = new Acteur("Leonardo DiCaprio");
                Acteur KateW = new Acteur("Kate Winslet");
                Acteur KathyB = new Acteur("Kathy Bates");
                Acteur BillyZ = new Acteur("Billy Zane");
                Acteur KevinB = new Acteur("Kevin Bacon");
                Acteur LoriS = new Acteur("Lori Singer");
                Acteur JohnL = new Acteur("John Lithgow");
                Acteur DiannaW = new Acteur("Dianne Wiest");
                Acteur MarkH = new Acteur("Mark Hamill");
                Acteur HarrisonF = new Acteur("Harrison Ford");
                Acteur CarrieF = new Acteur("Carrie Fisher");
                Acteur PeterC = new Acteur("Peter Cushing");
                Acteur BarretO = new Acteur("Barret Oliver");
                Acteur GeraldMcR = new Acteur("Gerald McRaney");
                Acteur ChrisE = new Acteur("Chris Eastman");
                Acteur DarrylC = new Acteur("Darryl Cooksey");
                #endregion
                _dbFilmContext.Acteurs.AddRange(LeonardoDC, KateW, KathyB, BillyZ, KevinB, LoriS, JohnL, DiannaW, BarretO, GeraldMcR, ChrisE,
                   DarrylC );
                _dbFilmContext.SaveChanges();

                #region Genres
                Genre Drama = new Genre("Drama");
                Genre Romantiek = new Genre("Romantiek");
                Genre Actie = new Genre("Actie");
                Genre Avontuur = new Genre("Avontuur");
                Genre Komedie = new Genre("Komedie");
                Genre Documentaire = new Genre("Documentaire");
                Genre Fantasie = new Genre("Fantasie");
                Genre Horror = new Genre("Horror");
                Genre Kunst = new Genre("Kunst");
                Genre Misdaad = new Genre("Misdaad");
                Genre Muziek = new Genre("Muziek");
                Genre Natuur = new Genre("Natuur");
                Genre Kinderfilm = new Genre("Kinderfilm");
                Genre Sport = new Genre("Sport");
                Genre Sciencefiction = new Genre("Sciencefiction");
                Genre Thriller = new Genre("Thriller");
                Genre Westers = new Genre("Westers");
                Genre Oorlog = new Genre("Oorlog");
                Genre Superhelden = new Genre("Superhelden");
                Genre Tekenfilm = new Genre("Tekenfilm");
                Genre zwartWit = new Genre("zwartWit");
                Genre Religie = new Genre("Religie");
                Genre Musical = new Genre("Musical");
                Genre Mysterie = new Genre("Mysterie");
                Genre Religieus = new Genre("Religieus");
                Genre Geschiedenis = new Genre("Geschiedenis");
                Genre Detective = new Genre("Detective");
                Genre Familie = new Genre("Familie"); 
                #endregion
                _dbFilmContext.Genres.AddRange(new Genre[] { Drama, Romantiek, Actie , Avontuur , Komedie , Documentaire , Fantasie, Horror,
                Kunst,Misdaad , Muziek, Natuur, Kinderfilm, Sport, Sciencefiction, Thriller, Westers, Oorlog, Superhelden, Tekenfilm, zwartWit,
               Religie, Musical, Mysterie, Religieus, Geschiedenis, Detective, Familie});
                _dbFilmContext.SaveChanges();

                #region Schrijvers
                Schrijver JamesC = new Schrijver("James Cameron");
                Schrijver DeanP = new Schrijver("Dean Pitchford");
                Schrijver GeorgeL = new Schrijver("George Lucas");
                Schrijver WolfgangP = new Schrijver("Wolfgang Petersen");
                Schrijver HermanW = new Schrijver("Herman Weigel"); 
                #endregion
                _dbFilmContext.Schrijvers.AddRange(new Schrijver[] { JamesC, DeanP, GeorgeL, WolfgangP, HermanW});
                _dbFilmContext.SaveChanges();

                // string titel, int jaar, int duur, string regiseur, string korteInhoud, string productie)
                Film Titanic = new Film("Titanic", 1997, 194, "James Cameron",
                    "De 17-jarige rijke Rose DeWitt Bukater wordt door haar familie gedwongen om zich met Cal Hockley te verloven en binnenkort te gaan trouwen. " +
                    "Tijdens de eerste tocht over de Atlantische zee van de Titanic, een gigantisch passagiersschip dat onzinkbaar wordt geacht, besluit ze zelfmoord te plegen. " +
                    "De jonge Jack Dawson, een derde klasse-passagier, kan haar tegenhouden." +
                    "Ondanks hun totaal verschillende afkomst worden ze vrienden en al snel groeit een verboden liefde tussen hen allebei."
                   ,"Paramount Pictures");
                _dbFilmContext.Films.Add(Titanic);
                _dbFilmContext.SaveChanges();

                FilmGenre fg1 = new FilmGenre(Titanic, Drama);
                FilmGenre fg2 = new FilmGenre(Titanic, Romantiek);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg1, fg2 });
                _dbFilmContext.SaveChanges();

                FilmActeur fa1 = new FilmActeur(Titanic, LeonardoDC);
                FilmActeur fa2 = new FilmActeur(Titanic, KateW);
                FilmActeur fa3 = new FilmActeur(Titanic, KathyB);
                FilmActeur fa4 = new FilmActeur(Titanic, BillyZ);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa1, fa2, fa3, fa4 });
                _dbFilmContext.SaveChanges();

                FilmSchrijver fs1 = new FilmSchrijver(Titanic, JamesC);
                _dbFilmContext.FilmSchrijvers.Add(fs1);
                _dbFilmContext.SaveChanges();

                 Film Footloose = new Film("Footloose", 1984,  107,  "Herbert Ross",
                     "De film gaat over de tiener Ren die met zijn moeder van Chicago (Illinois) naar Bomont verhuist. " +
                     "Hij maakt nieuwe vrienden, ook de mooie Ariel heeft vanaf het begin zijn aandacht. Ren is bezeten door muziek en dansen, en dat is in Bomont verboden. " +
                     "Dominee Moore is er tegen omdat zijn zoon na een nachtje fuiven is omgekomen in een ongeval. Ren blijft volhouden en kan de dominee, de vader van Ariel, overtuigen een dansavond te organiseren.", "Paramount Home Video");
                FilmGenre fg3 = new FilmGenre(Footloose, Drama);
                FilmGenre fg4 = new FilmGenre(Footloose, Romantiek);
                FilmGenre fg5 = new FilmGenre(Footloose, Musical);
                FilmGenre fg6 = new FilmGenre(Footloose, Muziek);

                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg3, fg4, fg5, fg6});
                _dbFilmContext.SaveChanges();
       
                FilmActeur fa5 = new FilmActeur(Footloose, KevinB);
                FilmActeur fa6 = new FilmActeur(Footloose, LoriS);
                FilmActeur fa7 = new FilmActeur(Footloose, JohnL);
                FilmActeur fa8 = new FilmActeur(Footloose, DiannaW);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa5, fa6, fa7, fa8 });
                _dbFilmContext.SaveChanges();

                FilmSchrijver fs2 = new FilmSchrijver(Footloose, DeanP);
                _dbFilmContext.FilmSchrijvers.Add(fs2);
                _dbFilmContext.SaveChanges();

                Film StarWarsEIV = new Film("Star Wars: Episode IV - A New Hope", 1977, 121, "George Lucas", /*new List<string> { "George Lucas" },*/
                    "Luke Skywalker werkt op het land bij z'n oom en tante op de planeet Tatooine. Als zij door Keizerlijke troepen worden vermoord, sluit Luke zich aan bij de groep rebellen die vecht tegen de tirannie van de Keizer en de slechte Darth Vader. Luke, Princess Leia, Han Solo en de andere rebellen doen een poging de Death Star, het nieuwe wapen van de Keizer, te vernietigen.", "20th Century Fox");
                FilmGenre fg7 = new FilmGenre(StarWarsEIV, Actie);
                FilmGenre fg8 = new FilmGenre(StarWarsEIV, Avontuur);
                FilmGenre fg9 = new FilmGenre(StarWarsEIV, Fantasie);
                FilmGenre fg10 = new FilmGenre(StarWarsEIV, Sciencefiction);

                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg7, fg8, fg9, fg10 });
                _dbFilmContext.SaveChanges();

                FilmActeur fa9 = new FilmActeur(StarWarsEIV, MarkH);
                FilmActeur fa10 = new FilmActeur(StarWarsEIV, HarrisonF);
                FilmActeur fa11 = new FilmActeur(StarWarsEIV, CarrieF);
                FilmActeur fa12 = new FilmActeur(StarWarsEIV, PeterC);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa9, fa10, fa11, fa12 });
                _dbFilmContext.SaveChanges();

                FilmSchrijver fs3 = new FilmSchrijver(StarWarsEIV, GeorgeL);
                _dbFilmContext.FilmSchrijvers.Add(fs3);
                _dbFilmContext.SaveChanges();

                Film TheNeverEndingStory = new Film("The NeverEnding Story", 1984,102, "Wolfgang Petersen",/* new List<string> { "Wolfgang Petersen", "Herman Weigel" },*/
                   "Shy, awkward Bastian is amazed to discover that he has become a character in the mysterious book he is reading and that he has an important mission to fulfill.", "Warner Home Video");
                FilmGenre fg11 = new FilmGenre(TheNeverEndingStory, Avontuur);
                FilmGenre fg12 = new FilmGenre(TheNeverEndingStory, Familie);
                FilmGenre fg13 = new FilmGenre(TheNeverEndingStory, Drama);
                FilmGenre fg14 = new FilmGenre(TheNeverEndingStory, Fantasie);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg11, fg12, fg13, fg14 });
                _dbFilmContext.SaveChanges();

                FilmActeur fa13 = new FilmActeur(TheNeverEndingStory, BarretO);
                FilmActeur fa14 = new FilmActeur(TheNeverEndingStory, GeraldMcR);
                FilmActeur fa15 = new FilmActeur(TheNeverEndingStory, ChrisE);
                FilmActeur fa16 = new FilmActeur(TheNeverEndingStory, DarrylC);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa13, fa14, fa15, fa16 });
                _dbFilmContext.SaveChanges();

                FilmSchrijver fs4 = new FilmSchrijver(TheNeverEndingStory, WolfgangP);
                FilmSchrijver fs5 = new FilmSchrijver(TheNeverEndingStory, HermanW);
                _dbFilmContext.FilmSchrijvers.AddRange(new FilmSchrijver[] { fs4, fs5 });
                _dbFilmContext.SaveChanges();

                //  FilmGenre fg5 = new FilmGenre(TheNeverEndingStory, new List<string> { "Avontuur", "Drama", "Fantasie", "Familie" });
                // FilmSchrijver fs5 = new FilmSchrijver(TheNeverEndingStory, new List<string> { "Wolfgang Petersen", "Herman Weigel" });
                // FilmActeur fa5 = new FilmActeur(TheNeverEndingStory, new List<string> { "Barret Oliver", "Gerald McRaney", "Chris Eastman", "Darryl Cooksey" });


                //  FilmGenre fg4 = new FilmGenre(StarWarsEIV, new List<string> { "Actie", "Avontuur", "Fantasie", "Sciencefiction" });
                // FilmSchrijver fs4 = new FilmSchrijver(StarWarsEIV, new List<string> { "George Lucas" });
                // FilmActeur fa4 = new FilmActeur(StarWarsEIV, new List<string> { "Mark Hamill", "Harrison Ford", "Carrie Fisher", "Peter Cushing" });


                // Film TheShawshankRedemption = new Film("The Shawshank Redemption", new DateTime(1994), new DateTime(0, 0, 0, 0, 142, 0),/* new List<string> {"Drama"},new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler" }, */  "Frank Darabont",/* new List<string> { "Frank Darabont" },*/
                //      "Andy Dufresne (Tim Robbins) wordt beschuldigd van de moord op zijn vrouw en haar minnaar. Hij houdt vol dat hij onschuldig is, maar krijgt toch tweemaal levenslang in de strenge gevangenis Shawshank. Hij raakt bevriend met de zwarte medegevangene Ellis Boyd Redding (Morgan Freeman), die voor iedereen spullen kan regelen en de bijnaam 'Red' heeft. En er zijn nog twee dingen die Andy op de been houden: hoop en een poster van Rita Hayworth.", "Columbia Pictures");
                // FilmGenre fg3 = new FilmGenre(TheShawshankRedemption, new List<string> { "Drama" });
                // FilmSchrijver fs3 = new FilmSchrijver(TheShawshankRedemption,new List<string>{ "Frank Darabont" } );
                // FilmActeur fa3 = new FilmActeur(TheShawshankRedemption, new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler" });


                // Film MammaMia = new Film("Mamma Mia!", new DateTime(2008), new DateTime(0, 0, 0, 0, 108, 0),/* new List<string> { "Romantiek", "Komedie","Musical","Muziek"},  new List<string> { "Amanda Seyfried", "Stellan Skarsgård", "Pierce Brosnan", "Nancy Baldwin" }, */ "Phyllida Lloyd", /*new List<string> { "Catherine Johnson" },*/
                //     "Donna, een onafhankelijke, single moeder heeft een hotelletje op een idyllisch Grieks eiland. Ze staat op het punt om Sophie, de pittige dochter die ze alleen heeft grootgebracht, los te laten. Voor Sophie's huwelijk heeft Donna haar twee oude hartsvrienden uitgenodigd: de praktische en no-nonsense Rosie en de rijke, meermalen gescheiden Tanya van haar vroegere backing-band 'Donna and the Dynamos'. Maar Sophie heeft in het geheim zelf drie gasten uitgenodigd. " +
                //     "Ze is op zoek gegaan naar de identiteit van haar vader die haar naar het altaar moet begeleiden en ze haalt drie mannen uit Donna's verleden naar het mediterrane paradijs waar ze 20 jaar daarvoor waren geweest. In de 24 chaotische, magische uren bloeit er nieuwe liefde op en oude romances vatten opnieuw vlam op dit weelderige eiland vol mogelijkheden.", "Universal Pictures");
                // FilmGenre fg6 = new FilmGenre(MammaMia, new List<string> { "Romantiek", "Komedie", "Musical", "Muziek" });
                // FilmSchrijver fs6 = new FilmSchrijver(MammaMia, new List<string> { "Catherine Johnson" });
                // FilmActeur fa6 = new FilmActeur(MammaMia, new List<string> { "Amanda Seyfried", "Stellan Skarsgård", "Pierce Brosnan", "Nancy Baldwin" });

                // Film TheLordOfTheRings1 = new Film("The Lord of the Rings: The Fellowship of the Ring", new DateTime(2001), new DateTime(0, 0, 0, 0, 178, 0),/* new List<string> { "Avontuur", "Actie", "Fantasie", "Drama" }, new List<string> { "Alan Howard", "Noel Appleby", "Sean Astin", "Sala Baker" }, */ "Peter Jackson",/* new List<string> { "J.R.R. Tolkien"},*/
                //     "Een eeuwenoude ring, die jaren zoek is geweest, wordt gevonden en komt bij toeval terecht bij de kleine Hobbit Frodo. Als de tovenaar Gandalf erachter komt dat deze ring eigenlijk de Ene Ring is waar de slechte Sauron naar op zoek is, gaat Frodo samen met Gandalf, een Dwerg, een Elf, twee Mensen en drie andere Hobbits op een groots avontuur om deze te vernietigen.", "New Line Cinema");
                // FilmGenre fg7 = new FilmGenre(TheLordOfTheRings1, new List<string> { "Avontuur", "Actie", "Fantasie", "Drama" });
                //FilmSchrijver fs7 = new FilmSchrijver(TheLordOfTheRings1 ,new List<string> { "J.R.R. Tolkien" });
                // FilmActeur fa7 = new FilmActeur(TheLordOfTheRings1, new List<string> { "Alan Howard", "Noel Appleby", "Sean Astin", "Sala Baker" });

                // Film DolphinTale = new Film("Dolphin Tale", new DateTime(2011), new DateTime(0, 0, 0, 0, 113, 0), /*new List<string> { "Familie", "Drama"}, new List<string> { "Harry Connick Jr.", "Ashley Judd", "Nathan Gamble", "Kris Kristofferson" }, */ "Charles Martin Smith",/* new List<string> { "Karen Janszen", "Noam Dromi" }, */
                //     "Een jongen raakt bevriend met Winter, een gewonde dolfijn die zijn staart verloren is in een krabbenval. Hij probeert iedereen om zich heen te motiveren om de dolfijn te redden. De dierenarts Clay redt de dolfijn en brengt hem naar zijn hospitaal. Hier proberen ze samen met een dokter (Morgan Freeman) een prothese te maken om de staart te vervangen en zo de dolfijn te redden.", "Warner Bros.Pictures");
                // FilmGenre fg8 = new FilmGenre(DolphinTale, new List<string> { "Familie", "Drama" });
                // FilmSchrijver fs8 = new FilmSchrijver(DolphinTale, new List<string> { "Karen Janszen", "Noam Dromi" });
                // FilmActeur fa8 = new FilmActeur(DolphinTale, new List<string> { "Harry Connick Jr.", "Ashley Judd", "Nathan Gamble", "Kris Kristofferson" });

                // Film Skyfall = new Film("Skyfall", new DateTime(2012), new DateTime(0, 0, 0, 0, 143, 0), /*new List<string> { "Avontuur", "Thriller" }, new List<string> { "Daniel Craig", "Judi Dench", "Javier Bardem", "Ralph Fiennes" },*/ "Sam Mendes", /*new List<string> { "Neal Purvis", "Robert Wade", "John Logan" }, */
                //     "Bonds loyaliteit aan M wordt op de proef gesteld als ze achtervolgd wordt door haar verleden. Als de MI6 vervolgens onder vuur komt te liggen is Bond genoodzaakt de bedreiging op te sporen en te vernietigen, ongeacht de hoge persoonlijke prijs die dit met zich mee brengt.", "MGM");
                // FilmGenre fg9 = new FilmGenre(Skyfall, new List<string> { "Avontuur", "Thriller" });
                // FilmSchrijver fs9 = new FilmSchrijver(Skyfall, new List<string> { "Neal Purvis", "Robert Wade", "John Logan" });
                // FilmActeur fa9 = new FilmActeur(Skyfall, new List<string> { "Daniel Craig", "Judi Dench", "Javier Bardem", "Ralph Fiennes" });

                // Film EdwardScissorhands = new Film("Edward Scissorhands", new DateTime(1990), new DateTime(0, 0, 0, 0, 105, 0), /*new List<string> {"Romantiek", "Drama", "Fantasie"}, new List<string> { "Johnny Depp", "Winona Ryder", "Dianne Wiest", "Anthony Michael Hall" }, */ "Tim Burton", /*new List<string> { "Tim Burton", "Caroline Thompson" },*/
                //     "Edward is gecreëerd door een uitvinder, die echter stierf voor hij z'n karwei af kon maken. Hierdoor heeft Edward scharen waar eigenlijk zijn handen zouden moeten zitten. Wanneer een vrouw bij zijn grote landhuis aanbelt en hem daar vindt, neemt ze hem mee naar haar huis om bij haar familie te wonen. Al snel weet hij zich aan te passen aan de voor hem ongewone omgeving.", "20th Century Fox");
                // FilmGenre fg10 = new FilmGenre(EdwardScissorhands, new List<string> { "Romantiek", "Drama", "Fantasie" });
                // FilmSchrijver fs10 = new FilmSchrijver(EdwardScissorhands, new List<string> { "Tim Burton", "Caroline Thompson" });
                // FilmActeur fa10 = new FilmActeur(EdwardScissorhands, new List<string> { "Johnny Depp", "Winona Ryder", "Dianne Wiest", "Anthony Michael Hall" });

                // Film PiratesOfTheCaribbeanI = new Film("Pirates of the Caribbean: The Curse of the Black Pearl", new DateTime(2003), new DateTime(0, 0, 0, 0, 143, 0),/* new List<string> {"Avontuur", "Actie", "Fantasie"}, new List<string> { "Johnny Depp", "Geoffrey Rush", "Orlando Bloom", "Keira Knightley" }, */"Gore Verbinski", /*new List<string> { "Ted Elliott", "Terry Rossio", "Stuart Beattie", "Jay Wolpert" },*/
                //      "Jack Sparrow, de afgedankte kapitein van het beroemde spookschip The Black Pearl, wil zijn schip terug. De nieuwe kapitein, Barbossa, ontvoert Elizabeth Swann tijdens één van hun veroveringen, omdat Elizabeth de enige lijkt die er voor kan zorgen dat de vloek van Cortez, die op Barbossa en zijn crew rust, wordt opgeheven. " +
                //      "De ware persoon die de vloek kan opheffen is echter Will Turner, die smoorverliefd is op Elizabeth. En dus schakelt Will, om Elizabeth te redden, de enige in die de thuishaven van The Black Pearl kent: Kapitein Jack Sparrow.", "Buena Vista Pictures");
                // FilmGenre fg11 = new FilmGenre(PiratesOfTheCaribbeanI, new List<string> { "Avontuur", "Actie", "Fantasie" });
                // FilmSchrijver fs11 = new FilmSchrijver(PiratesOfTheCaribbeanI, new List<string> { "Ted Elliott", "Terry Rossio", "Stuart Beattie", "Jay Wolpert" });
                // FilmActeur fa11 = new FilmActeur(PiratesOfTheCaribbeanI, new List<string> { "Johnny Depp", "Geoffrey Rush", "Orlando Bloom", "Keira Knightley" });

                // _dbFilmContext.Films.AddRange(new Film[] { Titanic, Footloose, TheShawshankRedemption, StarWarsEIV, TheNeverEndingStory,
                // MammaMia, TheLordOfTheRings1, DolphinTale, Skyfall, EdwardScissorhands, PiratesOfTheCaribbeanI});
                // _dbFilmContext.SaveChanges();

                // _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg1, fg2, fg3, fg4, fg5, fg6, fg7, fg8, fg9, fg10, fg11 });
                // _dbFilmContext.SaveChanges();

                // _dbFilmContext.FilmSchrijvers.AddRange(new FilmSchrijver[] { fs1, fs2, fs3, fs4, fs5, fs6, fs7, fs8, fs9, fs10, fs11 });
                // _dbFilmContext.SaveChanges();

                // _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa1, fa2, fa3, fa4, fa5, fa6, fa7, fa8, fa9, fa10, fa11 });
                // _dbFilmContext.SaveChanges();

            }
        }
    }
}

