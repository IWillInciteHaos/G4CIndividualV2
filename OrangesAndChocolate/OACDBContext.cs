using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OrangesAndChocolate
{
    public class OACDBContext : IdentityDbContext
    {
        public OACDBContext(DbContextOptions<OACDBContext> options) : base(options) { }
    }
}
