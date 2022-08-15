using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRY20220115.Data;
using PRY20220115.Models;
using PRY20220115.Models.Dto;
using PRY20220115.Repository;

namespace PRY20220115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PasajerosController : ControllerBase
    {
        private readonly IPasajeroRepository _pasajeroRepository;
        protected ResponseDto _response;

        public PasajerosController(IPasajeroRepository pasajeroRepository)
        {
            _pasajeroRepository = pasajeroRepository;
            _response = new ResponseDto();
        }

        // GET: api/Pasajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasajero>>> GetPasajeros()
        {
            try
            {
                var lista = await _pasajeroRepository.GetPasajeros();
                _response.Result = lista;
                _response.Message = "Lista de Pasajeros";
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };                
            }
            return Ok(_response);
        }

        // GET: api/Pasajeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasajero>> GetPasajero(int id)
        {
            var pasajero = await _pasajeroRepository.GetPasajeroById(id);
            if(pasajero == null)
            {
                _response.Success = false;
                _response.Message = "Pasajero No Existe";
                return NotFound(_response);
            }
            _response.Result = pasajero;
            _response.Message = "Datos del Pasajero";
            return Ok(_response);
        }

        // PUT: api/Pasajeros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasajero(int id, PasajeroDto pasajeroDto)
        {
            try
            {
                PasajeroDto model = await _pasajeroRepository.CreateUpdate(pasajeroDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = "Error al Actualizar el Pasajero";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Pasajeros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasajero>> PostPasajero(PasajeroDto pasajeroDto)
        {
            try
            {
                PasajeroDto model = await _pasajeroRepository.CreateUpdate(pasajeroDto);
                _response.Result = model;
                return CreatedAtAction("GetPasajero", new { id = model.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = "Error al Crear el Pasajero";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Pasajeros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasajero(int id)
        {
            try
            {
                bool isDelete = await _pasajeroRepository.DeletePasajero(id);
                if (isDelete)
                {
                    _response.Result = isDelete;
                    _response.Message = "Pasajero Eliminado con Éxito";
                    return Ok(_response);
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Error al Eliminar Pasajero";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
