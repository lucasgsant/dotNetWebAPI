namespace SmartSchool.WebAPI.Helpers
{
    public class PaginationFields
    {
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public PaginationFields(int currentPage, int totalPages, int pageSize, int totalCount)
        {
            this.currentPage = currentPage;
            this.totalPages = totalPages;
            this.pageSize = pageSize;
            this.totalCount = totalCount;

        }

        
    }
}