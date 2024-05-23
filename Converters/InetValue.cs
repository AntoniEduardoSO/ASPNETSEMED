using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NpgsqlTypes;

namespace ASPNETSEMED.Converters
{
    public class InetValueConverter : ValueConverter<string, NpgsqlInet>
    {
        public InetValueConverter() 
            : base(
                v => new NpgsqlInet(v),
                v => v.ToString())
        {
        }
    }
}