USE FaculdadeDB
GO

SELECT * FROM dbo.Cursos

SELECT * FROM dbo.Cursos WHERE Valor = 2000

SELECT * FROM dbo.Cursos WHERE Valor < 5000

SELECT * FROM dbo.Cursos WHERE Valor > 4000

SELECT * FROM dbo.Cursos WHERE Valor >= 5000

SELECT * FROM dbo.Cursos WHERE Valor <= 5000

SELECT * FROM dbo.Cursos WHERE Valor BETWEEN 3000 AND 4000

SELECT * FROM dbo.Cursos WHERE Nome LIKE 'A%'

SELECT * FROM dbo.Cursos WHERE DuracaoAnos IN (2, 3, 4)

SELECT * FROM dbo.Cursos WHERE DuracaoAnos NOT IN (2, 3, 4)

SELECT * FROM dbo.Cursos WHERE ProfessorId IS NULL

SELECT * FROM dbo.Cursos WHERE ProfessorId IS NOT NULL