using HealthApp.EF.Reposiotries;
using Product.Core.Interfaces.ProSch;
using Product.Core.Models.ProdSch;
using SharedLiberary.General;

namespace Product.EF.Repositoies.ProSch
{
    public class MeasureRepo : ProductRepository<Measurment>, IMeasreuRepo
    {
        readonly ProductDbContext _ctx;
        public MeasureRepo(ProductDbContext ctx) : base(ctx) => _ctx=ctx;

        public string GenerateMeasureCode(string propID)
        {
            int propCount = this.Count(m => m.PropID==propID);
            return new SerialCode(2, propCount).GenerateCode;
        }

        public async Task<string> GetPropCode(string propID)
        {
            var propItem = await this.PropData(propID);
            return propItem.PropCode;
        }

        public async Task<Property> PropData(string PropID)
        {
            var propRepo = new PropertyRepo(_ctx);
            return await propRepo.GetByStringID(PropID);
        }
    }
}
