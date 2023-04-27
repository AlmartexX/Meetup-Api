
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetupApi.DAL.Entities
{
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("PasswordHash")]
        public string PasswordHash { get; set; }
    }
}
