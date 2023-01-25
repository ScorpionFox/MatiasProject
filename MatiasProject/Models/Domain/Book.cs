using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //Niemapowane w bazie danych
        [NotMapped]
        public string? NameAutor { get; set; }
        [NotMapped]
        public string? NameWydawnictwo { get; set; }
        [NotMapped]
        public string? GatunekName { get; set; }
        [NotMapped]
        public List<SelectListItem>? AutorLista { get; set; }
        [NotMapped]
        public List<SelectListItem>? WydawnictwoLista { get; set; }
        [NotMapped]
        public List<SelectListItem>? GatunekLista { get; set; }

    }
}
