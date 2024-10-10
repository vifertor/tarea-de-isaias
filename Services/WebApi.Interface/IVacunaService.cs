using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;



namespace WebApi.Interface
{
       public interface IVacunaService
    {
        Task InsertarVacuna(Vacuna vacuna);
        Task ModificarVacuna(Vacuna vacuna);
        Task<Vacuna> BuscarVacunaPorId(int id);
        Task<List<Vacuna>> ListarVacunas();
        Task EliminarVacuna(int id);
    }
}