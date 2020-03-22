using System;
using System.Collections.Generic;

namespace Elecciones_itla.Models
{
    public partial class PuestoElectivo
    {
        public PuestoElectivo()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public int? PartidoPuesId { get; set; }

        public virtual Partidos PartidoPues { get; set; }
        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}
