
namespace SharedLiberary.Core.Interfaces
{
    public interface IAvailableRepository<T> where T : class
    {
        /// <summary>
        /// items are available
        /// </summary>
        /// <returns>List of available items</returns>
        Task<IList<T>> AvailableListAsync();
        /// <summary>
        /// items aren't available 
        /// </summary>
        /// <returns>list of stopped items</returns>
        Task<IList<T>> BannedListAsync();
        /// <summary>
        /// is this item available
        /// </summary>
        /// <param name="Item">item of data</param>
        /// <returns>get item of data availability</returns>
        bool IsAvalaible(T Item);

        /// <summary>
        /// set the availability of item
        /// </summary>
        /// <param name="sItem">item of data</param>
        /// <returns>the item after change the state of availability</returns>
        T RestorStop(T sItem);
        Task<T> RestoreStopAsync(T sItem);
    }
}
