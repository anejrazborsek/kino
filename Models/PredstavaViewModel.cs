using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models.PredstavaViewModels
{
    public class PredstavaIndexData
    {
        public IEnumerable<Film> Filmi { get; set; }
        public IEnumerable<Dvorana> Dvorane { get; set; }

        
    }
}