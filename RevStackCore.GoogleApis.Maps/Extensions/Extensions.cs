using System;
namespace RevStackCore.Google.Maps
{
    public static partial class GeoCodingExtensions
    {
        public static string ToGoogleFormattedAddress(this string src)
        {
            return src.Replace(" ", "+");
        }

        public static string GoogleFormattedAddress(string street, string city, string state)
        {
            string formattedAddress = street + ", " + city + ", " + state;
            return formattedAddress.ToGoogleFormattedAddress();
        }

        public static string GoogleFormattedAddress(string street, string city, string state, double latitude, double longitude)
        {
            string formattedAddress = street + ", " + city + ", " + state;
            formattedAddress= formattedAddress.ToGoogleFormattedAddress();
            formattedAddress += "/" + "@" + latitude.ToString() + "," + longitude.ToString();
            return formattedAddress;
        }
    }
}
