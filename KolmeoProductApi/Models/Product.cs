using System;
using System.ComponentModel.DataAnnotations;

namespace KolmeoProductApi.Models
{
    /// <summary>
    /// Represents a Kolmeo product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [Required]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The product's name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The product’s description.        
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The product's price in USD.
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
