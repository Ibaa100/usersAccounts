using System.ComponentModel.DataAnnotations;

namespace usersAccounts.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        [DataType(DataType.EmailAddress)]       
        public string? Email { get; set; }
        [DataType(DataType.Password)]   
        public string? Password { get; set; }
        public bool IsActive { get; set; }  



    }
}
