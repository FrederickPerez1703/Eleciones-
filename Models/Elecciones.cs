using System;
using System.Collections.Generic;

namespace Elecciones_itla.Models
{
    public partial class Elecciones
    {
        public Elecciones()
        {
            Partidos = new HashSet<Partidos>();
        }

        public int IdEleccion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRealizada { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Partidos> Partidos { get; set; }
    }
}
