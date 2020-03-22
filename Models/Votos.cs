using System;
using System.Collections.Generic;

namespace Elecciones_itla.Models
{
    public partial class Votos
    {
        public int IdCiudadanoVoto { get; set; }
        public int IdCandidatoVoto { get; set; }

        public virtual Candidatos IdCandidatoVotoNavigation { get; set; }
        public virtual Ciudadanos IdCiudadanoVotoNavigation { get; set; }
    }
}
