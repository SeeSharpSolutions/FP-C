using System.Xml.Serialization;

namespace FP_C.API.Models.XMLData
{
    [XmlRoot(ElementName = "HoldingTypeCode")]
    public class HoldingTypeCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CurrencyTypeCode")]
    public class CurrencyTypeCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ComponentOfPackage")]
    public class ComponentOfPackage
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }
    }

    [XmlRoot(ElementName = "LineOfBusiness")]
    public class LineOfBusiness
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ProductType")]
    public class ProductType
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PolicyStatus")]
    public class PolicyStatus
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PaymentMode")]
    public class PaymentMode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PaymentMethod")]
    public class PaymentMethod
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LifeCovStatus")]
    public class LifeCovStatus
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LifeCovTypeCode")]
    public class LifeCovTypeCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "IndicatorCode")]
    public class IndicatorCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "BenefitPeriod")]
    public class BenefitPeriod
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LifeCovOptTypeCode")]
    public class LifeCovOptTypeCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CovOption")]
    public class CovOption
    {

        [XmlElement(ElementName = "PlanName")]
        public string PlanName { get; set; }

        [XmlElement(ElementName = "LifeCovOptTypeCode")]
        public LifeCovOptTypeCode LifeCovOptTypeCode { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LifeParticipantRoleCode")]
    public class LifeParticipantRoleCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LifeParticipant")]
    public class LifeParticipant
    {

        [XmlElement(ElementName = "LifeParticipantRoleCode")]
        public LifeParticipantRoleCode LifeParticipantRoleCode { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "PartyID")]
        public string PartyID { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Coverage")]
    public class Coverage
    {

        [XmlElement(ElementName = "PlanName")]
        public string PlanName { get; set; }

        [XmlElement(ElementName = "LifeCovStatus")]
        public LifeCovStatus LifeCovStatus { get; set; }

        [XmlElement(ElementName = "LifeCovTypeCode")]
        public LifeCovTypeCode LifeCovTypeCode { get; set; }

        [XmlElement(ElementName = "IndicatorCode")]
        public IndicatorCode IndicatorCode { get; set; }

        [XmlElement(ElementName = "CurrentAmt")]
        public int CurrentAmt { get; set; }

        [XmlElement(ElementName = "ModalPremAmt")]
        public double ModalPremAmt { get; set; }

        [XmlElement(ElementName = "EffDate")]
        public DateTime EffDate { get; set; }

        [XmlElement(ElementName = "TermDate")]
        public DateTime TermDate { get; set; }

        [XmlElement(ElementName = "BenefitPeriod")]
        public BenefitPeriod BenefitPeriod { get; set; }

        [XmlElement(ElementName = "CovOption")]
        public CovOption CovOption { get; set; }

        [XmlElement(ElementName = "LifeParticipant")]
        public List<LifeParticipant> LifeParticipant { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "OLifEExtension")]
    public class OLifEExtension
    {

        [XmlElement(ElementName = "PremiumIndexRate")]
        public int PremiumIndexRate { get; set; }

        [XmlElement(ElementName = "SavingsPotValue")]
        public double SavingsPotValue { get; set; }

        [XmlElement(ElementName = "YearToDateWithdrawalAmount")]
        public double YearToDateWithdrawalAmount { get; set; }

        [XmlElement(ElementName = "DateOfLastWithdrawal")]
        public DateTime DateOfLastWithdrawal { get; set; }

        [XmlElement(ElementName = "VestedPotValue")]
        public double VestedPotValue { get; set; }

        [XmlElement(ElementName = "VestedValue")]
        public double VestedValue { get; set; }

        [XmlElement(ElementName = "NonVestedValue")]
        public double NonVestedValue { get; set; }

        [XmlElement(ElementName = "RetirementPotValue")]
        public double RetirementPotValue { get; set; }

        [XmlElement(ElementName = "LifetimeWithdrawalAmount")]
        public double LifetimeWithdrawalAmount { get; set; }

        [XmlElement(ElementName = "OptedIn")]
        public string OptedIn { get; set; }

        [XmlAttribute(AttributeName = "VendorCode")]
        public string VendorCode { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Life")]
    public class Life
    {

        [XmlElement(ElementName = "Coverage")]
        public List<Coverage> Coverage { get; set; }

        [XmlElement(ElementName = "OLifEExtension")]
        public OLifEExtension OLifEExtension { get; set; }
    }

    [XmlRoot(ElementName = "Policy")]
    public class Policy
    {

        [XmlElement(ElementName = "PolNumber")]
        public double PolNumber { get; set; }

        [XmlElement(ElementName = "CertificateNo")]
        public int CertificateNo { get; set; }

        [XmlElement(ElementName = "LineOfBusiness")]
        public LineOfBusiness LineOfBusiness { get; set; }

        [XmlElement(ElementName = "ProductType")]
        public ProductType ProductType { get; set; }

        [XmlElement(ElementName = "CarrierCode")]
        public string CarrierCode { get; set; }

        [XmlElement(ElementName = "PolicyStatus")]
        public PolicyStatus PolicyStatus { get; set; }

        [XmlElement(ElementName = "EffDate")]
        public DateTime EffDate { get; set; }

        [XmlElement(ElementName = "TermDate")]
        public DateTime TermDate { get; set; }

        [XmlElement(ElementName = "StatusChangeDate")]
        public DateTime StatusChangeDate { get; set; }

        [XmlElement(ElementName = "PaidToDate")]
        public DateTime PaidToDate { get; set; }

        [XmlElement(ElementName = "PaymentMode")]
        public PaymentMode PaymentMode { get; set; }

        [XmlElement(ElementName = "PaymentAmt")]
        public double PaymentAmt { get; set; }

        [XmlElement(ElementName = "PaymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [XmlElement(ElementName = "Life")]
        public Life Life { get; set; }

        [XmlAttribute(AttributeName = "CarrierPartyID")]
        public string CarrierPartyID { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Holding")]
    public class Holding
    {

        [XmlElement(ElementName = "HoldingTypeCode")]
        public HoldingTypeCode HoldingTypeCode { get; set; }

        [XmlElement(ElementName = "HoldingName")]
        public string HoldingName { get; set; }

        [XmlElement(ElementName = "CurrencyTypeCode")]
        public CurrencyTypeCode CurrencyTypeCode { get; set; }

        [XmlElement(ElementName = "ComponentOfPackage")]
        public ComponentOfPackage ComponentOfPackage { get; set; }

        [XmlElement(ElementName = "Policy")]
        public Policy Policy { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "IDReferenceType")]
    public class IDReferenceType
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Person")]
    public class Person
    {

        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "Initials")]
        public string Initials { get; set; }

        [XmlElement(ElementName = "Prefix")]
        public string Prefix { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "Gender")]
        public Gender Gender { get; set; }

        [XmlElement(ElementName = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement(ElementName = "SmokerStat")]
        public SmokerStat SmokerStat { get; set; }

        [XmlElement(ElementName = "Occupation")]
        public string Occupation { get; set; }

        [XmlElement(ElementName = "MarStat")]
        public MarStat MarStat { get; set; }
    }

    [XmlRoot(ElementName = "Party")]
    public class Party
    {

        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }

        [XmlElement(ElementName = "IDReferenceNo")]
        public double IDReferenceNo { get; set; }

        [XmlElement(ElementName = "IDReferenceType")]
        public IDReferenceType IDReferenceType { get; set; }

        [XmlElement(ElementName = "Person")]
        public Person Person { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "Client")]
        public Client Client { get; set; }

        [XmlElement(ElementName = "Address")]
        public List<Address> Address { get; set; }

        [XmlElement(ElementName = "Phone")]
        public List<Phone> Phone { get; set; }

        [XmlElement(ElementName = "EMailAddress")]
        public EMailAddress EMailAddress { get; set; }
    }

    [XmlRoot(ElementName = "Gender")]
    public class Gender
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SmokerStat")]
    public class SmokerStat
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PrefLanguage")]
    public class PrefLanguage
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Client")]
    public class Client
    {

        [XmlElement(ElementName = "PrefLanguage")]
        public PrefLanguage PrefLanguage { get; set; }
    }

    [XmlRoot(ElementName = "MarStat")]
    public class MarStat
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "AddressTypeCode")]
    public class AddressTypeCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PrefAddr")]
    public class PrefAddr
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }
    }

    [XmlRoot(ElementName = "Address")]
    public class Address
    {

        [XmlElement(ElementName = "AddressTypeCode")]
        public AddressTypeCode AddressTypeCode { get; set; }

        [XmlElement(ElementName = "Line1")]
        public string Line1 { get; set; }

        [XmlElement(ElementName = "Line2")]
        public string Line2 { get; set; }

        [XmlElement(ElementName = "Zip")]
        public int Zip { get; set; }

        [XmlElement(ElementName = "PrefAddr")]
        public PrefAddr PrefAddr { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "Line3")]
        public string Line3 { get; set; }
    }

    [XmlRoot(ElementName = "PhoneTypeCode")]
    public class PhoneTypeCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Phone")]
    public class Phone
    {

        [XmlElement(ElementName = "PhoneTypeCode")]
        public PhoneTypeCode PhoneTypeCode { get; set; }

        [XmlElement(ElementName = "AreaCode")]
        public int AreaCode { get; set; }

        [XmlElement(ElementName = "DialNumber")]
        public int DialNumber { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PrefEMailAddr")]
    public class PrefEMailAddr
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }
    }

    [XmlRoot(ElementName = "EMailAddress")]
    public class EMailAddress
    {

        [XmlElement(ElementName = "AddrLine")]
        public string AddrLine { get; set; }

        [XmlElement(ElementName = "PrefEMailAddr")]
        public PrefEMailAddr PrefEMailAddr { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "RelatedObjectType")]
    public class RelatedObjectType
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "RelationRoleCode")]
    public class RelationRoleCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Relation")]
    public class Relation
    {

        [XmlElement(ElementName = "RelatedObjectType")]
        public RelatedObjectType RelatedObjectType { get; set; }

        [XmlElement(ElementName = "RelationRoleCode")]
        public RelationRoleCode RelationRoleCode { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "OriginatingObjectID")]
        public string OriginatingObjectID { get; set; }

        [XmlAttribute(AttributeName = "RelatedObjectID")]
        public string RelatedObjectID { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "OLifE")]
    public class OLifE
    {

        [XmlElement(ElementName = "Holding")]
        public Holding Holding { get; set; }

        [XmlElement(ElementName = "Party")]
        public List<Party> Party { get; set; }

        [XmlElement(ElementName = "Relation")]
        public List<Relation> Relation { get; set; }
    }

    [XmlRoot(ElementName = "Organization")]
    public class Organization
    {

        [XmlElement(ElementName = "AbbrName")]
        public string AbbrName { get; set; }
    }

    [XmlRoot(ElementName = "PrefPhone")]
    public class PrefPhone
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public bool Text { get; set; }
    }

    [XmlRoot(ElementName = "EMailType")]
    public class EMailType
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PolicyProductTypeCode")]
    public class PolicyProductTypeCode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PolicyProduct")]
    public class PolicyProduct
    {

        [XmlElement(ElementName = "PolicyProductTypeCode")]
        public PolicyProductTypeCode PolicyProductTypeCode { get; set; }

        [XmlElement(ElementName = "LineOfBusiness")]
        public LineOfBusiness LineOfBusiness { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "PartyID")]
        public string PartyID { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LoanPaymentMethod")]
    public class LoanPaymentMethod
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LoanPaymentMode")]
    public class LoanPaymentMode
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "IndexCover")]
    public class IndexCover
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public bool Text { get; set; }
    }

    [XmlRoot(ElementName = "LivesType")]
    public class LivesType
    {

        [XmlAttribute(AttributeName = "tc")]
        public int Tc { get; set; }

        [XmlText]
        public string Text { get; set; }
    }



}
