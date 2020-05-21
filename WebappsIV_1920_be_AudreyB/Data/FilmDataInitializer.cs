using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data
{
    public class FilmDataInitializer
    {
        private readonly FilmContext _dbFilmContext;
        private readonly UserManager<IdentityUser> _userManager;
       private Gebruiker admin;
        private Gebruiker gebruiker;

        public FilmDataInitializer(FilmContext dbFilmContext, UserManager<IdentityUser> userManager)
        {
            _dbFilmContext = dbFilmContext;
            _userManager = userManager;

        }
        public async Task InitializeData()
        {
           _dbFilmContext.Database.EnsureDeleted();
            if (_dbFilmContext.Database.EnsureCreated())
            {
                admin = new Gebruiker("Audrey", "Behiels", "audrey.behiels@gmail.com")
                {
                    IsAdmin = true
                };
                _dbFilmContext.Gebruikers.Add(admin);
                await AanmakenGebruiker(admin.Mailadres, "W@chtwoord2");
                //await AanmakenGebruiker(admin.Mailadres, "P@ssword1111");
               
               // await _userManager.AddClaimAsync(admin, new Claim(ClaimTypes.Role, "Admin"));

                gebruiker = new Gebruiker("Kris", "Jansens", "kris.jansens@gmail.com") {
                    IsAdmin = false
            };
                //await AanmakenGebruiker(gebruiker.Mailadres, "P@ss1111");
                //_dbFilmContext.Gebruikers.AddRange(new Gebruiker[] { admin, gebruiker });
                // await _userManager.AddClaimAsync(gebruiker1, new Claim(ClaimTypes.Role, "Gebruiker"));
                _dbFilmContext.Gebruikers.Add(gebruiker);

                await AanmakenGebruiker(gebruiker.Mailadres, "W@chtwoord1");
                Gebruiker gebruiker2 = new Gebruiker { Voornaam = "Anne", Familienaam = "Vinke", Mailadres = "anne@gmail.com", IsAdmin = false };
                _dbFilmContext.Gebruikers.Add(gebruiker2);
                await AanmakenGebruiker(gebruiker2.Mailadres, "W@chtwoord2");


                // await AanmakenGebruiker();

                _dbFilmContext.SaveChanges();

                #region Acteurs
                Acteur LeonardoDC = new Acteur("Leonardo DiCaprio");
                Acteur KateW = new Acteur("Kate Winslet");
                Acteur KathyB = new Acteur("Kathy Bates");
                Acteur BillyZ = new Acteur("Billy Zane");
                Acteur KevinB = new Acteur("Kevin Bacon");
                Acteur LoriS = new Acteur("Lori Singer");
                Acteur JohnL = new Acteur("John Lithgow");
                Acteur DianneW = new Acteur("Dianne Wiest");
                Acteur MarkH = new Acteur("Mark Hamill");
                Acteur HarrisonF = new Acteur("Harrison Ford");
                Acteur CarrieF = new Acteur("Carrie Fisher");
                Acteur PeterC = new Acteur("Peter Cushing");
                Acteur BarretO = new Acteur("Barret Oliver");
                Acteur GeraldMcR = new Acteur("Gerald McRaney");
                Acteur ChrisE = new Acteur("Chris Eastman");
                Acteur DarrylC = new Acteur("Darryl Cooksey");
                Acteur TimR = new Acteur("Tim Robbins"); 
                Acteur MorganF = new Acteur("Morgan Freeman");
                Acteur BobG = new Acteur("Bob Gunton");
                Acteur WilliamS = new Acteur("William Sadler");
                Acteur AmandaS = new Acteur("Amanda Seyfried");
                Acteur StellanS = new Acteur("Stellan Skarsgård");
                Acteur PierceB = new Acteur("Pierce Brosnan");
                Acteur NancyB = new Acteur("Nancy Baldwin");
                Acteur AlanH = new Acteur("Alan Howard");
                Acteur NoelA = new Acteur("Noel Appleby");
                Acteur SeanA = new Acteur("Sean Astin");
                Acteur SalaB = new Acteur("Sala Baker");
                Acteur DanielC = new Acteur("Daniel Craig");
                Acteur JudiD = new Acteur("Judi Dench");
                Acteur JavierB = new Acteur("Javier Bardem");
                Acteur RalphF = new Acteur("Ralph Fiennes");
                Acteur JohnnyD = new Acteur("Johnny Depp");
                Acteur WinonaR = new Acteur("Winona Ryder");
                Acteur AnthonyMH = new Acteur("Anthony Michael Hall");
                Acteur GeoffreyR = new Acteur("Geoffrey Rush");
                Acteur OrlandoB = new Acteur("Orlando Bloom");
                Acteur KeiraK = new Acteur("Keira Knightley");
                Acteur HarryC = new Acteur("Harry Connick Jr.");
                Acteur AshleyJ = new Acteur("Ashley Judd");
                Acteur NathanG = new Acteur("Nathan Gamble");
                Acteur KrisK = new Acteur("Kris Kristofferson");
                #endregion
                _dbFilmContext.Acteurs.AddRange(LeonardoDC, KateW, KathyB, BillyZ, KevinB, LoriS, JohnL, DianneW, BarretO, GeraldMcR, ChrisE,
                   DarrylC, TimR, MorganF, BobG,WilliamS, AmandaS, StellanS, PierceB, NancyB, AlanH, NoelA, SeanA, SalaB, DanielC, JudiD, JavierB, RalphF,
                   JohnnyD, WinonaR, AnthonyMH, GeoffreyR, OrlandoB, KeiraK, HarryC, AshleyJ, NathanG, KrisK);
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
                Schrijver FrankD = new Schrijver("Frank Darabont");
                Schrijver CatherineJ = new Schrijver("Catherine Johnson");
                Schrijver JRRT= new Schrijver("J.R.R. Tolkien");
                Schrijver NealP = new Schrijver("Neal Purvis");
                Schrijver RobertW = new Schrijver("Robert Wade");
                Schrijver JohnLogan = new Schrijver("John Logan");
                Schrijver TimB = new Schrijver("Tim Burton");
                Schrijver CarolineT = new Schrijver("Caroline Thompson");
                Schrijver TedE = new Schrijver("Ted Elliott");
                Schrijver TerryR = new Schrijver("Terry Rossio");
                Schrijver StuartB = new Schrijver("Stuart Beattie");
                Schrijver JayW = new Schrijver("Jay Wolpert");
                Schrijver KarenJ = new Schrijver("Karen Janszen");
                Schrijver NoamD = new Schrijver("Noam Dromi");
               
                #endregion
                _dbFilmContext.Schrijvers.AddRange(new Schrijver[] { JamesC, DeanP, GeorgeL, WolfgangP, HermanW, FrankD, CatherineJ, JRRT, NealP, RobertW, JohnLogan,
                TimB, CarolineT, TedE, TerryR, StuartB, JayW, KarenJ, NoamD});
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
                _dbFilmContext.Films.Add(Footloose);
                FilmGenre fg3 = new FilmGenre(Footloose, Drama);
                FilmGenre fg4 = new FilmGenre(Footloose, Romantiek);
                FilmGenre fg5 = new FilmGenre(Footloose, Musical);
                FilmGenre fg6 = new FilmGenre(Footloose, Muziek);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg3, fg4, fg5, fg6});
                _dbFilmContext.SaveChanges();       
                FilmActeur fa5 = new FilmActeur(Footloose, KevinB);
                FilmActeur fa6 = new FilmActeur(Footloose, LoriS);
                FilmActeur fa7 = new FilmActeur(Footloose, JohnL);
                FilmActeur fa8 = new FilmActeur(Footloose, DianneW);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa5, fa6, fa7, fa8 });
                _dbFilmContext.SaveChanges();
                FilmSchrijver fs2 = new FilmSchrijver(Footloose, DeanP);
                _dbFilmContext.FilmSchrijvers.Add(fs2);
                _dbFilmContext.SaveChanges();

                Film StarWarsEIV = new Film("Star Wars, Episode IV - A New Hope", 1977, 121, "George Lucas", 
                    "Luke Skywalker werkt op het land bij z'n oom en tante op de planeet Tatooine. Als zij door Keizerlijke troepen worden vermoord, sluit Luke zich aan bij de groep rebellen die vecht tegen de tirannie van de Keizer en de slechte Darth Vader. " +
                    "Luke, Princess Leia, Han Solo en de andere rebellen doen een poging de Death Star, het nieuwe wapen van de Keizer, te vernietigen.", "20th Century Fox");
                _dbFilmContext.Films.Add(StarWarsEIV);
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
                       
                Film TheNeverEndingStory = new Film("The NeverEnding Story", 1984,102, "Wolfgang Petersen",
                   "Shy, awkward Bastian is amazed to discover that he has become a character in the mysterious book he is reading and that he has an important mission to fulfill.", "Warner Home Video");
                _dbFilmContext.Films.Add(TheNeverEndingStory);
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

                Film TheShawshankRedemption = new Film("The Shawshank Redemption",1994, 142,  "Frank Darabont",
                     "Andy Dufresne (Tim Robbins) wordt beschuldigd van de moord op zijn vrouw en haar minnaar. Hij houdt vol dat hij onschuldig is, maar krijgt toch tweemaal levenslang in de strenge gevangenis Shawshank." +
                     " Hij raakt bevriend met de zwarte medegevangene Ellis Boyd Redding (Morgan Freeman), die voor iedereen spullen kan regelen en de bijnaam 'Red' heeft. En er zijn nog twee dingen die Andy op de been houden: hoop en een poster van Rita Hayworth.", "Columbia Pictures");
                _dbFilmContext.Films.Add(TheShawshankRedemption);
                FilmGenre fg15 = new FilmGenre(TheShawshankRedemption, Drama);
                _dbFilmContext.FilmGenres.Add(fg15);
                _dbFilmContext.SaveChanges();
                FilmActeur fa17 = new FilmActeur(TheShawshankRedemption, TimR);
                FilmActeur fa18 = new FilmActeur(TheShawshankRedemption, MorganF);
                FilmActeur fa19 = new FilmActeur(TheShawshankRedemption, BobG);
                FilmActeur fa20 = new FilmActeur(TheShawshankRedemption, WilliamS);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa17, fa18, fa19, fa20 });
                _dbFilmContext.SaveChanges();              
                FilmSchrijver fs6 = new FilmSchrijver(TheShawshankRedemption, FrankD);
                _dbFilmContext.FilmSchrijvers.Add(fs6 );
                _dbFilmContext.SaveChanges();

                Film MammaMia = new Film("Mamma Mia!", 2008, 108, "Phyllida Lloyd",
                    "Donna, een onafhankelijke, single moeder heeft een hotelletje op een idyllisch Grieks eiland. Ze staat op het punt om Sophie, de pittige dochter die ze alleen heeft grootgebracht, los te laten." +
                    " Voor Sophie's huwelijk heeft Donna haar twee oude hartsvrienden uitgenodigd: de praktische en no-nonsense Rosie en de rijke, meermalen gescheiden Tanya van haar vroegere backing-band 'Donna and the Dynamos'." +
                    " Maar Sophie heeft in het geheim zelf drie gasten uitgenodigd. " +
                    "Ze is op zoek gegaan naar de identiteit van haar vader die haar naar het altaar moet begeleiden en ze haalt drie mannen uit Donna's verleden naar het mediterrane paradijs waar ze 20 jaar daarvoor waren geweest." +
                    " In de 24 chaotische, magische uren bloeit er nieuwe liefde op en oude romances vatten opnieuw vlam op dit weelderige eiland vol mogelijkheden.", "Universal Pictures");
                _dbFilmContext.Films.Add(MammaMia);
                FilmGenre fg16 = new FilmGenre(MammaMia, Romantiek);
                FilmGenre fg17 = new FilmGenre(MammaMia, Komedie);
                FilmGenre fg18 = new FilmGenre(MammaMia, Musical);
                FilmGenre fg19 = new FilmGenre(MammaMia, Muziek);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg16, fg17, fg18, fg19 });
                _dbFilmContext.SaveChanges();
                FilmSchrijver fs7 = new FilmSchrijver(MammaMia, CatherineJ);
                _dbFilmContext.FilmSchrijvers.Add(fs7);
                _dbFilmContext.SaveChanges();
                FilmActeur fa21 = new FilmActeur(MammaMia, AmandaS);
                FilmActeur fa22 = new FilmActeur(MammaMia, StellanS);
                FilmActeur fa23 = new FilmActeur(MammaMia, PierceB);
                FilmActeur fa24 = new FilmActeur(MammaMia, NancyB);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa21, fa22, fa23, fa24 });
                _dbFilmContext.SaveChanges();
              
                 Film TheLordOfTheRings1 = new Film("The Lord of the Rings, The Fellowship of the Ring", 2001, 178, "Peter Jackson",
                    "Een eeuwenoude ring, die jaren zoek is geweest, wordt gevonden en komt bij toeval terecht bij de kleine Hobbit Frodo." +
                    " Als de tovenaar Gandalf erachter komt dat deze ring eigenlijk de Ene Ring is waar de slechte Sauron naar op zoek is, gaat Frodo samen met Gandalf, een Dwerg, een Elf, twee Mensen en drie andere Hobbits op een groots avontuur om deze te vernietigen.", "New Line Cinema");
                _dbFilmContext.Films.Add(TheLordOfTheRings1);
                FilmGenre fg20 = new FilmGenre(TheLordOfTheRings1, Avontuur);
                FilmGenre fg21 = new FilmGenre(TheLordOfTheRings1, Actie);
                FilmGenre fg22 = new FilmGenre(TheLordOfTheRings1, Fantasie);
                FilmGenre fg23 = new FilmGenre(TheLordOfTheRings1, Drama);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg20, fg21, fg22, fg23 });
                _dbFilmContext.SaveChanges();
                FilmSchrijver fs8 = new FilmSchrijver(TheLordOfTheRings1, JRRT);
                _dbFilmContext.FilmSchrijvers.Add(fs8);
                _dbFilmContext.SaveChanges();
                FilmActeur fa25 = new FilmActeur(TheLordOfTheRings1, AlanH);
                FilmActeur fa26 = new FilmActeur(TheLordOfTheRings1, NoelA);
                FilmActeur fa27 = new FilmActeur(TheLordOfTheRings1, SeanA);
                FilmActeur fa28 = new FilmActeur(TheLordOfTheRings1, SalaB);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa25, fa26, fa27, fa28 });
                _dbFilmContext.SaveChanges();

                Film Skyfall = new Film("Skyfall", 2012,  143,  "Sam Mendes", "Bonds loyaliteit aan M wordt op de proef gesteld als ze achtervolgd wordt door haar verleden." +
                    " Als de MI6 vervolgens onder vuur komt te liggen is Bond genoodzaakt de bedreiging op te sporen en te vernietigen, ongeacht de hoge persoonlijke prijs die dit met zich mee brengt.", 
                    "MGM");
                _dbFilmContext.Films.Add(Skyfall);
                FilmGenre fg24 = new FilmGenre(Skyfall, Avontuur);
                FilmGenre fg25 = new FilmGenre(Skyfall, Thriller);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] {fg24, fg25 });
                _dbFilmContext.SaveChanges();
                FilmSchrijver fs9= new FilmSchrijver(Skyfall, NealP);
                FilmSchrijver fs10 = new FilmSchrijver(Skyfall, RobertW);
                FilmSchrijver fs11 = new FilmSchrijver(Skyfall, JohnLogan);
                _dbFilmContext.FilmSchrijvers.AddRange(new FilmSchrijver[] { fs9, fs10, fs11 });
                _dbFilmContext.SaveChanges();
                FilmActeur fa29 = new FilmActeur(Skyfall, DanielC);
                FilmActeur fa30 = new FilmActeur(Skyfall, JudiD);
                FilmActeur fa31 = new FilmActeur(Skyfall, JavierB);
                FilmActeur fa32 = new FilmActeur(Skyfall, RalphF);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa29, fa30, fa31, fa32 });
                _dbFilmContext.SaveChanges();

                 Film EdwardScissorhands = new Film("Edward Scissorhands", 1990, 105,  /*new List<string> {"Romantiek", "Drama", "Fantasie"}, new List<string> { "Johnny Depp", "Winona Ryder", "Dianne Wiest", "Anthony Michael Hall" }, */ "Tim Burton", /*new List<string> { "Tim Burton", "Caroline Thompson" },*/
                    "Edward is gecreëerd door een uitvinder, die echter stierf voor hij z'n karwei af kon maken. Hierdoor heeft Edward scharen waar eigenlijk zijn handen zouden moeten zitten. Wanneer een vrouw bij zijn grote landhuis aanbelt en hem daar vindt, neemt ze hem mee naar haar huis om bij haar familie te wonen. Al snel weet hij zich aan te passen aan de voor hem ongewone omgeving.", "20th Century Fox");
                _dbFilmContext.Films.Add(EdwardScissorhands);
                FilmGenre fg26 = new FilmGenre(EdwardScissorhands, Drama);
                FilmGenre fg27 = new FilmGenre(EdwardScissorhands, Romantiek);
                FilmGenre fg28 = new FilmGenre(EdwardScissorhands, Fantasie);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg26, fg27, fg28 });
                _dbFilmContext.SaveChanges();
                FilmSchrijver fs12 = new FilmSchrijver(EdwardScissorhands, TimB);
                FilmSchrijver fs13 = new FilmSchrijver(EdwardScissorhands, CarolineT);
                _dbFilmContext.FilmSchrijvers.AddRange(new FilmSchrijver[] { fs12, fs13});
                _dbFilmContext.SaveChanges();
                FilmActeur fa33 = new FilmActeur(EdwardScissorhands, JohnnyD);
                FilmActeur fa34 = new FilmActeur(EdwardScissorhands, WinonaR);
                FilmActeur fa35 = new FilmActeur(EdwardScissorhands, DianneW);
                FilmActeur fa36 = new FilmActeur(EdwardScissorhands, AnthonyMH);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa33, fa34, fa35, fa36 });
                _dbFilmContext.SaveChanges();

               Film PiratesOfTheCaribbeanI = new Film("Pirates of the Caribbean, The Curse of the Black Pearl",2003,  143,"Gore Verbinski", 
                    "Jack Sparrow, de afgedankte kapitein van het beroemde spookschip The Black Pearl, wil zijn schip terug. De nieuwe kapitein, Barbossa, ontvoert Elizabeth Swann tijdens één van hun veroveringen, omdat Elizabeth de enige lijkt die er voor kan zorgen dat de vloek van Cortez, die op Barbossa en zijn crew rust, wordt opgeheven. " +
                     "De ware persoon die de vloek kan opheffen is echter Will Turner, die smoorverliefd is op Elizabeth. En dus schakelt Will, om Elizabeth te redden, de enige in die de thuishaven van The Black Pearl kent: Kapitein Jack Sparrow.", "Buena Vista Pictures");
                _dbFilmContext.Films.Add(PiratesOfTheCaribbeanI);
                FilmGenre fg29 = new FilmGenre(PiratesOfTheCaribbeanI, Avontuur);
                FilmGenre fg30 = new FilmGenre(PiratesOfTheCaribbeanI, Actie);
                FilmGenre fg31 = new FilmGenre(PiratesOfTheCaribbeanI, Fantasie);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg29, fg30, fg31 });
                _dbFilmContext.SaveChanges();
                FilmSchrijver fs14 = new FilmSchrijver(PiratesOfTheCaribbeanI, TedE);
                FilmSchrijver fs15 = new FilmSchrijver(PiratesOfTheCaribbeanI, TerryR);
                FilmSchrijver fs16 = new FilmSchrijver(PiratesOfTheCaribbeanI, StuartB);
                FilmSchrijver fs17 = new FilmSchrijver(PiratesOfTheCaribbeanI, JayW);
                _dbFilmContext.FilmSchrijvers.AddRange(new FilmSchrijver[] { fs14, fs15, fs16,fs17 });
                _dbFilmContext.SaveChanges();
                FilmActeur fa37 = new FilmActeur(PiratesOfTheCaribbeanI, JohnnyD);
                FilmActeur fa38 = new FilmActeur(PiratesOfTheCaribbeanI, GeoffreyR);
                FilmActeur fa39 = new FilmActeur(PiratesOfTheCaribbeanI, OrlandoB);
                FilmActeur fa40 = new FilmActeur(PiratesOfTheCaribbeanI, KeiraK);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa37, fa38, fa39, fa40 });
                _dbFilmContext.SaveChanges();

                Film DolphinTale = new Film("Dolphin Tale", 2011, 113, "Charles Martin Smith",
                   "Een jongen raakt bevriend met Winter, een gewonde dolfijn die zijn staart verloren is in een krabbenval." +
                   " Hij probeert iedereen om zich heen te motiveren om de dolfijn te redden. De dierenarts Clay redt de dolfijn en brengt hem naar zijn hospitaal. " +
                   "Hier proberen ze samen met een dokter (Morgan Freeman) een prothese te maken om de staart te vervangen en zo de dolfijn te redden.", "Warner Bros.Pictures");
                _dbFilmContext.Films.Add(DolphinTale);
                FilmGenre fg32 = new FilmGenre(DolphinTale, Familie);
                FilmGenre fg33 = new FilmGenre(DolphinTale, Drama);
                _dbFilmContext.FilmGenres.AddRange(new FilmGenre[] { fg32, fg33});
                _dbFilmContext.SaveChanges();
                FilmSchrijver fs18 = new FilmSchrijver(DolphinTale, KarenJ);
                FilmSchrijver fs19 = new FilmSchrijver(DolphinTale, NoamD);
                _dbFilmContext.FilmSchrijvers.AddRange(new FilmSchrijver[] { fs18, fs19 });
                _dbFilmContext.SaveChanges();
                FilmActeur fa41 = new FilmActeur(DolphinTale, HarryC);
                FilmActeur fa42 = new FilmActeur(DolphinTale, AshleyJ);
                FilmActeur fa43 = new FilmActeur(DolphinTale, NathanG);
                FilmActeur fa44 = new FilmActeur(DolphinTale, KrisK);
                _dbFilmContext.FilmActeurs.AddRange(new FilmActeur[] { fa41, fa42, fa43, fa44 });
                _dbFilmContext.SaveChanges();

                FilmGebruiker fgebruiker = new FilmGebruiker(Titanic, admin);
                _dbFilmContext.FilmGebruikers.Add(fgebruiker);
                Titanic.FilmGebruikers.Add(fgebruiker);
                admin.FilmGebruikers.Add(fgebruiker);
                Titanic.AantalDuimenOmhoog++;
                _dbFilmContext.SaveChanges();
            }
        }

        private async Task AanmakenGebruiker(string mailadres, string wachtwoord)
        { 
         //   var claims = new List<Claim>() { };
              var user = new IdentityUser { UserName = mailadres, Email = mailadres };
            await _userManager.CreateAsync(user, wachtwoord);
          //  var gebruiker1 = new IdentityUser { UserName = gebruiker.Mailadres, Email = gebruiker.Mailadres };
            //await _userManager.AddLoginAsync(gebruiker1, null);
          /* await _userManager.CreateAsync(gebruiker1, "W@chtwoord1");
           await _userManager.AddClaimAsync(gebruiker1, new Claim(ClaimTypes.Role, "Gebruiker"));
           var roleClaims1 = await _userManager.GetClaimsAsync(gebruiker1);
            claims.AddRange(roleClaims1);
         
            var admin1 = new IdentityUser { UserName = admin.Mailadres, Email = admin.Mailadres };
            //await _userManager.AddLoginAsync(admin1, null);
            await _userManager.CreateAsync(admin1, "W@chtwoord2");
            await _userManager.AddClaimAsync(admin1, new Claim(ClaimTypes.Role, "Admin"));
            var roleClaims2 = await _userManager.GetClaimsAsync(admin1);
            claims.AddRange(roleClaims2);*/
            


            // new IdentityUser[] { gebruiker1, admin1 };


        }
    }
}

