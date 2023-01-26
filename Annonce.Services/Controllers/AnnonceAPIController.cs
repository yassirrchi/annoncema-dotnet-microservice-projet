using Annonce.Services.Migrations;
using Annonce.Services.Models.Dto;
using Annonce.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Annonce.Services.Controllers
{
    [Route("api/annonces")]
    public class AnnonceAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private IAnnonceRepository _annonceRepository;
        private static HttpClient _Http;
       

        public AnnonceAPIController(IAnnonceRepository annonceRepository)
        {
            _annonceRepository = annonceRepository;
            this._response = new ResponseDto();
            if (_Http == null)
            {
                _Http = new HttpClient();
                _Http.BaseAddress = new Uri("https://localhost:7100/");
                

            }
        }

        [HttpGet]
        public async Task<object> Get()
        {
            
            try
            {
                IEnumerable<AnnonceDto> annonceDtos = await _annonceRepository.GetAnnonces();
                foreach (AnnonceDto annonce in annonceDtos)
                {
                    annonce.User = await _Http.GetStringAsync("/api/users/" + annonce.UserId);
                    




                }

                _response.Result = annonceDtos;
               
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
                    AnnonceDto annonceDto = await _annonceRepository.GetAnnonceById(id);
                    annonceDto.User = await _Http.GetStringAsync("/api/users/" + annonceDto.UserId);
                   _response.Result = annonceDto;
                   
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
            [Authorize]
            public async Task<object> Post([FromBody] AnnonceDto annonceDto)
            {
                try
                {
                    AnnonceDto model = await _annonceRepository.CreateUpdateAnnonce(annonceDto);
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
            public async Task<object> Put([FromBody] AnnonceDto annonceDto)
            {
                try
                {
                    AnnonceDto model = await _annonceRepository.CreateUpdateAnnonce(annonceDto);
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
                    bool isSuccess = await _annonceRepository.DeleteAnnonce(id);
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

