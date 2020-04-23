﻿using FluentValidation;
using FluentValidation.Results;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Domain.Notificacoes;

namespace Locadora.Domain.Services
{
    public  abstract class BaseService
    {

        private readonly INotificador _notificador;


        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }


        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }

        }
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }


        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
