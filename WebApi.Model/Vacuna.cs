using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Vacuna
    {
                public int? IdVacuna { get; set; }
        public string NombreVacuna { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } // True = Activa, False = Inactiva
        public DateTime FechaAplicacion { get; set; }
        public int IdAnimal { get; set; } // Relación con un animal

    }
}