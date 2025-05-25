using SharedLiberary.General;

namespace Product.Core.DTOs.ProSch
{
    public class MeasureDTO : DtoRegister
    {
        string _measreID = string.Empty;
        public string MeasureID { get; set; }
        public string MeasureName { get; set; }
        public string MeasureShort { get; set; }
        public string PropID { get; set; }
        public string MeasureCode { get; set; }
        public string PropFullCode { get; set; }

    }
}
