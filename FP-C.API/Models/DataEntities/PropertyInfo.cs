using System.Text.Json.Serialization;

namespace FP_C.API.Models.DataEntities
{
    public class PropertyInfo : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string ValuePrev { get; set; } = string.Empty;
        public string PurchaseDate { get; set; } = string.Empty;
        public int ClientInfoId { get; set; }
        [JsonIgnore]
        public ClientInfo ClientInfo { get; set; }
    }
}
