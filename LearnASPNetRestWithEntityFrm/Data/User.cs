using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnASPNetRestWithEntityFrmB1.Data
{
    [Table("users")]
    public class User
    {
        public User(int id, string userName, string firstName, string lastName, string city, string state, string country)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            State = state;
            Country = country;
        }

        public User()
        {

        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
