using Api.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Api.Domain.Models
{
    public class Product : BaseEntity
    {
        [BsonElement("name")]
        [JsonProperty("name")]
        [Required(ErrorMessage = "FirstNameRequired")]
        public string Name { get; set; }

        [BsonElement("description")]
        [JsonProperty("description")]
        [Required(ErrorMessage = "ProductDescriptionRequired")]
        public string Description { get; set; }

        [BsonElement("price")]
        [JsonProperty("price")]
        [Required(ErrorMessage = "ProductPriceRequired")]
        public decimal Price { get; set; }

        [BsonElement("pricePublic")]
        [JsonProperty("pricePublic")]
        [Required(ErrorMessage = "ProductPricePublicRequired")]
        public decimal PricePublic { get; set; }

        [BsonElement("type")]
        [JsonProperty("type")]
        [RegularExpression("fuel|additive|undefined", ErrorMessage = "InvalidProductType")]
        public string Type { get; set; } = ProductType.Undefined;
    }
}