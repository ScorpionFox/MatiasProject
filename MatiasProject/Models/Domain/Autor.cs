using System.ComponentModel.DataAnnotations;

namespace MatiasProject.Models.Domain
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        public string NameAutor { get; set; }
    }
}
