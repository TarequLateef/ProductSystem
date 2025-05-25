using Microsoft.EntityFrameworkCore;
using Product.EF;
using SharedLiberary.Interfaces;
using System.Linq.Expressions;

namespace HealthApp.EF.Reposiotries
{
    public class ProductRepository<T> : IOperationRepository<T> where T : class
    {
        private readonly ProductDbContext _ctx;
        public ProductRepository(ProductDbContext ctx) => _ctx = ctx;

        #region Operation
        public async Task<T> AddItem(T item)
        {
            await _ctx.Set<T>().AddAsync(item);
            return item;
        }

        public void Delete(T item) => _ctx.Set<T>().Remove(item);

        public async Task<IList<T>> Delete(int id)
        {
            T item = await _ctx.Set<T>().FindAsync(id);
            if (item is not null) _ctx.Set<T>().Remove(item);
            return _ctx.Set<T>().ToList();
        }

        public async Task<IList<T>> Delete(string id)
        {
            T item = await _ctx.Set<T>().FindAsync(id);
            if (item is not null) _ctx.Set<T>().Remove(item);
            return _ctx.Set<T>().ToList();

        }
        public async Task<IList<T>> GetAll() => await _ctx.Set<T>().ToArrayAsync();

        public async Task<T> GetByIntID(int id) => await _ctx.Set<T>().FindAsync(id);

        public async Task<T> GetByStringID(string id) => await _ctx.Set<T>().FindAsync(id);

        public async Task<T> Update(int id, T item)
        {
            var updateItem = await _ctx.Set<T>().FindAsync(id);
            _ctx.Entry(updateItem).CurrentValues.SetValues(item);
            return updateItem;

        }

        public async Task<T> Update(string id, T item)
        {
            var updateItem = await _ctx.Set<T>().FindAsync(id);
            _ctx.Entry(updateItem).CurrentValues.SetValues(item);
            return updateItem;
        }
        public T Update(T item)
        {
            _ctx.Update(item);
            return item;

        }
        #endregion

        #region Services
        public int Count(Expression<Func<T, bool>> criteria) => _ctx.Set<T>().Count(criteria);
        public int Count() => _ctx.Set<T>().Count();
        public List<T> PageEelements(IList<T> ListElements, int pageNumber, int elemPerPage = 10) =>
            ListElements.Skip((pageNumber - 1)*elemPerPage).Take(elemPerPage).ToList();

       public ListData<T> ManageListPages(IList<T> ListElements, int pageNumber, int elemPerPage = 10)=>
            new ListData<T>
            {
                ListCount = ListElements.Count,
                PagesCount = PageCount(ListElements.Count, elemPerPage),
                ResultItems = PageEelements(ListElements, pageNumber, elemPerPage)
            };

        public int PageCount(int listCount, int elemPerPage = 10) =>
                    Convert.ToInt16(listCount/elemPerPage)+(listCount%elemPerPage>0 ? 1 : 0); // if there is any element in the last page, add one more page to the count
        public bool IsDeletable(Expression<Func<T, bool>> criteria) =>
            !_ctx.Set<T>().Any(criteria);

        public bool IsExists(Expression<Func<T, bool>> criteria, out T item)
        {
            item =_ctx.Set<T>().Find(criteria);
            return item is not null;
        }
        public bool IsExists(Expression<Func<T, bool>> criteria) => _ctx.Set<T>().Any(criteria);

        #endregion

        #region Search
        public async Task<IList<T>> Find(Expression<Func<T, bool>> criteria) =>
            await _ctx.Set<T>().Where(criteria).ToArrayAsync();

        public async Task<IList<T>> Find(string[] subTables)
        {
            IQueryable<T> list = _ctx.Set<T>();
            foreach (var tbl in subTables) list = list.Include(tbl);
            return await list.ToArrayAsync();
        }

        public async Task<IList<T>> Find(int take, int skip) =>
            await _ctx.Set<T>().Take(take).Skip(skip).ToArrayAsync();

        public async Task<IList<T>> Find(Expression<Func<T, object>> OrderByField, string OrderingField = "Acending")
        {
            IQueryable<T> list = _ctx.Set<T>();
            return OrderingField==Ordering.Asc ?
                await list.OrderBy(OrderByField).ToArrayAsync()
                : await list.OrderByDescending(OrderByField).ToArrayAsync();
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables, Expression<Func<T, object>> OrderByField, string OrderingField = "Acending")
        {
            IQueryable<T> list = _ctx.Set<T>().Where(criteria);
            foreach (var tbl in subTables) list=list.Include(tbl);
            return OrderingField==Ordering.Asc ?
                await list.OrderBy(OrderByField).ToArrayAsync()
                : await list.OrderByDescending(OrderByField).ToArrayAsync();
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> criteria, int take, int skip, Expression<Func<T, object>> OrderByField, string OrderingField = "Acending")
        {
            IQueryable<T> list = _ctx.Set<T>().Where(criteria);
            list = list.Take(take).Skip(skip);
            return OrderingField==Ordering.Asc ?
                await list.OrderBy(OrderByField).ToArrayAsync()
                : await list.OrderByDescending(OrderByField).ToArrayAsync();
        }

        public async Task<IList<T>> Find(string[] subTables, int take, int skip, Expression<Func<T, object>> OrderByField, string OrderingField = "Acending")
        {
            IQueryable<T> list = _ctx.Set<T>();
            list = list.Take(take).Skip(skip);
            foreach (var tbl in subTables) list = list.Include(tbl);
            return OrderingField==Ordering.Asc ?
                            await list.OrderBy(OrderByField).ToArrayAsync()
                            : await list.OrderByDescending(OrderByField).ToArrayAsync();
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables, int take, int skip, Expression<Func<T, object>> OrderByField, string OrderingField = "Acending")
        {
            IQueryable<T> list = _ctx.Set<T>().Where(criteria);
            list = list.Take(take).Skip(skip);
            foreach (var tbl in subTables) list = list.Include(tbl);
            return OrderingField==Ordering.Asc ?
                            await list.OrderBy(OrderByField).ToArrayAsync()
                            : await list.OrderByDescending(OrderByField).ToArrayAsync();
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables)
        {
            IQueryable<T> list = _ctx.Set<T>().Where(criteria);
            foreach (var tbl in subTables) list = list.Include(tbl);
            return await list.ToArrayAsync();
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            IQueryable<T> list = _ctx.Set<T>().Where(criteria);
            return await list.Take(take).Skip(skip).ToArrayAsync();
        }

        public async Task<IList<T>> Find(string[] subTables, int take, int skip)
        {
            IQueryable<T> list = _ctx.Set<T>();
            return await list.Take(take).Skip(skip).ToArrayAsync();
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> criteria, string[] subTables, int take, int skip)
        {
            IQueryable<T> list = _ctx.Set<T>().Where(criteria);
            list = list.Take(take).Skip(skip);
            foreach (var tbl in subTables) list=list.Include(tbl);
            return await list.ToArrayAsync();
        }

        public async Task<T> FindSingle(Expression<Func<T, bool>> criteria) =>
                await _ctx.Set<T>().FirstOrDefaultAsync(criteria);


        public async Task<T> FindSingle(Expression<Func<T, bool>> criteria, string[] subTables)
        {
            IQueryable<T> val = _ctx.Set<T>();
            foreach (var tbl in subTables) val = val.Include(tbl);
            return await val.FirstOrDefaultAsync(criteria);

        }
        #endregion
    }
}
