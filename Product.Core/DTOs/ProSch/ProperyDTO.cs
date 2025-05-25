using SharedLiberary.General;

namespace Product.Core.DTOs.ProSch
{
    public class ProperyDTO : DtoRegister
    {
        string _propID = string.Empty;
        public string PropID
        {
            get => string.IsNullOrEmpty(_propID) ? Guid.NewGuid().ToString() : _propID;
            set => _propID=value;
        }

        public string PropName { get; set; }
        public string? PropDesc { get; set; }
        // hexadecimal - 4 letters
        public string PropCode { get; set; }
        public string? MeasureID { get; set; }
        // unique - 4 letters propCode + 2 letters Measurement
        public string PropFullCode { get; set; }
    }
}
