using EFCoreGenericRepository.Console.Models;

namespace EFCoreGenericRepository.Console.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetPaginatedListAsync();
    }
}
