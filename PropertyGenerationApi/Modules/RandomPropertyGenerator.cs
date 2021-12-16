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
            result.Title =
                RandomData.TitleName_FirstName[_random.Next(0, RandomData.TitleName_FirstName.Length)] +
                " " +
                RandomData.TitleName_LastName[_random.Next(0, RandomData.TitleName_LastName.Length)];
            result.StreetAddress = CreateAddress();
            result.City = RandomData.CityNames[_random.Next(0, RandomData.CityNames.Length - 1)];
            result.State = "MI";
            result.Size = _random.Next(1000, 12000);
            result.PropertyType = (LineType)_random.Next(0, 2);

            if (_delays)
            {
                await Task.Delay(_random.Next(0, 5) * 1000);
            }

            return result;
        }

        private string CreateAddress()
        {
            _stringBuilder.Clear();

            int rnd = _random.Next(100, 10000);
            _stringBuilder.Append(rnd.ToString());

            rnd = _random.Next(0, RandomData.StreetNames.Length - 1);
            _stringBuilder.Append(" " + RandomData.StreetNames[rnd]);

            return _stringBuilder.ToString();
        }
    }
}
