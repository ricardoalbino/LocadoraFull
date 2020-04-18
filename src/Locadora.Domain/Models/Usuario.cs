using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Domain.Models
{
    public class Usuario : Entity
    {
        

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractees", MinimumLength = 2)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(12, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractees", MinimumLength = 10)]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractees", MinimumLength = 5)]
        public string email { get; set; }

        //public virtual IEnumerable<Filme> Filmes { get; set; }

        //public Locacao locacao { get; set; }


    }
}
