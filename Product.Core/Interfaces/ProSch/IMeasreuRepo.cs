using Product.Core.Models.ProdSch;
using SharedLiberary.Interfaces;

namespace Product.Core.Interfaces.ProSch
{
    public interface IMeasreuRepo : IOperationRepository<Measurment>
    {
        Task<Property> PropData(string PropID);
        string GenerateMeasureCode(string propID);
        Task<string> GetPropCode(string propID);
    }
}
