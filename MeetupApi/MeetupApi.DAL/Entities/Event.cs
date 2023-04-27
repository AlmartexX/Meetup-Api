using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetupApi.DAL.Modells
{
    public class Event
    {
        [Key]
        [Column("id")]
        
        public int EventId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("plan")]
        public string? Plan { get; set; }

        [Column("organizer")]
        public string? Organizer { get; set; }

        [Column("speaker")]
        public string? Speaker { get; set; }

        [Column("time")]
        public DateTime Time { get; set; } 

        [Column("location")]
        public string Location { get; set; }

    }
}
