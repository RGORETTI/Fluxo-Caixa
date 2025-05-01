using FluentValidation;
using FluxoCaixa.DTOs;
using FluxoCaixa.Utils;
using System;

namespace FluxoCaixa.Validators
{
    public class LancamentoDtoValidator : AbstractValidator<LancamentoDto>
    {
        public LancamentoDtoValidator()
        {
            RuleFor(x => x.Data)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Não é permitido lançar com data no passado.");

            RuleFor(x => x.TipoDeLancamento)
                .Must(t => t == 1 || t == 2)
                .WithMessage("Tipo de lançamento inválido. Use 1 (Recebimento) ou 2 (Pagamento).");

            RuleFor(x => x.Conta)
                 .NotEmpty().WithMessage("Conta é obrigatória.")
                 .Must(NotWhitespace).WithMessage("Conta não pode ser vazia.")
                 .Must(v => v.ToLower() != "string").WithMessage("Campo 'Conta' não pode conter valor genérico como 'string'.");

            RuleFor(x => x.Banco)
                .NotEmpty().WithMessage("Banco é obrigatório.")
                .Must(NotWhitespace).WithMessage("Banco não pode ser vazio.")
                .Must(v => v.ToLower() != "string").WithMessage("Campo 'Banco' não pode conter valor genérico como 'string'.");


            RuleFor(x => x.TipoDeConta)
                .NotEmpty().WithMessage("Tipo de conta é obrigatório.")
                .Must(NotWhitespace).WithMessage("Tipo de conta não pode ser vazio.");

            RuleFor(x => x.CpfCnpj)
                 .NotEmpty().WithMessage("CPF/CNPJ é obrigatório.")
                 .Must(NotWhitespace).WithMessage("CPF/CNPJ não pode ser vazio.")
                 .Must(CpfCnpjUtils.EhCpfOuCnpjValido).WithMessage("CPF ou CNPJ inválido.");

            // Descrição e Valor são opcionais — validados em outra camada
        }

        private bool NotWhitespace(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
