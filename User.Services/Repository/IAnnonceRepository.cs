using User.Services.Models.Dto;

namespace User.Services.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> CreateUpdateUser(UserDto userDto);
        Task<UserDto> UserLog(UserDto userDto);
        Task<bool> DeleteUser(int userId);
    }
}
