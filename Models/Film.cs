using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Film
    {
        public int FilmID { get; set; }
         [Display(Name = "Ime filma")]
        public string Film_ime { get; set; }
         [Display(Name = "Trajanje filma")]
        public int Film_trajanje { get; set; }
         [Display(Name = "Režiser filma")]
        public string Film_reziser { get; set; }
         [Display(Name = "Opis")]
        public string Film_opis { get; set; }
         [Display(Name = "Slika")]
        public string Film_img { get; set; }

        // ne tuji ključ, ampak smzd da to rabi
        //public ICollection<Predstava>? Predstave { get; set; }
    }
}