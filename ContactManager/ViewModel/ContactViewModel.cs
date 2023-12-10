using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.ViewModel
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required]
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

        public IEnumerable<SelectListItem> Category { get; set; } = default!;
    }
}
