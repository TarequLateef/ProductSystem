using Product.Core.Models.ProdSch;
using SharedLiberary.Core.Interfaces;
using SharedLiberary.Interfaces;

namespace Product.Core.Interfaces.ProSch
{
    public interface IPordFullDataRepo:IOperationRepository<ProductFullData>
        ,IAvailableRepository<ProductFullData>
    {
    }
}
