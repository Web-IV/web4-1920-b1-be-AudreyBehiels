# Webapplicatie_IV Backend Audrey Behiels

# screenshots van de API
Film API Swagger
![Alt text](Screenshots/Film_API_Swagger.png)

GET api/Films
![Alt text](Screenshots/GETAlleFilms.png)

GET api/Films/GetGenres
![Alt text](Screenshots/GETGenres.png)

GET api/Films/GetFilmsByTitel/{titel}
![Alt text](Screenshots/GETFilmsByTitel.png)

GET api/Films/GetFilmsByJaar/{jaar}
![Alt text](Screenshots/GETFilmsByJaar.png)

GET api/Films/GetFilmsByGenre/{genre}
![Alt text](Screenshots/GETFilmsByGenre.png)

POST api/Gebruiker
![Alt text](Screenshots/POST_InloggenGebruiker.png)

POST api/Gebruiker/registreer
![Alt text](Screenshots/POST_RegistrerenGebruiker.png)

PUT api/Gebruiker/VoegDuimToe/{filmtitel}
![Alt text](Screenshots/PUT_VoegDuimToe.png)

PUT api/Gebruiker/VerwijderDuim/{filmtitel}
![Alt text](Screenshots/PUT_VerwijderDuim.png)

# screenshots Klassendiagram
![Alt text](Screenshots/Klassendiagram.png)
![Alt text](Screenshots/Repo_Controller.png)

# de readme
- [x] Printscreen van de API zoals weergegeven in swagger. Per endpoint een printscreen van de parameters en de responses
- [x] Printscreen van het klassendiagram van de domeinlaag (toont de klassen met properties en methodes (inclusief de datatypes) en de associaties)
- [x] Opsomming van de instellingen die nodig zijn om je backend project lokaal te runnen, indien nodig
- [ ] Voorbereiding feedback moment: 
      - Ik zou graag willen weten of mijn domeinlaag en mijn controllerklasse goed zijn
      - 
# Domein laag
- [x] Het domein bevat minstens 2 geassocieerde klassen
- [x] Klassen bevatten toestand en gedrag
- [x] Klassendiagram is aangemaakt, toont de properties, methodes en de associaties

# Data laag
- [x] DataContext is aangemaakt
- [x] Mapping is geïmplementeerd (a.d.h.v. Mapper klassen)
- [x] Databank wordt geseed met data (via initializer)

# Controller
- [x] Minstens 1 controller met endpoints voor de CRUD operaties
- [ ] De endpoints zijn gedefinieerd volgens de best practices
- [x] Enkel de benodigde data wordt uitgewisseld (DTO’s indien nodig)

# Swagger
- [x] De documentatie is opgesteld
