using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Modelo do Carro")]
        public string? Modelo { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string? Marca { get; set; }

        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Display(Name = "Disponível?")]
        public bool Disponivel { get; set; }
    }
}
