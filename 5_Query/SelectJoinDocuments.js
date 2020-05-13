use FaculdadeDB

// A
db.Cursos.aggregate([ 
    {
        $lookup: {
            from: 'Professores', localField: 'ProfessorId', foreignField: '_id', as: 'Professor' 
        }
    },
    { $unwind: '$Professor' },
    { 
        $project: 
        {
            _id:0, CursoId: '$_id', Curso: '$Nome', DuracaoAnos:1, Valor:1, ProfessorId:1,
            Professor: '$Professor.Nome', ProfessorEmail: '$Professor.Email'
        } 
    }
])

// B
db.Cursos.aggregate([ 
    {
        $lookup: {
            from: 'Professores', localField: 'ProfessorId', foreignField: '_id', as: 'Professor' 
        }
    },
    { $unwind: { path: '$Professor', preserveNullAndEmptyArrays: true } },
    { 
        $project: 
        {
            _id:0, CursoId: '$_id', Curso: '$Nome', DuracaoAnos:1, Valor:1, ProfessorId:1,
            Professor: '$Professor.Nome', ProfessorEmail: '$Professor.Email'
        } 
    }
])

// C, D
db.Cursos.find({ 
    ProfessorId: { 
        $in: db.Professores.distinct('_id', {}) 
    } 
})

// E
db.Cursos.find({ 
    ProfessorId: { 
        $not: { $in: db.Professores.distinct('_id', {}) }
    } 
})

// F
db.CursosAlunos.aggregate([
    { $lookup: { from: 'Cursos', localField: 'CursoId', foreignField: '_id', as: 'Curso' } },
    { $unwind: '$Curso' },
    { $lookup: { from: 'Alunos', localField: 'AlunoId', foreignField: '_id', as: 'Aluno' } },
    { $unwind: '$Aluno' },
    { $lookup: { from: 'Professores', localField: 'Curso.ProfessorId', foreignField: '_id', as: 'Professor' } },
    { $unwind: '$Professor' },
    { 
        $project: 
        {
            _id:0, 
            CursoId:1, Curso:'$Curso.Nome',
            AlunoId:1, Aluno:'$Aluno.Nome',
            ProfessorId:'$Curso.ProfessorId', Professor:'$Professor.Nome'
        } 
    }
])

// G
db.CursosAlunos.aggregate([
    { $lookup: { from: 'Cursos', localField: 'CursoId', foreignField: '_id', as: 'Curso' } },
    { $unwind: '$Curso' },
    { $lookup: { from: 'Alunos', localField: 'AlunoId', foreignField: '_id', as: 'Aluno' } },
    { $unwind: '$Aluno' },
    { $lookup: { from: 'Professores', localField: 'Curso.ProfessorId', foreignField: '_id', as: 'Professor' } },
    { $unwind: { path: '$Professor', preserveNullAndEmptyArrays: true } },
    { 
        $project: 
        {
            _id:0, 
            CursoId:1, Curso:'$Curso.Nome',
            AlunoId:1, Aluno:'$Aluno.Nome',
            ProfessorId:'$Curso.ProfessorId', Professor:'$Professor.Nome'
        } 
    }
])