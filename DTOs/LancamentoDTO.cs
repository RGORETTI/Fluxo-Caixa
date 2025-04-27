using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.DTOs
{
    public class LancamentoDto
    {
        [Required]
        public DateTime DataDeLancamento { get; set; }

        [Required]
        public int TipoDeLancamento { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Conta { get; set; }

        [Required]
        public string Banco { get; set; }

        [Required]
        public string TipoDeConta { get; set; }

        [Required]
        public string CpfCnpj { get; set; }

        [Required]
        public decimal ValorDoLancamento { get; set; }
    }
}