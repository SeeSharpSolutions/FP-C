namespace FP_C.API.Models.Lightstone
{
    public class PropertySearchMultiLineResponse
    {
        public string? searchIdentifier { get; set; }
        public List<PropertyMultiLineResponse> results { get; set; } = [];
    }
}
