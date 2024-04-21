using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Universidade.Models
{
    public class Estudante
    {
        public int EstudanteID { get; set; }

        [StringLength(50)]
        [Display(Name ="Último Nome")]
        public string SobreNome { get; set; }

        [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres.")]
        [Display(Name ="Primeiro Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data de Matrícula")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataMatricula { get; set; }

        [Display(Name ="Nome Completo")]
        public string NomeCompleto
        {
            get { return SobreNome + "," + Nome; }
        }

        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
