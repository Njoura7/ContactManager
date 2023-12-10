using System.ComponentModel.DataAnnotations;

namespace ContactManager.ViewModel
{
    public class ContactListViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        
        public string? PhoneNumber { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
