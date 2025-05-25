using Product.Core.DbStructs;
using SharedLiberary.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Core.Models.ProdSch
{
    [Table(GoodTables.ProductProperty, Schema = SchemaNames.GoodSchema)]
    public class ProductFullData : GeneralRegister
    {
        [Key]
        public string FullDataID { get; set; }
        [Required, ForeignKey(GoodTables.BaseProduct)]
        public string ProdID { get; set; }
        /// <summary>
        /// sum of properties to product (5) hexa and (2) for count of prop 
        /// </summary>
        [Required,StringLength(7)]
        public string PropCode { get; set; }
        /// <summary>
        /// sum of properties values
        /// </summary>
        [Required, StringLength(3)]
        public string ValueCode { get; set; }

        /// <summary>
        /// full code (3) product hexa propcode(7) valuecode(3)
        /// </summary>
        public string FullCode { get; set; }

        public Products ProductTBL { get; set; }

    }
}
