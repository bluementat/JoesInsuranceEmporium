using JoesInsuranceEmporium.DataClasses;
using System.Threading.Tasks;

namespace PropertyGenerationApi.Modules
{
    public interface IRandomPropertyGenerator
    {
        Task<Property> Generate();
    }
}