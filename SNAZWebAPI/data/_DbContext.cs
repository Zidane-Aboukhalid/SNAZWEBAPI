using Microsoft.EntityFrameworkCore;
using SNAZWebAPI.Models.Domian;

namespace SNAZWebAPI.data
{
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions dbContextOptions):base(dbContextOptions) 
        {

        }


        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Formateur> Formateurs { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
