using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.Models
{
    public class Lancamento
    {
        [BsonId] // Informa ao MongoDB que esta propriedade é o _id
        [BsonRepresentation(BsonType.ObjectId)] // Permite que seja tratado como string
        public string Id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public TipoLancamento TipoDeLancamento { get; set; }

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
        public decimal Valor { get; set; }
    }
}
