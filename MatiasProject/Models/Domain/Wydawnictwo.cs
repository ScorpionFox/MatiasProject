using System.ComponentModel.DataAnnotations;

namespace MatiasProject.Models.Domain
{
    public class Wydawnictwo
    {
        public int Id { get; set; }

        [Required]
        public string NameWydawnictwo { get; set; }
    }
}
