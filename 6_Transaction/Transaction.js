use FaculdadeDB

session = db.getMongo().startSession({ readPreference: { mode: "primary" } })
session.startTransaction({ readConcern: { level: "local" }, writeConcern: { w: "majority" } })

try {
    prof = session.getDatabase('FaculdadeDB').Professores
    cursos = session.getDatabase('FaculdadeDB').Cursos
    
    prof.insertOne(
        { _id:9, Nome:'Sabrina Souza', Celular:'(11) 99574-8855', Email:'sabrina.souza@dev.com.br', DataCriacao: new Date() }
    )

    cursos.insertOne(
        { _id:14, Nome:'Dança', DuracaoAnos:2, ProfessorId:9, DataCriacao: new Date(), Valor: 3500 }
    )

    session.commitTransaction()    
} catch (error) {
    session.abortTransaction()
    throw error;
}

session.endSession()