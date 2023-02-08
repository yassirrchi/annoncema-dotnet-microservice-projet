using User.Services.DbContexts;
using User.Services.Models;
using User.Services.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace User.Services.Repository
{
   
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _db;

        private IMapper _mapper;











        public UserRepository(UserDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUpdateUser(UserDto userDto)
        {
            Users user = _mapper.Map<UserDto, Users>(userDto);
            if (user.UserId > 0)
            {
                _db.Users.Update(user);
            }
            else
            {
                _db.Users.Add(user);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Users, UserDto>(user);
        }


        public async Task<UserDto> UserLog(UserDto userDto)
        {
            Users user =await _db.Users.Where(x => x.email.Equals(userDto.email)
            && x.password.Equals(userDto.password)
            ).FirstOrDefaultAsync();

            if (user.UserId > 0)
            {
                return _mapper.Map<Users, UserDto>(user);
            }
            else
            {
                return _mapper.Map<Users, UserDto>(null);
            }
         
           
        }



        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                Users user = await _db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    return false;
                }
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            Users user = await _db.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            
            return _mapper.Map<UserDto>(user);
        }






        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            List<Users> userList = await _db.Users.ToListAsync();

           
            return _mapper.Map<List<UserDto>>(userList);

        }
    }
}
