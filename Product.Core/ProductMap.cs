using AutoMapper;
using Product.Core.DTOs.ProSch;
using Product.Core.Models.ProdSch;

namespace Product.Core
{
    public class ProductMap:Profile
    {
        public ProductMap()
        {
            CreateMap<Products, ProductDTO>();
            CreateMap<ProductDTO, Products>();

            CreateMap<PropValue, PropValueDTO>();
            CreateMap<PropValueDTO, PropValue>();

            CreateMap<Property,ProperyDTO>();
            CreateMap<ProperyDTO, Property>();
        }
    }
}
