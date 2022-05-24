using Microsoft.EntityFrameworkCore;

namespace WebServer.Models
{
    public class Paginated<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int TotalPages => (int)Math.Ceiling(Total / (double)PageSize);
        public IList<T> Items { get; set; }
        public Paginated(List<T> items, int pageNumber, int pageSize, int total)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Total = total;
            Items = items;
        }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    public static class PaginatedQueryableExtensions
    {
        public static async Task<Paginated<T>> ToPaginatedAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Paginated<T>(items, pageNumber, pageSize, count);
        }
    }
}
