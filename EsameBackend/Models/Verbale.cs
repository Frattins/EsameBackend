using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsameBackend.Models
{
    public class Verbale
    {
        [Key]
        public int Idverbale { get; set; }

        public int Idanagrafica { get; set; }
        [ForeignKey("Idanagrafica")]
        public Anagrafica Anagrafica { get; set; }

        public int Idviolazione { get; set; }
        [ForeignKey("Idviolazione")]
        public TipoViolazione TipoViolazione { get; set; }

        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
