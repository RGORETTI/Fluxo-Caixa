// Models/FluxoCaixaDia.cs
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Models
{
    /// <summary>
    /// Representa o fluxo de caixa de um dia específico, contendo entradas, saídas e saldo.
    /// </summary>
    public class FluxoCaixaDia
    {
        /// <summary>
        /// Data referente ao fluxo de caixa (formato dd-MM-aaaa).
        /// </summary>
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// Lista de entradas financeiras do dia.
        /// </summary>
        public List<LancamentoResumo> Entradas { get; set; } = new();

        /// <summary>
        /// Lista de saídas financeiras do dia.
        /// </summary>
        public List<LancamentoResumo> Saidas { get; set; } = new();

        /// <summary>
        /// Total de entradas menos saídas no dia (formato monetário).
        /// </summary>
        public string Total { get; set; } = string.Empty;

        /// <summary>
        /// Posição do saldo do dia em relação ao dia anterior, em percentual.
        /// </summary>
        public string PosicaoDoDia { get; set; } = string.Empty;
    }

    /// <summary>
    /// Representa um resumo de lançamento financeiro (entrada ou saída) no fluxo de caixa.
    /// </summary>
    public class LancamentoResumo
    {
        /// <summary>
        /// Data em que o lançamento foi realizado (formato dd-MM-aaaa).
        /// </summary>
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// Valor do lançamento no formato monetário.
        /// </summary>
        public string Valor { get; set; } = string.Empty;
    }
}
