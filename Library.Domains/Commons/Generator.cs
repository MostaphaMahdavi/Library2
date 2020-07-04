using System;

namespace Library.Domains.Commons
{
    public class Generator
    {
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}