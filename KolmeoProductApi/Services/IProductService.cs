using KolmeoProductApi.Models;
using KolmeoProductApi.Services.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KolmeoProductApi.Services
{
    /// <summary>
    /// Defines methods used to perform operations on products.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Creates a product from the given options and returns it.
        /// </summary>
        /// <param name="options">The options to create the product from.</param>
        /// <returns>The created product.</returns>
        public Product Create(ProductCreateOptions options);
        
        /// <summary>
        /// Creates a product from the given options and returns it.
        /// </summary>
        /// <param name="options">The options to create the product from.</param>
        /// <returns>A task representing the created product.</returns>
        public Task<Product> CreateAsync(ProductCreateOptions options);

        /// <summary>
        /// Gets a product for the given id and returns it.
        /// </summary>
        /// <param name="id">The id of the product to get.</param>
        /// <returns>The product with the given id</returns>
        /// <remarks>If the product is not found, this method will return null</remarks>
        public Product Get(Guid id);

        /// <summary>
        /// Gets a product for the given id and returns it.
        /// </summary>
        /// <param name="id">The id of the product to get.</param>
        /// <returns>A task reprsenting the product with the given id</returns>
        /// <remarks>If the product is not found, this method will return null</remarks>
        public Task<Product> GetAsync(Guid id);

        /// <summary>
        /// Gets all the products for the given options and returns them.
        /// </summary>
        /// <param name="options">The options specifying which products to return</param>
        /// <returns>The products for the given options.</returns>
        public IEnumerable<Product> GetAll(ProductListOptions options);

        /// <summary>
        /// Gets all the products for the given options and returns them.
        /// </summary>
        /// <param name="options">The options specifying which products to return</param>
        /// <returns>A task representing the products for the given options.</returns>
        public Task<IEnumerable<Product>> GetAllAsync(ProductListOptions options);
    }
}
