namespace CookieManager.Models.Domain
{
    public class Cookie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? CookieImageUrl { get; set; }
    }
}
