using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.Page
{
    public class Page
    {
        public Page():this(0)
        {

        }
        public Page(int totalrowcount):this(1,10,totalrowcount)
        {

        }
        public Page(int pageSize, int totalrowcount) :this(1,pageSize, totalrowcount)
        {
           
        }
        public Page(int currentPage, int pageSize, int totalrowcount) 
        {
            if (currentPage < 1)
                throw new ArgumentException("invalid Page number");
            if (pageSize < 1)
                throw new ArgumentException("invalid page size");
            TotalRowCount= totalrowcount;
            CurrentPage= currentPage;
            PageSize= pageSize; 
        }

        public int CurrentPage{ get; set; }
        public int PageSize { get; set; }
        public int TotalRowCount { get; set; }
        public int TotalPageCount => (int)Math.Ceiling((double)TotalRowCount/PageSize);
        public int Skip => (CurrentPage - 1) * PageSize;

    }
}
