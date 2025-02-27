using System.ComponentModel.DataAnnotations;

namespace Alterdata.TesteFullStackBackend.Api.V1.Requests.Product
{
    public sealed record ProductPutRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Name { get; init; } = null!;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero.")]
        public int Stock { get; init; }
    }
}
