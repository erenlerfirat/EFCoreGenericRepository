using EFCoreGenericRepository.Console.Models;
using EFCoreGenericRepository.Console.RepositoryBase.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGenericRepository.Console.RepositoryBase.Concrete
{
    public class AuthourRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthourRepository(DbContext context) : base(context)
        {
        }
    }
}
