using System.ComponentModel.DataAnnotations;

namespace MatiasProject.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string TotalPages { get; set; }
        [Required]
        public int AutorId { get; set; }
        [Required]
        public int WydawnictwoId { get; set; }
        [Required]
        public int GatunekId { get; set; }

    }
}
