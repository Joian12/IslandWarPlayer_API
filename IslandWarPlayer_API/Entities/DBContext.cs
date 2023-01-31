using Microsoft.EntityFrameworkCore;

namespace IslandWarPlayer_API.Entities
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<PlayerInfo> playerInfos { get; set; }
    }
}
