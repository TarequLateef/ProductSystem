using HealthApp.EF.Reposiotries;
using Product.Core.DbStructs;
using Product.Core.Interfaces.ProSch;
using Product.Core.Models.ProdSch;
using SharedLiberary.General;
using SharedLiberary.Interfaces;

namespace Product.EF.Repositoies.ProSch
{
    public class ProdValueRepo : ProductRepository<PropValue>, IProductValRepo
    {
        readonly ProductDbContext _ctx;
        public ProdValueRepo(ProductDbContext ctx) : base(ctx) => _ctx=ctx;

        #region Availablity
        public Task<IList<PropValue>> AvailableListAsync() =>
            this.Find(pv => !pv.EndDate.HasValue || (pv.EndDate.HasValue && pv.EndDate.Value>=DateTime.Now), new[] { GoodTables.Properties, GoodTables.BaseProduct });

        public Task<IList<PropValue>> BannedListAsync() =>
            this.Find(pv => pv.EndDate.HasValue && pv.EndDate.Value<DateTime.Now, new[] { GoodTables.Properties, GoodTables.BaseProduct });

        public bool IsAvalaible(PropValue Item) =>
            !Item.EndDate.HasValue || (Item.EndDate.HasValue && Item.EndDate.Value >= DateTime.Now);

        public async Task<PropValue> RestoreStopAsync(PropValue sItem)
        {
            sItem.EndDate=sItem.EndDate.HasValue ? null : DateTime.Now;
            return await this.Update(sItem.PropValID, sItem);
        }

        public PropValue RestorStop(PropValue sItem)
        {
            sItem.EndDate=sItem.EndDate.HasValue ? null : DateTime.Now;
            return this.Update(sItem);
        }
        #endregion
        public async Task<PropValue> PropValDetailsAsync(PropValue propValue)
        {
            var prodRepo = new ProductRepo(_ctx);
            propValue.ProductTBL = await prodRepo.GetByStringID(propValue.ProdID);

            var propRepo = new ProductRepository<Property>(_ctx);
            propValue.PropertyTBL = await propRepo.GetByStringID(propValue.PropID);

            return propValue;
        }

        public IList<PropValue> SearchValue(IList<PropValue> pvList, string val) =>
             pvList.Where(pv => pv.ProprityValue.Contains(val)).ToList();

        public IList<PropValue> SearchPorprety(IList<PropValue> pvList, string prop) =>
            pvList.Where(pv => pv.PropertyTBL.PropName.Contains(prop)).ToList();

        public string ValueCode(string propID, string prodID)
        {
            int valCount = this.Count(v => v.PropID==propID && v.ProdID==prodID);
            return new SerialCode(2, valCount).GenerateCode;
        }


    }
}
