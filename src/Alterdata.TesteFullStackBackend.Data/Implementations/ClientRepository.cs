using Alterdata.TesteFullstackBackend.Core.Entities;
using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Data.Context;

namespace Alterdata.TesteFullStackBackend.Data.Implementations
{
    public sealed class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DbMemoryContext dbMemoryContext) : base(dbMemoryContext)
        {
        }
    }
}
