using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RevStackCore.Net;
using RevStackCore.Extensions.Serialization.SnakeCase;
using RevStackCore.Extensions.GeoLocation;
using RevStackCore.GoogleApis.Core;


namespace RevStackCore.GoogleApis.Maps
{
    public class GeoCodingService : IGeoCodingService
    {
        private readonly GoogleApiContext _context;
        private string _key;
        private string _baseGoolgeUrl = "https://maps.googleapis.com/maps/api/geocode/json?";
        public GeoCodingService(GoogleApiContext context)
        {
            _context = context;
            _key = _context.Key;
        }

        public async Task<IEnumerable<GeoCodedResult>> GetAsync(string formattedAddress)
        {
            string url = _baseGoolgeUrl + "address=" + formattedAddress + "&key=" + _key;
            string json = await Http.GetAsync(url);
            var response= Json.DeserializeObject<GeoCodedResponse>(json);
            return response.Results;
        }

        public  Task<IEnumerable<GeoCodedResult>> GetAsync(string street, string city, string state)
        {
            string formattedAddress = street + ", " + city + ", " + state;
            formattedAddress = formattedAddress.ToGoogleFormattedAddress();
            return GetAsync(formattedAddress);
        }

        public async Task<GeoCoordinate> GetLocationAsync(string formattedAddress)
        {
            var result = await GetAsync(formattedAddress);
            if(result !=null && result.Count() > 0)
            {
                var location = result.FirstOrDefault().Geometry.Location;
                return new GeoCoordinate(location.Lat, location.Lng);
            }
            else
            {
                return null;
            }
        }

        public Task<GeoCoordinate> GetLocationAsync(string street, string city, string state)
        {
            string formattedAddress = street + ", " + city + ", " + state;
            formattedAddress = formattedAddress.ToGoogleFormattedAddress();
            return GetLocationAsync(formattedAddress);
        }

        public async Task<IEnumerable<GeoCodedResult>> GetReverseAsync(double latitude,double longitude)
        {
            string url = _baseGoolgeUrl + "latlng=" + latitude.ToString() + "," + longitude.ToString() + "&key=" + _key;
            string json = await Http.GetAsync(url);
            var response= Json.DeserializeObject<GeoCodedResponse>(json);
            return response.Results;
        }

        public async Task<IEnumerable<AddressComponent>> GetReverseLocationAsync(double latitude, double longitude)
        {
            var result = await GetReverseAsync(latitude, longitude);
            var first = result.FirstOrDefault();
            if(first!=null)
            {
                return first.AddressComponents;
            }
            else
            {
                return new List<AddressComponent>();
            }
        }

    }
}
