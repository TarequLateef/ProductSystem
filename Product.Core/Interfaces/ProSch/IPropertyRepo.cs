using Product.Core.Models.ProdSch;
using SharedLiberary.Interfaces;

namespace Product.Core.Interfaces.ProSch
{
    public interface IPropertyRepo : IOperationRepository<Property>
    {
        string GeneratePropCode();
        Task<string> GenerateFullCode(string? measureID,string propCode);
    }
}
