namespace KolmeoProductApi.Controllers.RequestModels
{
    /// <summary>
    /// Represents the request model received from clients to create a product.
    /// </summary>
    public class ProductCreateRequestModel
    {
        /// <summary>
        /// The product's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The product’s description.        
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The product's price in USD.
        /// </summary>
        public decimal Price { get; set; }
    }
}
