namespace SharedLiberary.General.DbStructs
{
    public class ReturnState<T>
    {
        public string Message { get; set; }
        public T Item { get; set; }
        public bool Status { get; set; }
    }

    //public class ListData<T>
    //{
    //    public int ListCount { get; set; }
    //    public IList<T> ResultItems { get; set; }
    //    public int PagesCount { get; set; }
    //}
}
