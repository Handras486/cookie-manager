namespace CookieManager.Core.Specifications
{
    public class CookieQueryParameters
    {
        public string? filterOn { get; set; } = null;

        public string? filterQuery { get; set; } = null;
        public string? sortBy { get; set; } = null;
        public bool isAscending { get; set; } = true;
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 100;

        public int GetSkipResults()
        {
            return (pageNumber - 1) * pageSize;
        }
    }
}
