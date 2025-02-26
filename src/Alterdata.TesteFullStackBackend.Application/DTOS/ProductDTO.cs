namespace Alterdata.TesteFullStackBackend.Application.DTOS
{
    public sealed record ProductDTO
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public decimal Price { get; init; }

        public int Stock { get; init; }
    }
}
