using System.ComponentModel.DataAnnotations;

namespace Universidade.ViewModels
{
    public class DataMatriculaGrupo
    {
        [DataType(DataType.Date)]
        public DateTime? DataMatricula { get; set; }
        public int EstudanteContador { get; set; }
    }
}
