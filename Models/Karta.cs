using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace web.Models
{

    public class Karta
    {
        public int KartaID { get; set; }
        [Display(Name = "Cena karte")]
        public double Karta_cena { get; set; }

        public int PredstavaID { get; set; }                
        public Predstava? Predstava { get; set; }
       
    }
}