using GAM27092023_BLAZOR.EN;
using Microsoft.EntityFrameworkCore;


namespace GAM27092023_BLAZOR.Models.DAL
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions<DbContext> options): base (options)
        {
           
        }

        public DbSet<memberGAM> MembersGAM { get; set; }
    }
}
