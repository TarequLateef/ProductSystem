using Product.Core.Models.ProdSch;
using SharedLiberary.Core.Interfaces;
using SharedLiberary.Interfaces;

namespace Product.Core.Interfaces.ProSch
{
    public interface IProductRepo : IOperationRepository<Products>, IAvailableRepository<Products>
    {
        Task<string> SetProductCode();
        Task<IList<Products>> SearchByName(bool aval,string pName);

    }
}
