using System;
using TiendeoAPI.Models;

namespace TiendeoAPI.Helpers
{
    public static class DistanceCalculate
    {
        public const double EarthRadius = 6371;
        public static Double CalculateDistanceBetween(Coord userCoord, Coord objCoord)
        {
            Double distance = 0;
            double lat = (objCoord.Lat - userCoord.Lat) * (Math.PI / 180);
            double lon = (objCoord.Lon - userCoord.Lon) * (Math.PI / 180);
            double a = Math.Sin(lat / 2) * Math.Sin(lat / 2) + Math.Cos(userCoord.Lat * (Math.PI / 180)) * Math.Cos(objCoord.Lat * (Math.PI / 180)) * Math.Sin(lon / 2) * Math.Sin(lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            return Math.Round(distance, 2);
        }
    }
}
