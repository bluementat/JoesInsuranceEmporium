using JoesInsuranceEmporium.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyGenerationApi.Modules
{
    public class RandomPropertyGenerator : IRandomPropertyGenerator
    {
        private Random _random { get; set; }
        private readonly bool _delays;
        private StringBuilder _stringBuilder;

        private static readonly string[] StreetNames =
        {
            "Sixth Ave.",
            "First Ave.",
            "Main St.",
            "Second St.",
            "Elms Rd.",
            "Broadway Dr.",
            "Franklin Ave.",
            "Washington St.",
            "Michigan Ave.",
            "Cook St.",
            "Park Ave.",
            "Third St.",
            "Baker Rd.",
            "Detroit St."
        };

        private static readonly string[] CityNames =
        {
            "Detroit",
            "Ann Arbor",
            "Lansing",
            "Swartz Creek",
            "Grand Rapids",
            "Flint",
            "Saginaw",
            "Kalamazoo",
            "Traverse City",
            "Alpena"
        };

        public RandomPropertyGenerator(bool Delays)
        {
            _random = new Random();
            _stringBuilder = new();
            _delays = Delays;
        }

        public async Task<Property> Generate()
        {
            var result = new Property();
            result.Id = Guid.NewGuid();
            result.Title = "";
            result.StreetAddress = CreateAddress();
            result.City = CityNames[_random.Next(0, CityNames.Length - 1)];
            result.State = "MI";
            result.Size = _random.Next(1000, 12000);
            result.PropertyType = (LineType)_random.Next(0, 2);

            if (_delays)
            {
                await Task.Delay(_random.Next(0, 4000));
            }

            return result;
        }

        private string CreateAddress()
        {
            _stringBuilder.Clear();

            int rnd = _random.Next(100, 10000);
            _stringBuilder.Append(rnd.ToString());

            rnd = _random.Next(0, StreetNames.Length - 1);
            _stringBuilder.Append(" " + StreetNames[rnd]);

            return _stringBuilder.ToString();
        }
    }
}
