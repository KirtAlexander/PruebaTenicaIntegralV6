using ApiContrats.Models;
using ApiContrats.DTOs; // Asegúrate de importar esto
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiContrats.Services
{
    public interface IContratService
    {
        Task<List<ContratResponseDto>> GetAllContratsAsync();

        Task<Contrat> CreateContratAsync(Contrat contrat);
    }
}