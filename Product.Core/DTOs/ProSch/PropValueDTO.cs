using SharedLiberary.General;

namespace Product.Core.DTOs.ProSch
{
    public class PropValueDTO : DtoGeneralRegister
    {
        string _propValID = string.Empty;
        public string PropValID
        {
            get => string.IsNullOrEmpty(_propValID) ? Guid.NewGuid().ToString() : _propValID;
            set => _propValID=value;
        }

        public string ProdID { get; set; }
        public string PropID { get; set; }
        public string ProprityValue { get; set; }
        public string ValCode { get; set; }
        public byte PackgeNo { get; set; }

        public string? ProductName { get; set; }
        public string? PropertyName { get; set; }

    }
}
