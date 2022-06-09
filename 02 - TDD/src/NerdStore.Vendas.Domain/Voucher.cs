using FluentValidation;
using FluentValidation.Results;
using System;

namespace NerdStore.Vendas.Domain
{
    public class Voucher
    {
        public string Codigo { get; private set; }

        public decimal? PercentualDesconto { get; private set; }

        public decimal? ValorDesconto { get; private set; }

        public TipoDescontoVoucher TipoDesconto { get; private set; }

        public int Quantidade { get; private set; }

        public DateTime DataValidade { get; private set; }

        public bool Ativo { get; private set; }

        public bool Utilizado { get; private set; }

        public Voucher(string codigo, decimal? percentualDesconto, decimal? valorDesconto, TipoDescontoVoucher tipoDesconto, int quantidade,
            DateTime dataValidade, bool ativo, bool utilizado)
        {
            Codigo = codigo;
            PercentualDesconto = percentualDesconto;
            ValorDesconto = valorDesconto;
            TipoDesconto = tipoDesconto;
            Quantidade = quantidade;
            DataValidade = dataValidade;
            Ativo = ativo;
            Utilizado = utilizado;
        }

        public ValidationResult ValidarSeAplicavel()
        {
            return new VoucherAplicavelValidation().Validate(this);
        }
    }

    public class VoucherAplicavelValidation : AbstractValidator<Voucher>
    {
        public static string CodigoErroMsg => "Voucher sem código válido.";
        public static string DataValidadeErroMsg => "Este voucher está expirado.";
        public static string  AtivoErroMsg => "Este voucher não é mais válido.";
        public static string UtilizadoErroMsg => "Este voucher já foi utilizado.";
        public static string QuantidadeErroMsg => "Este voucher não está mais disponível.";
        public static string ValorDescontoErroMsg => "O valor do desconto precisa ser superior à 0.";
        public static string PercentualDescontoErroMsg => "O valor da porcentagem de desconto precisa ser superior à 0.";

        public VoucherAplicavelValidation()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty()
                .WithMessage(CodigoErroMsg);

            RuleFor(c => c.DataValidade)
                .Must(DataVencimentoSuperiorAtual)
                .WithMessage(DataValidadeErroMsg);

            RuleFor(c => c.Ativo)
                .Equal(true)
                .WithMessage(AtivoErroMsg);

            RuleFor(c => c.Utilizado)
                .Equal(false)
                .WithMessage(UtilizadoErroMsg);


            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage(QuantidadeErroMsg);

            When(f => f.TipoDesconto == TipoDescontoVoucher.Porcentagem, () =>
            {
                RuleFor(f => f.PercentualDesconto)
                    .NotNull()
                    .WithMessage(PercentualDescontoErroMsg)
                    .GreaterThan(0)
                    .WithMessage(PercentualDescontoErroMsg);
            });

            When(f => f.TipoDesconto == TipoDescontoVoucher.Valor, () =>
            {
                RuleFor(f => f.ValorDesconto)
                    .NotNull()
                    .WithMessage(ValorDescontoErroMsg)
                    .GreaterThan(0)
                    .WithMessage(ValorDescontoErroMsg);
            });


        }

        private bool DataVencimentoSuperiorAtual(DateTime arg)
        {
            return arg > DateTime.Now;
        }
    }
}
