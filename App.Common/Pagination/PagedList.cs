using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Services.Contracts.Pagination;

namespace App.Common.Pagination
{
    public class PagedList<T> : IPagedList<T>
    {

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize = 20)
        {
         
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;

            Data = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
      


        }


        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize = 20)
        {
  
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;

            Data = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
          
        }



        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }
        public IEnumerable<T> Data { get; set; }
        public bool HasPreviousPage => (PageIndex > 0);

        public bool HasNextPage => (PageIndex + 1 < TotalPages);
    }
}
