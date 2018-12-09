using System;
using System.Collections.Generic;

namespace RevStackCore.Google.Maps
{

    public class AddressComponent
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public IEnumerable<string> Types { get; set; }
    }

    public class LatLng
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Viewport
    {
        public LatLng Northeast { get; set; }
        public LatLng Southwest { get; set; }
    }

    public class Geometry
    {
        public LatLng Location { get; set; }
        public string LocationType { get; set; }
        public Viewport Viewport { get; set; }
    }

   
    public class GeoCodedResult
    {
        public IEnumerable<AddressComponent> AddressComponents { get; set; }
        public string FormattedAddress { get; set; }
        public Geometry Geometry { get; set; }
        public string PlaceId { get; set; }
        public IEnumerable<string> Types { get; set; }

    }

    public class GeoCodedResponse
    {
        public IEnumerable<GeoCodedResult> Results { get; set; }
    }
}
