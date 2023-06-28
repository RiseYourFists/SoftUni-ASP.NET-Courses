using AutoMapper;
using AutoMapper.QueryableExtensions;
using WebShop.Core.Data.Common;
using WebShop.Core.Models;
using WebShop.Services.Contracts;
using WebShop.Services.Models.Product;

namespace WebShop.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repo;

        public ProductService(
            IMapper mapper,
            IRepository repo)
        {
            this._mapper = mapper;
            this._repo = repo;
        }
        public async Task Add(AddProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);

            await _repo.AddAsync(newProduct);

            await _repo.SaveChangesAsync();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ListProductDto> GetAll()
        {
            var data = _repo.AllReadonly<Product>();

            var products = data
                .ProjectTo<ListProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.ProductName)
                .ToArray();

            return products;
        }

        public Task<ICollection<ListProductDto>> GetAll(Func<ListProductDto, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductInfoDto> GetById(Guid id)
        {
            var result = await _repo.GetByIdAsync<Product>(id);

            var info = _mapper.Map<ProductInfoDto>(result);

            return info;
        }
    }
}
