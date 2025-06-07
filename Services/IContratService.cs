using ApiContrats.Models;
using ApiContrats.DTOs;

namespace ApiContrats.Services
{
    public interface IContratService
    {
        Task<List<ContratResponseDto>> GetAllContratsAsync();

        Task<Contrat> CreateContratAsync(Contrat contrat);
    }
}