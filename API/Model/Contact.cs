using API.Enum;

namespace API.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public CategoryContact Category { get; set; }
        public string Subcategory { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

    }
}