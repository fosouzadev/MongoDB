use FaculdadeDB

// 1
db.Cursos.find()

// 2
db.Cursos.find({ Valor: 2000})

// 3
db.Cursos.find({ Valor: { $lt: 5000 } })

db.Cursos.find({ Valor: { $gt: 4000 } })

db.Cursos.find({ Valor: { $gte: 5000 } })

db.Cursos.find({ Valor: { $lte: 5000 } })

// 4
db.Cursos.find({ Valor: { $gte: 3000, $lte: 4000 } })
db.Cursos.find({ $and: [ 
    { Valor: { $gte: 3000 } }, 
    { Valor: { $lte: 4000 } } 
] })

// 5
// Consulta com like no SQL é usada como expressão regular no mongodb, estudar regex

// 6
db.Cursos.find({ DuracaoAnos: { $in: [ 2,3,4 ] } })

db.Cursos.find({ DuracaoAnos: { $not: { $in: [ 2,3,4 ] } } })

// 7
db.Cursos.find({ ProfessorId: null })

db.Cursos.find({ ProfessorId: { $ne: null } })

// 8
db.Cursos.find().sort({ DuracaoAnos: 1 })

db.Cursos.find().sort({ DuracaoAnos: -1 })