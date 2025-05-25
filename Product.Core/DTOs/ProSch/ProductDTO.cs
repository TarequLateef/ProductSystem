using SharedLiberary.General;

namespace Product.Core.DTOs.ProSch
{
    public class ProductDTO : DtoGeneralRegister
    {
        string _prodID = string.Empty;
        public string ProdID
        {
            get => string.IsNullOrEmpty(_prodID) ? Guid.NewGuid().ToString() : _prodID;
            set => _prodID=value;
        }
        public string ProdName { get; set; }
        public string? ProdDesc { get; set; }
        public string BaseCode { get; set; }


    }
}
