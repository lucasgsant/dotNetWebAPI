namespace SmartSchool.WebAPI.Helpers
{
    public class PageParams
    {
        public int maxPage { get; set; } = 50;
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public int PageSize { 
            get {
                return pageSize;
            } 
            set {
                pageSize = (value > maxPage) ? maxPage : value;
            } 
        }
        public int? Matricula { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}