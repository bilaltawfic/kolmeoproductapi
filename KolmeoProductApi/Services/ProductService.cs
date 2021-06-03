using KolmeoProductApi.Models;
using KolmeoProductApi.Models.Contexts;
using KolmeoProductApi.Services.Exceptions;
using KolmeoProductApi.Services.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KolmeoProductApi.Services
{
    /// <summary>
    /// Represents the operations available to perform on products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly KolmeoProductDbContext _context;

        /// <summary>
        /// Initialises a new ProductService with the given DbContext.
        /// </summary>
        /// <param name="context">The DbContext to use when performing operations on Products.</param>
        public ProductService(KolmeoProductDbContext context)
        {
            _context = context;
        }

        public Product Create(ProductCreateOptions options)
        {
            var product = CreateProduct(options);

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public async Task<Product> CreateAsync(ProductCreateOptions options)
        {
            var product = CreateProduct(options);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public Product Get(Guid id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll(ProductListOptions options)
        {
            var query = GetAllQuery(options);

            return query.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(ProductListOptions options)
        {
            var query = GetAllQuery(options);

            return await query.ToListAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        private Product CreateProduct(ProductCreateOptions options)
        {
            if (string.IsNullOrEmpty(options.Name))
            {
                throw new RequiredFieldMissingException("Name is required to create a Product.");
            }

            if (options.Price < 0)
            {
                throw new InvalidFieldException("Invalid price specified. Price must be greater than 0.");
            }

            return new Product()
            {
                Description = options.Description,
                Name = options.Name,
                Price = options.Price,
            };
        }

        private IQueryable<Product> GetAllQuery(ProductListOptions options)
        {
            return _context.Products
                            .Skip((options.PageNumber - 1) * options.PageSize)
                            .Take(options.PageSize);
        }
    }
}
