using System;
using System.Collections.Generic;

namespace Elecciones_itla.Models
{
    public partial class Ciudadanos
    {
        public Ciudadanos()
        {
            Votos = new HashSet<Votos>();
        }

        public int IdCiudadano { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public bool? Estado { get; set; }
        public int? PartidoCiuId { get; set; }

        public virtual Partidos PartidoCiu { get; set; }
        public virtual ICollection<Votos> Votos { get; set; }
    }
}
