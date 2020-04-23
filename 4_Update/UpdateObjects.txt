use FaculdadeDB

db.Cursos.update({ _id: 2.0 }, { $set: { Valor: 4000 } })

db.Cursos.updateMany({ _id: { $in: [3, 4] } }, { $set: { Valor: 3500 } })

db.Cursos.updateMany({ $or: [ { _id: 5 }, { _id: 6 } ] }, { $set: { Valor: 2000 } })

db.Cursos.updateMany(
    { $and: [
        { _id: { $in: [7, 8, 9] } },
        { Valor: 0 }
    ]},
    { $set: { Valor: 6800 } }
)

db.Cursos.updateMany({ Valor: 0 }, { $set: { Valor: 5500 } })

db.Cursos.updateMany({ ProfessorId: 5 }, { $set: { ProfessorId: null } })