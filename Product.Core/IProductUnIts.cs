using Product.Core.Interfaces.ProSch;
using Product.Core.Models.ProdSch;
using SharedLiberary.Interfaces;

namespace Product.Core
{
    public interface IProductUnIts:IDisposable
    {
        IProductRepo Product { get; }
        IProductValRepo PropValue { get; }
        IPordFullDataRepo ProductFullData { get; }
        IPropertyRepo Properity { get; }
        IMeasreuRepo MeasureUnit { get; }
        Task SubmitAsync();
        void Submit();
    }
}
