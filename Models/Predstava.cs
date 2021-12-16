using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace web.Models
{
    
    public class Predstava
    {
        public int PredstavaID { get; set; }
         [Display(Name = "Čas predstave")]
        public string Predstava_cas { get; set; }
        public int FilmID { get; set; }
        public int DvoranaID { get; set; }
        
        // reference smzd
        public Film? Film { get; set; }
        
        public Dvorana? Dvorana { get; set; }

    }
}