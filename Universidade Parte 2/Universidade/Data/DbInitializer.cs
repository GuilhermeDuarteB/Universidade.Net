using Universidade.Models;

namespace Universidade.Data
{
    public class DbInitializer
    {
        public static void Initialize(EscolaContexto context)
        {
            context.Database.EnsureCreated();

            // vai procurar qualquer estudante
            if (context.Estudantes.Any())
            {
                return; // DB inicializado
            }
            var estudantes = new Estudante[]
            {
                new Estudante{Nome="Guilherme",SobreNome="Branco",DataMatricula=DateTime.Parse("30-03-2007") },
                new Estudante{Nome="Sara",SobreNome="Matias",DataMatricula=DateTime.Parse("20-12-2008") },
                new Estudante{Nome="Afonso",SobreNome="Jaqim",DataMatricula=DateTime.Parse("23-01-2023") },
                new Estudante{Nome="Gumball",SobreNome="Watterson",DataMatricula=DateTime.Parse("25-03-2059") },
                new Estudante{Nome="Jaqim",SobreNome="Antunes",DataMatricula=DateTime.Parse("20-02-1999") },
                new Estudante{Nome="Tomás",SobreNome="José",DataMatricula=DateTime.Parse("02-02-2000") }
            };
            foreach (Estudante s in estudantes)
            {
                context.Estudantes.Add(s);
            }
            context.SaveChanges();

            var cursos = new Curso[]
            {
                new Curso{CursoID=0001, Titulo="Ciências e Tecnologias", Creditos=4,},
                new Curso{CursoID=0002, Titulo="Humanidades", Creditos=3,},
                new Curso{CursoID=0004, Titulo="Comunicação e Marketing", Creditos=3,},
                new Curso{CursoID=3333, Titulo="Informática de Gestão", Creditos=4,},
                new Curso{CursoID=0006, Titulo="Desporto", Creditos=3,},
                new Curso{CursoID=0008, Titulo="Economia", Creditos=4,},
                new Curso{CursoID=0009, Titulo="Psicologia", Creditos=4,},
            };
            foreach (Curso c in cursos)
            {
                context.Cursos.Add(c);
            }
            context.SaveChanges();

            var matriculas = new Matricula[]
            {
                   new Matricula{EstudanteID=1,CursoID=0001,Nota=Nota.A},
            new Matricula{EstudanteID=1,CursoID=0002,Nota=Nota.C},
            new Matricula{EstudanteID=1,CursoID=0004,Nota=Nota.B},
            new Matricula{EstudanteID=2,CursoID=3333,Nota=Nota.B},
            new Matricula{EstudanteID=2,CursoID=0006,Nota=Nota.F},
            new Matricula{EstudanteID=2,CursoID=0008,Nota=Nota.F},
            new Matricula{EstudanteID=3,CursoID=0001},
            new Matricula{EstudanteID=4,CursoID=0001,},
            new Matricula{EstudanteID=4,CursoID=0002,Nota=Nota.F},
            new Matricula{EstudanteID=5,CursoID=0004,Nota=Nota.C},
            new Matricula{EstudanteID=6,CursoID=3333},
            new Matricula{EstudanteID=7,CursoID=0006,Nota=Nota.A},
            };
            foreach (Matricula e in matriculas)
            {
                context.Matriculas.Add(e);
            }
            context.SaveChanges();
        }
    }
}
