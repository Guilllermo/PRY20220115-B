using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRY20220115.Data;
using PRY20220115.Models;
using PRY20220115.Models.Dto;

namespace PRY20220115.Repository
{
    public class PasajeroRepository : IPasajeroRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PasajeroRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<PasajeroDto> CreateUpdate(PasajeroDto pasajeroDto)
        {
            Pasajero pasajero = _mapper.Map<PasajeroDto, Pasajero>(pasajeroDto);
            if (pasajero.Id > 0)
            {
                _db.Pasajeros.Update(pasajero);
            }
            else
            {
                _db.Pasajeros.AddAsync(pasajero);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Pasajero, PasajeroDto>(pasajero);
        }

        public async Task<bool> DeletePasajero(int id)
        {
            try
            {
                Pasajero pasajero = await _db.Pasajeros.FindAsync(id);
                if (pasajero == null)
                {
                    return false;
                }
                _db.Pasajeros.Remove(pasajero);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PasajeroDto> GetPasajeroById(int id)
        {
            Pasajero pasajero = await _db.Pasajeros.FindAsync(id);

            return _mapper.Map<PasajeroDto>(pasajero);
        }

        public async Task<List<PasajeroDto>> GetPasajeros()
        {
            List<Pasajero> lista = await _db.Pasajeros.ToListAsync();

            return _mapper.Map<List<PasajeroDto>>(lista);
        }
    }
}
