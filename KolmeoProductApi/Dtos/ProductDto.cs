using System;

namespace KolmeoProductApi.Dtos
{
    /// <summary>
    /// Represents a Kolmeo product to be sent to clients using the API.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        public Guid Id { get; set; }

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
