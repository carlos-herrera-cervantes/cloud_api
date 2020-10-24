﻿using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Api.Domain.Models
{
    public class CustomerPurchase : BaseEntity
    {
        [BsonElement("folio")]
        [JsonProperty("folio")]
        [Required(ErrorMessage = "PurchaseFolioRequired")]
        public string Folio { get; set; }

        [BsonElement("iva")]
        [JsonProperty("iva")]
        [Required(ErrorMessage = "PurchaseIvaRequired")]
        public decimal? Iva { get; set; }

        [BsonElement("subtotal")]
        [JsonProperty("subtotal")]
        [Required(ErrorMessage = "PurchaseSubtotalRequired")]
        public decimal? Subtotal { get; set; }

        [BsonElement("total")]
        [JsonProperty("total")]
        [Required(ErrorMessage = "PurchaseTotalRequired")]
        public decimal? Total { get; set; }

        [BsonElement("totalLetters")]
        [JsonProperty("totalLetters")]
        [Required(ErrorMessage = "PurchaseTotalLettersRequired")]
        public string TotalLetters { get; set; }

        [BsonElement("userId")]
        [JsonProperty("userId")]
        [Required(ErrorMessage = "PurchaseEmployeeRequired")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonElement("products")]
        [JsonProperty("products")]
        [Required(ErrorMessage = "PurchaseProductRequired")]
        [MinLength(1, ErrorMessage = "PurchaseProductRequired")]
        public ProductSold[] Products { get; set; }

        [BsonElement("payments")]
        [JsonProperty("payments")]
        [Required(ErrorMessage = "PurchasePaymentRequired")]
        [MinLength(1, ErrorMessage = "PurchasePaymentRequired")]
        public Payment[] Payments { get; set; }

        [BsonElement("client")]
        [JsonProperty("client")]
        [Required(ErrorMessage = "PurchaseClientRequired")]
        public Client Client { get; set; }
    }
}
