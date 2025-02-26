using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Data.Context;

namespace Alterdata.TesteFullStackBackend.Data.Implementations
{
    public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DbMemoryContext dbMemoryContext) : base(dbMemoryContext)
        {
        }
    }
}
