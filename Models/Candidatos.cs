using System;
using System.Collections.Generic;

namespace Elecciones_itla.Models
{
    public partial class Candidatos
    {
        public Candidatos()
        {
            Votos = new HashSet<Votos>();
        }

        public int IdCandidato { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? PartidoCanId { get; set; }
        public int? PuestoCanId { get; set; }
        public string Foto { get; set; }
        public bool? Estado { get; set; }

        public virtual Partidos PartidoCan { get; set; }
        public virtual PuestoElectivo PuestoCan { get; set; }
        public virtual ICollection<Votos> Votos { get; set; }
    }
}
