using PRY20220115.Models;
using PRY20220115.Models.Dto;

namespace PRY20220115.Repository
{
    public interface IPasajeroRepository
    {
        Task<List<PasajeroDto>> GetPasajeros();

        Task<PasajeroDto> GetPasajeroById(int id);

        Task<PasajeroDto> CreateUpdate(PasajeroDto pasajeroDto);

        Task<bool> DeletePasajero(int id);
    }
}
