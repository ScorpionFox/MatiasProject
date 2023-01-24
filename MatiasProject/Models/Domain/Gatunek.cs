using System.ComponentModel.DataAnnotations;

namespace MatiasProject.Models.Domain
{
    public class Gatunek
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
