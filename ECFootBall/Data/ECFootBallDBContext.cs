using Microsoft.EntityFrameworkCore;

namespace ECFootBall.Data
{
    public class ECFootBallDBContext : DbContext
    {
        public ECFootBallDBContext(DbContextOptions<ECFootBallDBContext> options) : base(options)
        {
        }
    }
}
