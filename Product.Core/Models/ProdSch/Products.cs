using Microsoft.EntityFrameworkCore;
using Product.Core.DbStructs;
using SharedLiberary.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Core.Models.ProdSch
{
    [Table(GoodTables.BaseProduct, Schema = SchemaNames.GoodSchema)]
    public class Products : GeneralRegister
    {
        [Key]
        public string ProdID { get; set; }
        /// <summary>
        /// the product name is unique
        /// </summary>
        [Required, StringLength(30)]
        public string ProdName { get; set; }
        [StringLength(50)]
        public string? ProdDesc { get; set; }
        /// <summary>
        /// the code is unique and hexadecimal
        /// </summary>
        [Required, StringLength(3)]
        public string BaseCode { get; set; }
    }
}
