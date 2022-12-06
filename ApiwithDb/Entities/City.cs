using System.ComponentModel.DataAnnotations;

namespace ApiwithDb.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Personel> ?Personel { get; set; }
    }
}
