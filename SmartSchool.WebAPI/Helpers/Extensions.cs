using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SmartSchool.WebAPI.Helpers
{
    public static class Extensions
    {
        public static void addPaginationHeader(this HttpResponse response,  
            int currentPage,
            int totalPages,
            int pageSize, 
            int totalCount)
        {
            var paginationFields = new PaginationFields(currentPage, totalPages, pageSize, totalCount);
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationFields));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}