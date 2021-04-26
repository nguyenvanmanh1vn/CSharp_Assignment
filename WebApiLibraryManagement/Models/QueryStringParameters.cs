namespace WebApiLibraryManagement.Models
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 10; // maxPageSize = _pageSize * 5
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 2;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}