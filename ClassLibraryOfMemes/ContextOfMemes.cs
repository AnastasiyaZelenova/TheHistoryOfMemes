using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClassLibraryOfMemes;

namespace ClassLibraryOfMemes
{
    public class ContextOfMemes : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Meme> Memes { get; set; }

        public ContextOfMemes() : base("localsql")
        {

        }
        static ContextOfMemes()
        {
            Database.SetInitializer(new ContextInitializer());
        }
    }
}
