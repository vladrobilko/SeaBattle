using SeaBattle.Application.Models;
using SeaBattle.Repository.Models;
namespace SeaBattle.Application.Converters
{
    public static class NewSessionDtoConverter
    {
        public static NewSessionModel ConvertToSessionModel(this SessionDtoModel newSessionDto)
        {
            return new NewSessionModel() { HostPlayerName = newSessionDto.HostPlayerName, SessionName = newSessionDto.SessionName };
        }

        public static List<NewSessionModel> ConvertToListSessionModel(this List<SessionDtoModel> newSessionDto)
        {
            return newSessionDto
                .Select(ConvertToSessionModel)
                .ToList();
        }
    }
}
