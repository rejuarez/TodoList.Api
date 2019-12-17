using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core;
using Todo.Core.Models;
namespace Todo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetById(int Id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(Id);
        }
    }
}
