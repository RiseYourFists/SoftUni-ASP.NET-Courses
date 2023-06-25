using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Services.Models.Product;

namespace WebShop.Services.Contracts
{
    public interface IProductService
    {
        public Task Add(AddProductDto product);
        public Task<bool> Delete(Guid id);
        public ICollection<ListProductDto> GetAll();
        public Task<ICollection<ListProductDto>> GetAll(Func<ListProductDto, bool> predicate);
        public Task<ProductInfoDto> GetById(Guid id);
    }
}
