using Product.Core.DbStructs;
using SharedLiberary.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Core.Models.ProdSch
{
    [Table(name: GoodTables.MeasureUnit, Schema = SchemaNames.GoodSchema)]
    public class Measurment//: Register
    {
        [Key]
        public string MeasureID { get; set; }
        [Required, StringLength(20)]
        public string MeasureName { get; set; }
        /// <summary>
        /// unique
        /// </summary>
        [StringLength(3)]
        public string MeasureShort { get; set; }
        /// <summary>
        /// the code will generate with the properity 
        /// </summary>
        [StringLength(2)]
        public string MeasureCode { get; set; }
        [Required,StringLength(6)]
        public string PropFullCode { get; set; }

        /// <summary>
        /// unique and will be the propcode and measurecode
        /// </summary>
        [Required,ForeignKey(GoodTables.Properties)]
        public string PropID { get; set; }

        public Property PropertyTBL { get; set; }

    }
}
