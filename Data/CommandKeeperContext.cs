using CommandKeeper.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandKeeper.Data
{
    public class CommandKeeperContext : DbContext
    {
        public CommandKeeperContext(DbContextOptions<CommandKeeperContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
    }
}