using FluentValidation;
using Locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {

        public UsuarioValidation()
        {
            RuleFor(u => u.Nome)
                .NotNull()
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado!")
                .Length(min:2, max:100).WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracters!");


            RuleFor(u => u.Telefone)
                .NotNull()
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado!")
                .Length(min: 11, max: 20).WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracters!");


            RuleFor(u => u.email)
                  .NotNull()
                  .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser informado!")
                  .Length(min: 1, max: 100).WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracters!")
                  .EmailAddress().WithMessage("E-mail inválido!");

        }
    }
}
