
using System.Linq.Expressions;

namespace SharedLiberary.Interfaces
{
    public interface IOperationRepository<T> where T : class
    {
        #region Base Operation
        Task<T> GetByIntID(int id);
        Task<T> GetByStringID(string id);
        Task<IList<T>> GetAll();
        Task<T> AddItem(T item);
        Task<T> Update(int id, T item);
        Task<T> Update(string id, T item);
        T Update(T item);
        /// <summary>
        /// delete item by id as string
        /// </summary>
        /// <param name="item">item to delete</param>
        void Delete(T item);
        Task<IList<T>> Delete(int id);
        /// <summary>
        /// delete item by id as string
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns>list of items without deleted</returns>
        Task<IList<T>> Delete(string id);

        #endregion

        #region Services

        int Count(Expression<Func<T, bool>> criteria);
        int Count();
        /// <summary>
        /// calculate which elements should be shown in the page
        /// </summary>
        /// <param name="ListElements"> List of elements that will filterd</param>
        /// <param name="pageNumber">Number of page</param>
        /// <param name="elemPerPage">count of elements per page</param>
        /// <returns>elememts of page</returns>
        List<T> PageEelements(IList<T> ListElements, int pageNumber, int elemPerPage=10);
        /// <summary>
        /// calculate the number of pages that should be shown in navigation bar
        /// </summary>
        /// <param name="listCount">count of elements in list</param>
        /// <param name="elemPerPage">count of elements in the page</param>
        /// <returns>count of pages in navigation</returns>
        public int PageCount(int listCount, int elemPerPage = 10);
        bool IsExists(Expression<Func<T, bool>> criteria, out T item);
        bool IsExists(Expression<Func<T, bool>> criteria);
        bool IsDeletable(Expression<Func<T, bool>> criteria);

        ListData<T> ManageListPages(IList<T> ListElements, int pageNumber, int elemPerPage = 10);
        #endregion

        #region Searching Single
        Task<T> FindSingle(Expression<Func<T, bool>> criteria);
        Task<T> FindSingle(Expression<Func<T, bool>> criteria, string[] subTables);
        #endregion

        #region Searching List
        Task<IList<T>> Find(Expression<Func<T, bool>> criteria);
        Task<IList<T>> Find(string[] subTables);
        Task<IList<T>> Find(int take, int skip);
        Task<IList<T>> Find(Expression<Func<T, object>> OrderByField, string OrderingField = Ordering.Asc);
        Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables, Expression<Func<T, object>> OrderByField, string OrderingField = Ordering.Asc);
        Task<IList<T>> Find(Expression<Func<T, bool>> criteria, int take, int skip, Expression<Func<T, object>> OrderByField, string OrderingField = Ordering.Asc);
        Task<IList<T>> Find(string[] subTables, int take, int skip, Expression<Func<T, object>> OrderByField, string OrderingField = Ordering.Asc);
        Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables, int take, int skip, Expression<Func<T, object>> OrderByField, string OrderingField = Ordering.Asc);
        Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables);
        Task<IList<T>> Find(Expression<Func<T, bool>> criteria, int take, int skip);
        Task<IList<T>> Find(string[] subTables, int take, int skip);
        Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables, int take, int skip);
        #endregion

    }

    public struct Ordering
    {
        public const string Asc = "Acending";
        public const string Desc = "Descending";
    }

    public class ListData<T>
    {
        public int ListCount { get; set; }
        public IList<T> ResultItems { get; set; }
        public int PagesCount { get; set; }
    }

}
