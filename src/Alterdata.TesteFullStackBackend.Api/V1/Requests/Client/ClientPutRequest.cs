using System.ComponentModel.DataAnnotations;

namespace Alterdata.TesteFullStackBackend.Api.V1.Requests.Client
{
    public sealed record ClientPutRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Name { get; init; } = null!;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        public string Email { get; init; } = null!;

        [RegularExpression(@"^\(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "O telefone deve estar no formato (XX) XXXXX-XXXX.")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "O telefone não pode ser maior que 15 caracteres.")]
        public string? PhoneNumber { get; init; }

        public bool Active { get; init; }
    }
}
