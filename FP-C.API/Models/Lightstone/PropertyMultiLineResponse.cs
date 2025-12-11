


































using System;
using System.Drawing;

namespace FP_C.API.Models.Lightstone
{
    public class PropertyMultiLineResponse
    {
        public int? propertyId { get; set; }
        public int? deedsOfficeId { get; set; }
        public string? address { get; set; }
        public int? streetId { get; set; }
        public int? streetGroupId { get; set; }
        public string? streetNumber { get; set; }
        public string? streetName { get; set; }
        public string? streetType { get; set; }
        public int? estateId { get; set; }
        public int? schemeGroupId { get; set; }
        public string? estateName { get; set; }
        public int? suburbId { get; set; }
        public string? suburb { get; set; }
        public int? townId { get; set; }
        public string? town { get; set; }
        public string? suburbName { get; set; }
        public string? townName { get; set; }
        public string? districtCouncilName { get; set; }
        public string? municipalityName { get; set; }
        public int? municipalityId { get; set; }
        public string? municipality { get; set; }
        public int? districtCouncilId { get; set; }
        public string? districtCouncil { get; set; }
        public string? postCode { get; set; }
        public int? provinceId { get; set; }
        public string? province { get; set; }
        public string? legalDescription { get; set; }
        public string? township { get; set; }
        public int? erfNumber { get; set; }
        public int? portionNumber { get; set; }
        public string? sectionalSchemeName { get; set; }
        public int? sectionalSchemeUnitNumber { get; set; }
        public int? sectionalSchemeNumber { get; set; }
        public int? sectionalSchemeYear { get; set; }
        public string? farmName { get; set; }
        public string? registrar { get; set; }
        public string? propertyType { get; set; }
        public int? ownerCount { get; set; }
        public string? ownerDetails { get; set; }
        public GeometryCollection? cadPolygon { get; set; }
        public Point cadPoint { get; set; }
        public string[] highlightedFields { get; set; }
        public List<Owner> owners { get; set; }
        public bool? remainingExtent { get; set; }
        public bool? isUniqueMatch { get; set; }
        public string? matchLevel { get; set; }
    }
}
