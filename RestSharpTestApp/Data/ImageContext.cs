using Microsoft.EntityFrameworkCore;
using RestSharpTestApp.Models;

namespace RestSharpTestApp.Data
{
    public class ImageContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Face> Faces { get; set; }

        public ImageContext(DbContextOptions<ImageContext> options)
            : base(options)
        {
        }
    }
}
