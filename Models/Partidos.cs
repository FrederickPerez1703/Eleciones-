using System;
using System.Collections.Generic;

namespace Elecciones_itla.Models
{
    public partial class Partidos
    {
        public Partidos()
        {
            Candidatos = new HashSet<Candidatos>();
            Ciudadanos = new HashSet<Ciudadanos>();
            PuestoElectivo = new HashSet<PuestoElectivo>();
        }

        public int IdPartido { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public bool? Estado { get; set; }
        public int? EleccionesId { get; set; }

        public virtual Elecciones Elecciones { get; set; }
        public virtual ICollection<Candidatos> Candidatos { get; set; }
        public virtual ICollection<Ciudadanos> Ciudadanos { get; set; }
        public virtual ICollection<PuestoElectivo> PuestoElectivo { get; set; }
    }
}
