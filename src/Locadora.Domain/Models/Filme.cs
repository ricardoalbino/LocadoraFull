using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Domain.Models
{
    public class Filme : Entity
    {
      
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractees", MinimumLength = 2)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractees", MinimumLength = 2)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public DateTime DataLançamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public decimal ValorLocacao { get; set; }


        //public Locacao locacao { get; set; }

        /* EF  - RELACIONAMENTOS - FILME  TEM 1  USUARIO */
        //public Guid UsuarioID { get; set; }
        //public Usuario Usuario { get; set; }

        //public IEnumerable<Usuario> Usuarios { get; set; }



    }
}
