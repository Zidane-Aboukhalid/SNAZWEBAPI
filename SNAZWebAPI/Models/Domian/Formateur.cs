namespace SNAZWebAPI.Models.Domian
{
    public class Formateur
    {
        public Guid FormateurId { get; set; }
        public string Name { get; set; }
        public string Adrress { get; set; }
        public Guid GroupId { get; set; }

        public Group Group { get; set; }
    }
}
