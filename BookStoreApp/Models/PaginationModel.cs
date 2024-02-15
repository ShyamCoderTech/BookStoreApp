using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Models
{
    public class PaginationModel<T>
    {

        public  List<T> Items { get; set; }
        public  int TotalItems { get; set; }
        public  int PageIndex { get; set; }
        public  int PageSize { get; set; }
        public  int TotalPages { get; set; }
        public PaginationModel(List<T> items,int count ,int pageIndex,int pageSize)
        {
            Items = items;
            TotalItems = count;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(TotalItems/(double)pageSize);
        }

        public bool hasPreviousPage => (PageIndex > 1);
        public bool hasNextPage => (PageIndex < PageSize);

        public static async Task<PaginationModel<T>> CreateAsync(IQueryable<T> source, int pageIndex,int pageSize)
        {
            var count =await source.CountAsync();
            var items =await source.Skip((pageIndex-1)*pageSize).Take(pageSize).ToListAsync();
            return new PaginationModel<T>(items, count, pageIndex, pageSize);
        }

    }
}
