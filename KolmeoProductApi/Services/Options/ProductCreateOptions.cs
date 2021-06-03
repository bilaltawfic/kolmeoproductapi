namespace KolmeoProductApi.Services.Options
{
    /// <summary>
    /// Represents the options to create a product.
    /// </summary>
    public class ProductCreateOptions
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
