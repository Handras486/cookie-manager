﻿namespace CookieManager.Core.Entities
{
    public class Cookie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? CookieImageUrl { get; set; }
    }
}
