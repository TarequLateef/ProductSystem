using HealthApp.EF.Reposiotries;
using Product.Core.Interfaces.ProSch;
using Product.Core.Models.ProdSch;
using SharedLiberary.General;
using SQLitePCL;

namespace Product.EF.Repositoies.ProSch
{
    public class ProductRepo : ProductRepository<Products>, IProductRepo
    {
        readonly ProductDbContext _proCtx;
        public ProductRepo(ProductDbContext proCtx) : base(proCtx) => _proCtx=proCtx;

        #region Availablity
        public Task<IList<Products>> AvailableListAsync() =>
            this.Find(p => !p.EndDate.HasValue || (p.EndDate.HasValue && p.EndDate.Value>=DateTime.Now));

        public Task<IList<Products>> BannedListAsync() =>
            this.Find(p => p.EndDate.HasValue && p.EndDate.Value<DateTime.Now);

        public bool IsAvalaible(Products Item) =>
            !Item.EndDate.HasValue || (Item.EndDate.HasValue && Item.EndDate.Value >= DateTime.Now);

        public async Task<Products> RestoreStopAsync(Products sItem)
        {
            sItem.EndDate=sItem.EndDate.HasValue ? null : DateTime.Now;
            //stop the values of the product and the data of it 
            if (sItem.EndDate.HasValue)
            {
                var proValRepo = new ProdValueRepo(_proCtx);
                var ProValList = await proValRepo.Find(pv => pv.ProdID==sItem.ProdID);
                foreach (var item in ProValList)
                {
                    item.EndDate=DateTime.Now;
                    proValRepo.Update(item);
                    _proCtx.SaveChanges();
                }

                var proFullDataRepo = new ProdFullDataRepo(_proCtx);
                var proFullDataList = await proFullDataRepo.Find(pv => pv.ProdID==sItem.ProdID);
                foreach (var item in proFullDataList)
                {
                    item.EndDate=DateTime.Now;
                    proFullDataRepo.Update(item);
                    _proCtx.SaveChanges();
                }
            }

            return await this.Update(sItem.ProdID, sItem);
        }

        public Products RestorStop(Products sItem)
        {
            sItem.EndDate=sItem.EndDate.HasValue ? null : DateTime.Now;
            return this.Update(sItem);
        }

        #endregion
        public async Task<string> SetProductCode()
        {
            var proCount = this.Count();
            string sc = new SerialCode(4, proCount).GenerateCode;
            return new MathConvertion(MathSystem.Hexa, Convert.ToInt16(sc)).ReturnedNumber;
        }

        public async Task<IList<Products>> SearchByName(bool aval, string pName) =>
            await this.Find(p => p.ProdName.Contains(pName) && p.Available==aval);
        

    }
}
