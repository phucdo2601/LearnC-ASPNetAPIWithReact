using Microsoft.EntityFrameworkCore;

namespace LearnASPNetRestWithEntityFrmB1.Data
{
    public class LearnASPNetRestWithEntityFrmB1Context :DbContext
    {
        public LearnASPNetRestWithEntityFrmB1Context(DbContextOptions<LearnASPNetRestWithEntityFrmB1Context> options) :base(options)
        {

        }

        public DbSet<User> users { get; set; }

    }
}
