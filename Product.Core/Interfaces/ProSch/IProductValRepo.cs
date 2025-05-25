using Product.Core.Models.ProdSch;
using SharedLiberary.Core.Interfaces;
using SharedLiberary.Interfaces;

namespace Product.Core.Interfaces.ProSch
{
    public interface IProductValRepo:IOperationRepository<PropValue>,IAvailableRepository<PropValue>
    {
        /// <summary>
        /// read data of property and paroduct
        /// </summary>
        /// <param name="propValue">property value Item</param>
        /// <returns>the product details and property details</returns>
        Task<PropValue> PropValDetailsAsync(PropValue propValue);

        /// <summary>
        /// search for property value by name
        /// </summary>
        /// <param name="pvList">list of property value</param>
        /// <param name="val">properity value</param>
        /// <returns>list of product has val in properties</returns>
        IList<PropValue> SearchValue(IList<PropValue> pvList, string val);

        /// <summary>
        /// search products by property name
        /// </summary>
        /// <param name="pvList">list of products value</param>
        /// <param name="prop">property name of part of property name</param>
        /// <returns>list of products has a property like this</returns>
        IList<PropValue> SearchPorprety(IList<PropValue> pvList, string prop);

        /// <summary>
        /// generate the code of property value to each product
        /// </summary>
        /// <param name="propID">proprety id</param>
        /// <param name="prodID">product id</param>
        /// <returns>the value of product code</returns>
        string ValueCode(string propID, string prodID);
    }
}
