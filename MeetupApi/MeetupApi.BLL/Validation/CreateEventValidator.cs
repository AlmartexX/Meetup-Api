using FluentValidation;
using MeetupApi.BLL.DTO;
using System.Globalization;

namespace MeetupApi.BLL.Infrastructure
{
    public class CreateEventValidator : AbstractValidator<CreateEventDTO>
    {
        public CreateEventValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty()
                .MaximumLength(80);

            RuleFor(e => e.Description)
                .MaximumLength(150);

            RuleFor(e => e.Plan)
                .MaximumLength(100);

            RuleFor(e => e.Organizer)
                .MaximumLength(110);

            RuleFor(e => e.Speaker)
                .MaximumLength(110);

            RuleFor(e => e.Time)
                .Must(s_beValidTime)
                .WithMessage("Time should be in format: yyyy-MM-ddTHH:mm:ssZ");

            RuleFor(e => e.Location)
                .MaximumLength(100);

        }
     
        private static bool s_beValidTime(DateTime time)
        {
            var timeString = time.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return DateTime.TryParseExact(timeString, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
