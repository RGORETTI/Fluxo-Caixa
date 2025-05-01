namespace FluxoCaixa.DTOs
{
    public class LancamentoDto
    {
        public DateTime Data { get; set; }

        public int TipoDeLancamento { get; set; }

        public string Descricao { get; set; }

        public string Conta { get; set; }

        public string Banco { get; set; }

        public string TipoDeConta { get; set; }

        public string CpfCnpj { get; set; }

        public decimal Valor { get; set; }
    }
}
