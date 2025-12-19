using AstuteServiceReference;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.NetworkInformation;
using System.Reflection;

namespace FP_C.API.Models.DataEntities
{
    public class Customers
    {
        public int id { get; set; }
        public int? financial_advisor_id { get; set; }
        public string? firstName { get; set; }
        public string? surname {get;set;}
        public string? emailAddress { get;set;}
        public string? mobileNumber { get; set;}
        public string identityNumber { get; set;}
        public string? physicalAddress1 { get; set;}
        public string? physicalAddress2 { get; set;}
        public int? provinceId { get; set;}
        public string? postalCode { get; set;}
        public int? maritalStatusId { get; set;}
        public int? preferredLanguageId { get; set;}
        public int? qualificationId { get; set;}
        public string? profileImageUrl { get; set;}
        public bool? isActive { get; set;}
        public DateTime createdAt { get; set;}
        public DateTime updatedAt { get; set;}
        public int? idType { get; set;}
        public string? employer { get; set;}
        public int? spouseLinking { get; set;}
        public int? gender { get; set;}
        public DateTime dob { get; set;}
    }
}
