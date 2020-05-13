use FaculdadeDB

db.Alunos.insertMany([
    { _id:1, Nome:'Maria Aparecida de Santos', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'maria@dev.com.br', DataCriacao: new Date() },
    { _id:2, Nome:'João Mendes de Fibini', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'joão@dev.com.br', DataCriacao: new Date() },
    { _id:3, Nome:'José Pinto', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'josé@dev.com.br', DataCriacao: new Date() },
    { _id:4, Nome:'Juliana Alencar', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'juliana@dev.com.br', DataCriacao: new Date() },
    { _id:5, Nome:'Patricia Brito', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'patricia@dev.com.br', DataCriacao: new Date() },
    { _id:6, Nome:'Luiza Kaori Sato', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'luiza@dev.com.br', DataCriacao: new Date() },
    { _id:7, Nome:'Sabrina Santos de Souza', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'sabrina@dev.com.br', DataCriacao: new Date() },
    { _id:8, Nome:'Felipe Oliveira de Souza', DataNasc:'1989-07-13', Celular:'(11) 97845-4512', Email:'felipe@dev.com.br', DataCriacao: new Date() }
])

db.Professores.insertMany([
    { _id:1, Nome:'Mariana Jujuba', Celular:'(11) 97845-4512', Email:'mariana@dev.com.br', DataCriacao: new Date() },
    { _id:2, Nome:'Marcos Cesar Augustos', Celular:'(11) 97845-4512', Email:'marcos@dev.com.br', DataCriacao: new Date() },
    { _id:3, Nome:'Marcelo Xavier', Celular:'(11) 97845-4512', Email:'marcelo@dev.com.br', DataCriacao: new Date() },
    { _id:4, Nome:'Ana Maria Bunda', Celular:'(11) 97845-4512', Email:'ana@dev.com.br', DataCriacao: new Date() },
    { _id:5, Nome:'Roneiva Runiania', Celular:'(11) 97845-4512', Email:'roneiva@dev.com.br', DataCriacao: new Date() },
    { _id:6, Nome:'Cecilia Batista', Celular:'(11) 97845-4512', Email:'cecilia@dev.com.br', DataCriacao: new Date() },
    { _id:7, Nome:'Paulo Fabiosi', Celular:'(11) 97845-4512', Email:'paulo@dev.com.br', DataCriacao: new Date() },
    { _id:8, Nome:'Luciana Murilais', Celular:'(11) 97845-4512', Email:'luciana@dev.com.br', DataCriacao: new Date() }
])

db.Cursos.insertMany([
    { _id:2, Nome:'Gastronomia', DuracaoAnos:6.5, ProfessorId:1, DataCriacao: new Date() },
    { _id:3, Nome:'Contabilidade', DuracaoAnos:4.5, ProfessorId:1, DataCriacao: new Date() },
    { _id:4, Nome:'Fisioterapia', DuracaoAnos:2, ProfessorId:2, DataCriacao: new Date() },
    { _id:5, Nome:'Radiologia', DuracaoAnos:1.5, ProfessorId:2, DataCriacao: new Date() },
    { _id:6, Nome:'Análise de Sistemas', DuracaoAnos:4, ProfessorId:3, DataCriacao: new Date() },
    { _id:7, Nome:'Banco de dados', DuracaoAnos:4.5, ProfessorId:4, DataCriacao: new Date() },
    { _id:8, Nome:'Arquiteto de software', DuracaoAnos:8, ProfessorId:4, DataCriacao: new Date() },
    { _id:9, Nome:'Engenharia de software', DuracaoAnos:6, ProfessorId:4, DataCriacao: new Date() },
    { _id:10, Nome:'Psicologia', DuracaoAnos:3, ProfessorId:5, DataCriacao: new Date() },
    { _id:11, Nome:'Pedagogia', DuracaoAnos:2, ProfessorId:6, DataCriacao: new Date() },
    { _id:12, Nome:'Administração', DuracaoAnos:2, ProfessorId:6, DataCriacao: new Date() },
    { _id:13, Nome:'Engenharia', DuracaoAnos:7, ProfessorId:7, DataCriacao: new Date() }
])

db.CursosAlunos.insertMany([
    { AlunoId: 1, CursoId: 2 },
    { AlunoId: 2, CursoId: 2 },
    { AlunoId: 3, CursoId: 2 },
    { AlunoId: 4, CursoId: 2 },
    { AlunoId: 1, CursoId: 3 },
    { AlunoId: 5, CursoId: 3 },
    { AlunoId: 6, CursoId: 3 },
    { AlunoId: 2, CursoId: 4 },
    { AlunoId: 7, CursoId: 4 },
    { AlunoId: 8, CursoId: 4 },
    { AlunoId: 3, CursoId: 5 },
    { AlunoId: 4, CursoId: 5 },
    { AlunoId: 5, CursoId: 5 },
    { AlunoId: 6, CursoId: 6 },
    { AlunoId: 7, CursoId: 6 },
    { AlunoId: 8, CursoId: 7 },
    { AlunoId: 2, CursoId: 8 },
    { AlunoId: 3, CursoId: 8 },
    { AlunoId: 4, CursoId: 8 },
    { AlunoId: 5, CursoId: 8 },
    { AlunoId: 6, CursoId: 8 },
    { AlunoId: 2, CursoId: 9 },
    { AlunoId: 8, CursoId: 9 },
    { AlunoId: 7, CursoId: 10 },
    { AlunoId: 6, CursoId: 10 },
    { AlunoId: 5, CursoId: 11 },
    { AlunoId: 1, CursoId: 11 },
    { AlunoId: 4, CursoId: 12 },
    { AlunoId: 3, CursoId: 12 }
])