using Elecciones_itla.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elecciones_itla.DTo
{
    public class CandidatoDto
    {

        public int IdCandidato { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? PartidoCanId { get; set; }
        public int? PuestoCanId { get; set; }
        public IFormFile Foto { get; set; }
        public bool? Estado { get; set; }

        public virtual Partidos PartidoCan { get; set; }
        public virtual PuestoElectivo PuestoCan { get; set; }
        public virtual ICollection<Votos> Votos { get; set; }
    }
}
