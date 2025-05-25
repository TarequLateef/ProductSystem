using HealthApp.EF.Reposiotries;
using Product.Core.Interfaces.ProSch;
using Product.Core.Models.ProdSch;
using SharedLiberary.General;

namespace Product.EF.Repositoies.ProSch
{
    public class PropertyRepo : ProductRepository<Property>, IPropertyRepo
    {
        readonly ProductDbContext _ctx;
        public PropertyRepo(ProductDbContext ctx) : base(ctx) => _ctx=ctx;

        public string GeneratePropCode()
        {
            int propCount = _ctx.Properties.Count();
            string propCode = new SerialCode(4, propCount).GenerateCode;
            return new MathConvertion(MathSystem.Hexa, Convert.ToInt16(propCode)).ReturnedNumber;
        }

        public async Task<string> GenerateFullCode(string? measureID, string propCode)
        {
            string measureCode = "00";
            if (!string.IsNullOrEmpty(measureID))
            {
                var measure = await this.MeasureData(measureID);
                measureCode= measure.MeasureCode;
            }
            return propCode + measureCode;
        }

        public async Task<Measurment> MeasureData(string? measureID)
        {
            var mesureRepo = new ProductRepository<Measurment>(_ctx);
            var measure = new Measurment();
            if (!string.IsNullOrEmpty(measureID))
                measure = await mesureRepo.GetByStringID(measureID);
            return measure;
        }
    }
}
