namespace FP_C.API.Models.Lightstone
{
    public class ICRSObject
    {
        public CRSType type { get; set; }
    }

    public enum CRSType
    {
        Unspecified = 0,
        Name = 1,
        Link = 2
    }
}
