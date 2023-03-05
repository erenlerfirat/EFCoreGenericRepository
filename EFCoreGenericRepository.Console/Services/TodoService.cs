using EFCoreGenericRepository.Console.Models;
using EFCoreGenericRepository.Console.RepositoryBase.GenericRepository;
using EFCoreGenericRepository.Console.RepositoryBase.QueryRepository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGenericRepository.Console.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository _repository;

        public TodoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Todo>> GetPaginatedListAsync()
        {
            Specification<Todo> specification = new Specification<Todo>();
            //specification.Conditions.Add(e => e.TodoName.Contains("Ta"));
            //specification.Includes = q => q.Include(e =>e.Name);
            specification.OrderBy = q => q.OrderBy(e => e.TodoName);
            specification.Skip = 0;
            specification.Take = 4;

            //long count = await _repository.GetLongCountAsync(specification.Conditions);

            List<Todo> paginatedList = await _repository.GetListAsync(specification);

            return paginatedList;
        }
    }
}
