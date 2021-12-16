using web.Models;
using System;
using System.Linq;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KinoContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students
            if (context.Filmi.Any())
            {
                return;   // DB has been seeded
            }

            var Filmi = new Film[]
            {
            new Film{Film_ime="James Bond",Film_trajanje=165,Film_reziser="Režiser: Cary Joji Fukunaga",Film_opis="Občutite val adrenalina z najbolj priljubljenim vohunom. Zdaj ni čas za smrt, čas je, da si ogledate film.",Film_img="Images/james_bond.jpg"},
            new Film{Film_ime="Levji Kralj",Film_trajanje=96,Film_reziser="Režiser: Walt Disney",Film_opis="Najlepši družinski risani film leta 1994.",Film_img="Images/lion_king.jpg"},
            new Film{Film_ime="Terminator",Film_trajanje=140,Film_reziser="Režiser: James Cameron",Film_opis="Schwarzenegger gre v preteklost v tej akcijski pustolovščini, polni akcije in vprašanj o potovanju skozi čas.",Film_img="Images/terminator.jpg"},
            new Film{Film_ime="Matrix",Film_trajanje=125,Film_reziser="Režiser: Lana Wachowski",Film_opis="Ste res prepričani, da svet okoli vas ni le računalniška simulacija? Odkrijte nove dimenzije resničnosti v tej 2006 uspešnici.",Film_img="Images/matrix.jpg"},    
            new Film{Film_ime="Star Wars",Film_trajanje=100,Film_reziser="Režiser: George Lucas",Film_opis="Klasične vojne zvezd se vračajo v kinematografe v še bolj spektakularni prequel trilogiji.",Film_img="Images/star_wars.jpg"},    
            new Film{Film_ime="Neon Genesis Evangelion",Film_trajanje=135,Film_reziser="Režiser: Hideaki Anno",Film_opis="Ste si kdaj želeli videti bitke med vesoljci in roboti, hkrati pa se spraševali o pomenu življenja? Raziščite življenje skozi bitke robotskih vesoljcev in psihičnega trpljenja njihovih pilotov.",Film_img="Images/neon_genesis.jpg"},
            };
            
            context.Filmi.AddRange(Filmi);
            context.SaveChanges();

            var Dvorane = new Dvorana[]
            {
            new Dvorana{Dvorana_tip="Mala"},
            new Dvorana{Dvorana_tip="Mala"},
            new Dvorana{Dvorana_tip="Velika"},
            new Dvorana{Dvorana_tip="Velika"},
            new Dvorana{Dvorana_tip="Mala"},
            };
            
            context.Dvorane.AddRange(Dvorane);
            context.SaveChanges();

            var Predstave = new Predstava[]
            {
            new Predstava{FilmID=1,DvoranaID=1,Predstava_cas="Torek - 18:00"},
            new Predstava{FilmID=1,DvoranaID=1,Predstava_cas="Torek - 21:00"},
            new Predstava{FilmID=3,DvoranaID=2,Predstava_cas="Torek - 19:00"},
            new Predstava{FilmID=2,DvoranaID=3,Predstava_cas="Sreda - 22:00"},
            new Predstava{FilmID=4,DvoranaID=2,Predstava_cas="Sreda - 20:00"},
            

            };
            
            context.Predstave.AddRange(Predstave);
            context.SaveChanges();


            var Sedezi = new Sedez[]
            {
            new Sedez{DvoranaID=1,Sedez_tip="Navaden"},
            new Sedez{DvoranaID=1,Sedez_tip="Navaden"},
            new Sedez{DvoranaID=1,Sedez_tip="Navaden"},
            new Sedez{DvoranaID=1,Sedez_tip="Navaden"},            
            new Sedez{DvoranaID=1,Sedez_tip="Navaden"},
            new Sedez{DvoranaID=1,Sedez_tip="VIP"},
            new Sedez{DvoranaID=1,Sedez_tip="VIP"},
            new Sedez{DvoranaID=1,Sedez_tip="VIP"},
            
            new Sedez{DvoranaID=2,Sedez_tip="Navaden"},
            new Sedez{DvoranaID=2,Sedez_tip="Navaden"},
            new Sedez{DvoranaID=2,Sedez_tip="Navaden"},
            new Sedez{DvoranaID=2,Sedez_tip="VIP"},            
            new Sedez{DvoranaID=2,Sedez_tip="VIP"},
            new Sedez{DvoranaID=2,Sedez_tip="VIP"},
            new Sedez{DvoranaID=2,Sedez_tip="VIP"},
            new Sedez{DvoranaID=2,Sedez_tip="VIP"},

            };
            
            context.Sedezi.AddRange(Sedezi);
            context.SaveChanges();



            var Karte = new Karta[]
            {
            new Karta{PredstavaID=1,Karta_cena=7.00},
            new Karta{PredstavaID=1,Karta_cena=13.80},
            new Karta{PredstavaID=2,Karta_cena=19.90},
            new Karta{PredstavaID=3,Karta_cena=12.00},
            
            };
            
            context.Karte.AddRange(Karte);
            context.SaveChanges();


        }
    }
}