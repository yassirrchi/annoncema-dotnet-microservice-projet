using User.Services.Models.Dto;
using User.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace user.Services.Controllers
{
    [Route("api/users")]
    public class UserAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private IUserRepository _userRepository;
        public UserAPIController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
          try
            {
                IEnumerable<UserDto> userDtos = await _userRepository.GetUsers();
                _response.Result = userDtos;
               
            }
                catch (Exception ex)
                 {
                   _response.IsSuccess = false;
                  _response.ErrorMessages
                      = new List<string>() { ex.ToString() };
                   }
            return _response;
        }

            [HttpGet]
            [Route("{id}")]
            public async Task<object> Get(int id)
            {
              try
               {
                    UserDto userDto = await _userRepository.GetUserById(id);
                    _response.Result = userDto;
                   
               }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages
                         = new List<string>() { ex.ToString() };
                }
            return _response;
        }


            [HttpPost]
            
            public async Task<object> Post([FromBody] UserDto userDto)
            {
                try
                {
                    UserDto model = await _userRepository.CreateUpdateUser(userDto);
                    _response.Result = model;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages
                         = new List<string>() { ex.ToString() };
                }
                return _response;
            }


        [HttpPost]
        [Route("/log")]
        public async Task<object> Log([FromBody] UserDto userDto)
        {
            try
            {
                UserDto model = await _userRepository.UserLog(userDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }



        [HttpPut]
            [Authorize]
            public async Task<object> Put([FromBody] UserDto userDto)
            {
                try
                {
                    UserDto model = await _userRepository.CreateUpdateUser(userDto);
                    _response.Result = model;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages
                         = new List<string>() { ex.ToString() };
                }
                return _response;
            }

            [HttpDelete]
            [Authorize(Roles = "Admin")]
            [Route("{id}")]
            public async Task<object> Delete(int id)
            {
                try
                {
                    bool isSuccess = await _userRepository.DeleteUser(id);
                    _response.Result = isSuccess;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages
                         = new List<string>() { ex.ToString() };
                }
                return _response;
            }
        }
    }

