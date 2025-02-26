namespace Alterdata.TesteFullStackBackend.Application.DTOS
{
    public sealed record ClientDTO
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public string Email { get; init; } = null!;

        public string? PhoneNumber { get; init; }

        public bool Active { get; init; }
    }
}
