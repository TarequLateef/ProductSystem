using Product.Core.DbStructs;
using SharedLiberary.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Core.Models.ProdSch
{
    [Table(GoodTables.Properties, Schema = SchemaNames.GoodSchema)]
    public class Property //: Register
    {
        [Key]
        public string PropID { get; set; }
        /// <summary>
        /// the propName and measurement will be unique
        /// </summary>
        [Required, StringLength(15)]
        public string PropName { get; set; }
        [StringLength(50)]
        public string? PropDesc { get; set; }
        /// <summary>
        /// this code is unique and hexadecimal
        /// </summary>
        [Required, StringLength(4)]
        public string PropCode { get; set; }
    }
}
