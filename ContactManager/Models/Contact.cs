using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Contact Name")]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
      
        [Required]
        public int CategoryId { get; set; }       
    }
}
