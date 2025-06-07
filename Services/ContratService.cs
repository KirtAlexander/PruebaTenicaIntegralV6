using ApiContrats.Models;
using ApiContrats.DTOs;

namespace ApiContrats.Services
{
    public class ContratService : IContratService
    {
        private static List<Contrat> _contrats = new List<Contrat>
        {
            new Contrat { ContratId = Guid.NewGuid(), Entity = "Mi Entidad A", Validity = DateTime.Now,},
            new Contrat { ContratId = Guid.NewGuid(), Entity = "Otra Entidad B", Validity = DateTime.Now.AddMonths(-6)}
        };

        public async Task<List<ContratResponseDto>> GetAllContratsAsync()
        {
            await Task.Delay(100); 
            return _contrats.Select(c => new ContratResponseDto
            {
                Entity = c.Entity,
                Validity = c.Validity.ToString(),
            }).ToList();
        }

        public async Task<Contrat> CreateContratAsync(Contrat contrat)
        {
            await Task.Delay(50);

            if (contrat.ContratId == Guid.Empty)
            {
                contrat.ContratId = Guid.NewGuid();
            }

            _contrats.Add(contrat);
            return contrat;
        }
    }
}