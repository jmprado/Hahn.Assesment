namespace Hahn.Assesment.Domain.ValueObjects
{
    public class Location
    {
        public string Lat { get; }
        public string Lon { get; }

        public Location(string lat, string lon)
        {
            if (string.IsNullOrWhiteSpace(lat))
                throw new ArgumentException("Latitude cannot be empty", nameof(lat));
            if (string.IsNullOrWhiteSpace(lon))
                throw new ArgumentException("Longitude cannot be empty", nameof(lon));

            Lat = lat;
            Lon = lon;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Location other)
            {
                return Lat == other.Lat && Lon == other.Lon;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Lat, Lon);
        }

        public override string ToString()
        {
            return $"Lat: {Lat}, Lon: {Lon}";
        }
    }
}
