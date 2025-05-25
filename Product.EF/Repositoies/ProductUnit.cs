using HealthApp.EF.Reposiotries;
using Product.Core;
using Product.Core.Interfaces.ProSch;
using Product.Core.Models.ProdSch;
using Product.EF.Repositoies.ProSch;
using SharedLiberary.Interfaces;
using System.ComponentModel.Design;

namespace Product.EF.Repositoies
{
    public class ProductUnit : IProductUnIts
    {
        readonly ProductDbContext _ctx;

        public IProductRepo Product { get; private set; }
        public IProductValRepo PropValue { get; private set; }
        public IPordFullDataRepo ProductFullData { get; private set; }
        public IPropertyRepo Properity { get; }
        public IMeasreuRepo MeasureUnit { get; }

        public ProductUnit(ProductDbContext ctx)
        {
            _ctx = ctx;

            this.Product = new ProductRepo(_ctx);
            this.PropValue = new ProdValueRepo(_ctx);
            this.ProductFullData = new ProdFullDataRepo(_ctx);
            this.Properity = new PropertyRepo(_ctx);
            this.MeasureUnit = new MeasureRepo(_ctx);
        }
        public void Dispose() => _ctx.Dispose();

        public void Submit() => _ctx.SaveChanges();

        public async Task SubmitAsync() => await _ctx.SaveChangesAsync();
    }
}
