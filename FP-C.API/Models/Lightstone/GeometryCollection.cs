namespace FP_C.API.Models.Lightstone
{
    public class GeometryCollection
    {
        public List<int> boundingBoxes { get; set; } = [];
        public ICRSObject? crs { get; set; }
        public GeoJSONObjectType type { get; set; }
        public IGeometryObject? geometries { get; set; }
    }

    public class IGeometryObject
    {
        public GeoJSONObjectType type { get; set; }
    }

    public enum GeoJSONObjectType
    {
        Point = 0,
        MultiPoint = 1,
        LineString = 2,
        MultiLineString = 3,
        Polygon = 4,
        MultiPolygon = 5,
        GeometryCollection = 6,
        Feature = 7,
        FeatureCollection = 8
    }
}
