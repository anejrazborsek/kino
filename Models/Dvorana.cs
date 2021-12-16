using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Dvorana
    {
        
        public int DvoranaID { get; set; }
        [Display(Name = "Tip dvorane")]
        public string Dvorana_tip { get; set; }

        public ICollection<Predstava>? Predstave { get; set; }
         public ICollection<Sedez>? Sedezi{ get; set; }
    }
}