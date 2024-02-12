using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.DatabaseContext
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options): base(options) { 
         
        }

        public DbSet<Contact> Contacts { get; set; }
        
        //Unikalnosc adresow email 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasIndex(c => c.Email).IsUnique();

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Name = "admin",
                    Surname = "admin",
                    Email = "admin@admin",
                    Password = PasswordFunction.PaswordHash.HashPassword("Admin1!"),
                    Category = Enum.CategoryContact.Business,
                    Subcategory = "Business",
                    PhoneNumber = "123456789",
                    BirthDate = DateTime.Now
                });
        }
    }
}
