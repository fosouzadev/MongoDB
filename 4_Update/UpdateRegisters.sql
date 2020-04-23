USE FaculdadeDB
GO

UPDATE dbo.Cursos SET Valor = 4000 WHERE Id = 2
GO

UPDATE dbo.Cursos SET Valor = 3500 WHERE Id IN (3, 4)
GO

UPDATE dbo.Cursos SET Valor = 2000 WHERE Id = 5 OR Id = 6
GO

UPDATE dbo.Cursos SET Valor = 6800 WHERE Id IN (7, 8, 9) AND Valor = 0
GO

UPDATE dbo.Cursos SET Valor = 5500 WHERE Valor = 0
GO

UPDATE dbo.Cursos SET ProfessorId = NULL WHERE ProfessorId = 5
GO