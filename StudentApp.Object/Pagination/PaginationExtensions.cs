namespace StudentApp.Object.Pagination
{
    public static class PaginationExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int currentPage, int itemsPerPage)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source collection cannot be null.");
            }

            if (currentPage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(currentPage), "Current page must be greater than zero.");
            }

            if (itemsPerPage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(itemsPerPage), "Items per page must be greater than zero.");
            }

            return source.Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage);
        }

        public static PaginationResult<T> Paginate<T>(this IEnumerable<T> source, int totalCount, int currentPage, int itemsPerPage = 10)
        {
            if (totalCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totalCount), "Total count must be non-negative.");
            }

            var paginatedItems = source.Paginate(currentPage, itemsPerPage);
            var totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);

            return new PaginationResult<T>(paginatedItems, currentPage, itemsPerPage, totalCount, totalPages);
        }
    }
}
