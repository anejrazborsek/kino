using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace web.Models
{

    public class Sedez
    {
        [Display(Name = "Sedež")]
        public int SedezID { get; set; }
        [Display(Name = "Tip sedeža")]
        public string Sedez_tip { get; set; }

        public int DvoranaID { get; set; }                
        public Dvorana? Dvorana { get; set; }
       
    }
}