namespace FP_C.API.Models.Lightstone
{
    public class Point
    {
        public List<int> boundingBoxes { get; set; } = [];
        public ICRSObject? crs { get; set; }
        public GeoJSONObjectType type { get; set; }
        public IPosition? coordinates { get; set; }
    }

    public class IPosition
    {
        public double altitude { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
