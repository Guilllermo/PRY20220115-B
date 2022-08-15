using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRY20220115.Models;
using PRY20220115.Models.Dto;
using PRY20220115.Repository;

namespace PRY20220115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto user)
        {
            var respuesta = await _userRepository.Register(
                    new User
                    {
                        UserName = user.UserName
                    }, user.Password);
            if (respuesta == -1)
            {
                _response.Success = false;
                _response.Message = "Usuario ya existe";
                return BadRequest(_response);
            }
            if(respuesta == -500)
            {
                _response.Success = false;
                _response.Message = "Error al crear el Usuario";
                return BadRequest(_response);
            }

            _response.Message = "Usuario creado con Éxito";
            _response.Result = respuesta;
            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto user)
        {
            var respuesta = await _userRepository.Login(user.UserName, user.Password);
            if(respuesta == "no user")
            {
                _response.Success = false;
                _response.Message = "Usuario no existe";
                return BadRequest(_response);
            }
            if(respuesta == "wrong password")
            {
                _response.Success = false;
                _response.Message = "Contraseña incorrecta";
                return BadRequest(_response);
            }
            _response.Result = respuesta;
            _response.Message = "Usuario Conectado";
            return Ok(_response);
        }
    }
}
