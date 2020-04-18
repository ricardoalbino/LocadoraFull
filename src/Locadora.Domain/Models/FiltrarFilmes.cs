using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Models
{
    public class FiltrarFilmes
    {  
        public string  Nome { get; set; }

        public string Genero { get; set; }

        public DateTime? DataLançamento { get; set; }

    }
}
