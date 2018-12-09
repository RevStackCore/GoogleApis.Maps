using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RevStackCore.Extensions.GeoLocation;

namespace RevStackCore.Google.Maps
{
    public interface IGeoCodingService
    {
        Task<IEnumerable<GeoCodedResult>> GetAsync(string formattedAddress);
        Task<IEnumerable<GeoCodedResult>> GetAsync(string street, string city, string state);
        Task<GeoCoordinate> GetLocationAsync(string formattedAddress);
        Task<GeoCoordinate> GetLocationAsync(string street, string city, string state);
        Task<IEnumerable<GeoCodedResult>> GetReverseAsync(double latitude, double longitude);
        Task<IEnumerable<AddressComponent>> GetReverseLocationAsync(double latitude, double longitude);
    }
}
