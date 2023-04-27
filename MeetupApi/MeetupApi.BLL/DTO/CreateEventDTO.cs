
namespace MeetupApi.BLL.DTO
{
    public class CreateEventDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Plan { get; set; }
        public string? Organizer { get; set; }
        public string? Speaker { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
    }
}
