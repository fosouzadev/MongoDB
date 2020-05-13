use FaculdadeDB

db.Cursos.updateMany({}, { $set: { Valor:0 } })