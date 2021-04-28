using System.ComponentModel.DataAnnotations;

namespace Shop.models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrgatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrgatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrgatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria invalida")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }

}