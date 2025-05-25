namespace Product.Core.DbStructs
{
    public struct SchemaNames
    {
        public const string Security = "Security";
        public const string GoodSchema = "Prod";
    }

    public struct GoodTables
    {
        /// <summary>
        /// the base data of product
        /// </summary>
        public const string BaseProduct = "ProductTBL"; 
        /// <summary>
        ///the specification of the product like (weight, size, color, etc) 
        /// </summary>
        public const string Properties = "PropertyTBL";
        /// <summary>
        ///the value of the specification like (weight=100g, size=large, color=red, etc) 
        /// </summary>
        public const string PropertyValue = "PropValTBL";
        /// <summary>
        ///the fill name of properties if the grouped together like (red large, 100g 20volt, etc) 
        /// </summary>
        //public const string PropertyName = "PropNameTBL";
        /// <summary>
        ///the full data of the product like and this table will use in other schemas like invnetory and sales 
        /// </summary>
        public const string ProductProperty = "ProductFullDataTBL";
        /// <summary>
        /// the unit of measure for the product like (kg, g, m, cm, etc)
        /// </summary>
        public const string MeasureUnit = "MeasureUnitTBL";
    }

}
