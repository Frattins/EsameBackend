using System.ComponentModel.DataAnnotations;

namespace EsameBackend.Models
{
    public class Anagrafica
    {
        [Key]
        public int Idanagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public string CAP { get; set; }
        public string Cod_Fisc { get; set; }
    }
}
