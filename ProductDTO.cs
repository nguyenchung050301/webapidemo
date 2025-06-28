using System.ComponentModel.DataAnnotations;
namespace WebAPIDemo
{
    public class ProductDTO
    {

        //  public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal Price { get; set; }
      
    }
}
