namespace StudentApp.Object.Pagination
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; }
        public int CurrentPage { get; }
        public int ItemsPerPage { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }

        public PaginationResult(IEnumerable<T> items, int currentPage, int itemsPerPage, int totalCount, int totalPages)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
    }
}
