using System.ComponentModel.DataAnnotations.Schema;

namespace SNAZWebAPI.Models.Domian
{
    public class Etudiant
    {
        public Guid EtudiantId { get; set; }
        public string FullName { get; set; }
        public string Adrress { get; set; }
        public Guid GroupId { get; set; }


        public Group Group { get; set; }

    }
}
