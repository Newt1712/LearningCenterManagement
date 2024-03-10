using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Constants
{
    public class PagingInfo
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string OrderBy { get; set; }
        public int Direction { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages
        {
            get
            {
                return ((TotalRecords - 1) / PageSize) + 1;
            }
        }

        public PagingInfo()
        {
            this.CurrentPage = 1;
            this.PageSize = 10;
        }
    }
}
