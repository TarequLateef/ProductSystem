using HealthApp.EF.Reposiotries;
using Product.Core.Interfaces.ProSch;
using Product.Core.Models.ProdSch;
using SharedLiberary.Interfaces;
using System.Linq.Expressions;

namespace Product.EF.Repositoies.ProSch
{
    public class ProdFullDataRepo:ProductRepository<ProductFullData>, IPordFullDataRepo
    {
        readonly ProductDbContext _ctx;
        public ProdFullDataRepo(ProductDbContext ctx) : base(ctx) => _ctx=ctx;

        #region Availablity
        public Task<IList<ProductFullData>> AvailableListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProductFullData>> BannedListAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsAvalaible(ProductFullData Item)
        {
            throw new NotImplementedException();
        }

        public Task<ProductFullData> RestoreStopAsync(ProductFullData sItem)
        {
            throw new NotImplementedException();
        }

        public ProductFullData RestorStop(ProductFullData sItem)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
